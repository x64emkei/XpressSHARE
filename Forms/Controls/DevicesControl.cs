using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Services;
using TransferOptimizer = XpressShare.Services.TransferOptimizer;

namespace XpressShare.Forms.Controls
{
    public partial class DevicesControl : UserControl
    {
        public event Action<MainForm.DeviceItem> SendFileToDeviceRequested;
        public event Action<string> StatusMessageChanged;

        private TrustedDeviceService _trustedDeviceService;
        private LanDiscoveryService _discoveryService;
        private DeviceIdentity _localIdentity;
        private readonly List<MainForm.DeviceItem> _discoveredDevices = new List<MainForm.DeviceItem>();
        private readonly object _deviceLock = new object();

        public DevicesControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            _trustedDeviceService = ServiceRegistry.Resolve<TrustedDeviceService>("TrustedDeviceService");
            _localIdentity = ServiceRegistry.Resolve<DeviceIdentity>("DeviceIdentity");
            _discoveryService = new LanDiscoveryService();
            _discoveryService.DeviceDiscovered += DiscoveryService_DeviceDiscovered;

            if (_localIdentity != null)
            {
                _discoveryService.Start(_localIdentity);
            }

            RefreshDevicesGrid();
        }

        private void DiscoveryService_DeviceDiscovered(object sender, DeviceDiscoveredEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DeviceDiscoveredEventArgs>(OnDeviceDiscoveredUI), e);
            }
            else
            {
                OnDeviceDiscoveredUI(e);
            }
        }

        private void OnDeviceDiscoveredUI(DeviceDiscoveredEventArgs e)
        {
            lock (_deviceLock)
            {
                bool exists = false;
                foreach (var d in _discoveredDevices)
                {
                    if (d.DeviceId == e.DeviceId || d.IpAddress == e.IpAddress)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    _discoveredDevices.Add(new MainForm.DeviceItem
                    {
                        DeviceId = e.DeviceId,
                        DeviceName = e.DeviceName,
                        IpAddress = e.IpAddress,
                        Port = AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort : 15001,
                        ConnectionType = "LAN",
                        IsTrusted = false
                    });
                }
            }
            RefreshDevicesGrid();
        }

        public void RefreshDevicesGrid()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(RefreshDevicesGrid));
                return;
            }

            dgvDevices.Rows.Clear();

            // 1. This Computer
            string myIp = _localIdentity != null && !string.IsNullOrEmpty(_localIdentity.LocalIpAddress) ? _localIdentity.LocalIpAddress : "127.0.0.1";
            int selfRow = dgvDevices.Rows.Add(
                "● Online",
                Environment.MachineName + " (This Computer)",
                myIp,
                AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort.ToString() : "15001",
                TransferOptimizer.GetActiveConnectionType().ToString(),
                "Local Workstation",
                "Now"
            );
            dgvDevices.Rows[selfRow].Cells[0].Style.ForeColor = Color.FromArgb(16, 185, 129);
            dgvDevices.Rows[selfRow].DefaultCellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);

            // 2. Trusted / Paired Devices
            if (_trustedDeviceService != null)
            {
                var trusted = _trustedDeviceService.GetTrustedDevices();
                foreach (var t in trusted)
                {
                    MainForm.DeviceItem dev = new MainForm.DeviceItem
                    {
                        DeviceId = t.DeviceId,
                        DeviceName = t.Name,
                        IpAddress = string.IsNullOrEmpty(t.IpAddress) ? "127.0.0.1" : t.IpAddress,
                        Port = AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort : 15001,
                        ConnectionType = string.IsNullOrEmpty(t.ConnectionType) ? "Ethernet" : t.ConnectionType,
                        IsTrusted = true
                    };

                    int r = dgvDevices.Rows.Add(
                        "● Online",
                        t.Name,
                        dev.IpAddress,
                        dev.Port.ToString(),
                        dev.ConnectionType,
                        "Trusted / Paired",
                        "Active"
                    );
                    dgvDevices.Rows[r].Tag = dev;
                    dgvDevices.Rows[r].Cells[0].Style.ForeColor = Color.FromArgb(16, 185, 129);
                    dgvDevices.Rows[r].Cells[5].Style.ForeColor = Color.FromArgb(37, 99, 235);
                }
            }

            // 3. Discovered Unpaired Devices
            lock (_deviceLock)
            {
                foreach (var d in _discoveredDevices)
                {
                    bool isPaired = false;
                    if (_trustedDeviceService != null)
                    {
                        foreach (var t in _trustedDeviceService.GetTrustedDevices())
                        {
                            if (t.DeviceId == d.DeviceId || t.IpAddress == d.IpAddress) { isPaired = true; break; }
                        }
                    }
                    if (isPaired) continue;

                    int r = dgvDevices.Rows.Add(
                        "○ Discovered",
                        d.DeviceName,
                        d.IpAddress,
                        d.Port.ToString(),
                        d.ConnectionType,
                        "Unpaired Peer",
                        "Recent"
                    );
                    dgvDevices.Rows[r].Tag = d;
                    dgvDevices.Rows[r].Cells[0].Style.ForeColor = Color.FromArgb(245, 158, 11);
                    dgvDevices.Rows[r].Cells[5].Style.ForeColor = Color.Gray;
                }
            }

            lblDeviceCount.Text = string.Format("{0} registered & discovered device(s) on network", dgvDevices.Rows.Count);
            UpdateActionStates();
        }

        private void UpdateActionStates()
        {
            bool hasItem = dgvDevices.SelectedRows.Count > 0 && dgvDevices.SelectedRows[0].Tag is MainForm.DeviceItem;
            if (hasItem)
            {
                MainForm.DeviceItem dev = (MainForm.DeviceItem)dgvDevices.SelectedRows[0].Tag;
                btnPair.Enabled = !dev.IsTrusted;
                btnUnpair.Enabled = dev.IsTrusted;
                btnSendFile.Enabled = true;
                btnProperties.Enabled = true;
            }
            else
            {
                btnPair.Enabled = false;
                btnUnpair.Enabled = false;
                btnSendFile.Enabled = false;
                btnProperties.Enabled = false;
            }
        }

        private void DgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            UpdateActionStates();
        }

        private void BtnDiscover_Click(object sender, EventArgs e)
        {
            if (_discoveryService != null && _localIdentity != null)
            {
                _discoveryService.Start(_localIdentity);
                NotifyStatus("Broadcasted UDP discovery packet across subnet...");
                RefreshDevicesGrid();
            }
        }

        private void BtnPair_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0 || !(dgvDevices.SelectedRows[0].Tag is MainForm.DeviceItem)) return;

            MainForm.DeviceItem dev = (MainForm.DeviceItem)dgvDevices.SelectedRows[0].Tag;
            if (_trustedDeviceService != null)
            {
                _trustedDeviceService.PairDevice(dev.DeviceId, dev.DeviceName, dev.IpAddress, dev.ConnectionType);
                dev.IsTrusted = true;
                RefreshDevicesGrid();
                MessageBox.Show(string.Format("Device '{0}' ({1}) has been paired and trusted for high-speed file sharing.", dev.DeviceName, dev.IpAddress), "Pairing Established", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NotifyStatus("Paired with " + dev.DeviceName);
            }
        }

        private void BtnUnpair_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0 || !(dgvDevices.SelectedRows[0].Tag is MainForm.DeviceItem)) return;

            MainForm.DeviceItem dev = (MainForm.DeviceItem)dgvDevices.SelectedRows[0].Tag;
            if (_trustedDeviceService != null)
            {
                string msg = string.Format("Revoke pairing with device '{0}' ({1})?", dev.DeviceName, dev.IpAddress);
                if (MessageBox.Show(msg, "Confirm Unpair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _trustedDeviceService.RemoveTrustedDevice(dev.DeviceId);
                    dev.IsTrusted = false;
                    RefreshDevicesGrid();
                    NotifyStatus("Unpaired device " + dev.DeviceName);
                }
            }
        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0 || !(dgvDevices.SelectedRows[0].Tag is MainForm.DeviceItem)) return;

            MainForm.DeviceItem dev = (MainForm.DeviceItem)dgvDevices.SelectedRows[0].Tag;
            if (SendFileToDeviceRequested != null)
            {
                SendFileToDeviceRequested(dev);
            }
        }

        private void BtnProperties_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0) return;
            if (dgvDevices.SelectedRows[0].Tag is MainForm.DeviceItem)
            {
                MainForm.DeviceItem dev = (MainForm.DeviceItem)dgvDevices.SelectedRows[0].Tag;
                string msg = string.Format("Device Name: {0}\nDevice ID: {1}\nIP Address: {2}\nTransfer Port: {3}\nInterface: {4}\nTrust Status: {5}",
                    dev.DeviceName, dev.DeviceId, dev.IpAddress, dev.Port, dev.ConnectionType, dev.IsTrusted ? "Trusted / Paired" : "Unpaired Discovered");
                MessageBox.Show(msg, "Device Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string report = TransferOptimizer.GetDiagnosticReport();
                MessageBox.Show(report, "Local Computer Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NotifyStatus(string message)
        {
            if (StatusMessageChanged != null) StatusMessageChanged(message);
        }
    }
}
