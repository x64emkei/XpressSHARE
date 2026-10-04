using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Services;

namespace XpressShare.Forms.Controls
{
    public partial class ExplorerControl : UserControl
    {
        public event Action<string[]> SendFilesRequested;
        public event Action<string> StatusMessageChanged;

        private string _currentPath = string.Empty;
        private readonly List<string> _history = new List<string>();
        private int _historyIndex = -1;
        private bool _isNavigatingHistory = false;

        private ImageList _imgListSmall;
        private ImageList _imgListLarge;

        public ExplorerControl()
        {
            InitializeComponent();
            InitializeIconLists();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            listLocal.SmallImageList = _imgListSmall;
            listLocal.LargeImageList = _imgListLarge;
            listRemote.SmallImageList = _imgListSmall;
            listRemote.LargeImageList = _imgListLarge;

            PopulateRemotePeers();

            string initialPath = AppSettings.Instance.SelectedDownloadFolder;
            if (string.IsNullOrEmpty(initialPath) || !Directory.Exists(initialPath))
            {
                initialPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            NavigateTo(initialPath);
        }

        private void InitializeIconLists()
        {
            _imgListSmall = new ImageList();
            _imgListSmall.ImageSize = new Size(16, 16);
            _imgListSmall.ColorDepth = ColorDepth.Depth32Bit;

            _imgListLarge = new ImageList();
            _imgListLarge.ImageSize = new Size(32, 32);
            _imgListLarge.ColorDepth = ColorDepth.Depth32Bit;

            _imgListSmall.Images.Add("folder", CreateFolderBitmap(Color.FromArgb(245, 158, 11), 16));
            _imgListSmall.Images.Add("drive", CreateDriveBitmap(Color.FromArgb(59, 130, 246), 16));
            _imgListSmall.Images.Add("file", CreateFileBitmap(Color.FromArgb(107, 114, 128), 16));
            _imgListSmall.Images.Add("exe", CreateFileBitmap(Color.FromArgb(16, 185, 129), 16));
            _imgListSmall.Images.Add("zip", CreateFileBitmap(Color.FromArgb(224, 0, 0), 16));

            _imgListLarge.Images.Add("folder", CreateFolderBitmap(Color.FromArgb(245, 158, 11), 32));
            _imgListLarge.Images.Add("drive", CreateDriveBitmap(Color.FromArgb(59, 130, 246), 32));
            _imgListLarge.Images.Add("file", CreateFileBitmap(Color.FromArgb(107, 114, 128), 32));
            _imgListLarge.Images.Add("exe", CreateFileBitmap(Color.FromArgb(16, 185, 129), 32));
            _imgListLarge.Images.Add("zip", CreateFileBitmap(Color.FromArgb(224, 0, 0), 32));
        }

        private Bitmap CreateFolderBitmap(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, 1, 3, size - 2, size - 5);
                    g.FillRectangle(brush, 1, 1, size / 2, 4);
                }
            }
            return bmp;
        }

        private Bitmap CreateDriveBitmap(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                using (Brush brush = new SolidBrush(Color.FromArgb(40, color)))
                {
                    g.FillRectangle(brush, 1, size / 4, size - 3, size / 2);
                    g.DrawRectangle(pen, 1, size / 4, size - 3, size / 2);
                }
            }
            return bmp;
        }

        private Bitmap CreateFileBitmap(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Pen pen = new Pen(color, Math.Max(1.2f, size / 16f)))
                using (Brush brush = new SolidBrush(Color.FromArgb(20, color)))
                {
                    g.FillRectangle(brush, 2, 1, size - 5, size - 2);
                    g.DrawRectangle(pen, 2, 1, size - 5, size - 2);
                    g.DrawLine(pen, 4, 5, size - 5, 5);
                    g.DrawLine(pen, 4, 8, size - 5, 8);
                }
            }
            return bmp;
        }

        public void NavigateTo(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            if (!_isNavigatingHistory)
            {
                if (_historyIndex >= 0 && _historyIndex < _history.Count - 1)
                {
                    _history.RemoveRange(_historyIndex + 1, _history.Count - (_historyIndex + 1));
                }
                _history.Add(path);
                _historyIndex = _history.Count - 1;
            }

            _currentPath = path;
            txtAddress.Text = path;

            btnNavBack.Enabled = _historyIndex > 0;
            btnNavForward.Enabled = _historyIndex < _history.Count - 1;
            btnNavUp.Enabled = (path != "THIS_PC" && !string.IsNullOrEmpty(Path.GetPathRoot(path)) && Path.GetPathRoot(path) != path);

            if (path == "THIS_PC")
            {
                lblLocalHeaderTitle.Text = "This PC (Local Storage Drives)";
                PopulateThisPc(listLocal);
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    NotifyStatus("Directory does not exist: " + path);
                    return;
                }

                string name = Path.GetFileName(path);
                lblLocalHeaderTitle.Text = string.IsNullOrEmpty(name) ? path : name;
                PopulateFolder(listLocal, path, txtSearch.Text);
            }

            UpdateSelectionStatus();
            NotifyStatus("Navigated to " + path);
        }

        private void PopulateThisPc(ListView target)
        {
            target.BeginUpdate();
            target.Items.Clear();
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo d in drives)
                {
                    if (!d.IsReady) continue;
                    string name = string.Format("{0} ({1})", string.IsNullOrEmpty(d.VolumeLabel) ? "Local Disk" : d.VolumeLabel, d.Name.TrimEnd('\\'));
                    ListViewItem item = new ListViewItem(name);
                    item.ImageKey = "drive";
                    item.Tag = d.RootDirectory.FullName;
                    item.SubItems.Add("--");
                    item.SubItems.Add(d.DriveType.ToString() + " Disk");
                    item.SubItems.Add(string.Format("{0} free of {1}", FormatSize(d.TotalFreeSpace), FormatSize(d.TotalSize)));
                    item.SubItems.Add("Ready");
                    target.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("PopulateThisPc error: " + ex.Message);
            }
            finally
            {
                target.EndUpdate();
            }
        }

        private void PopulateFolder(ListView target, string path, string filter)
        {
            target.BeginUpdate();
            target.Items.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                DirectoryInfo[] subDirs = dir.GetDirectories();
                foreach (DirectoryInfo d in subDirs)
                {
                    if ((d.Attributes & FileAttributes.Hidden) != 0) continue;
                    if (!string.IsNullOrEmpty(filter) && filter != "Search files..." && d.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) < 0) continue;

                    ListViewItem item = new ListViewItem(d.Name);
                    item.ImageKey = "folder";
                    item.Tag = d.FullName;
                    item.SubItems.Add(d.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add("File folder");
                    item.SubItems.Add("--");
                    item.SubItems.Add("Folder");
                    target.Items.Add(item);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo f in files)
                {
                    if ((f.Attributes & FileAttributes.Hidden) != 0) continue;
                    if (!string.IsNullOrEmpty(filter) && filter != "Search files..." && f.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) < 0) continue;

                    ListViewItem item = new ListViewItem(f.Name);
                    string ext = f.Extension.ToLowerInvariant();
                    if (ext == ".exe" || ext == ".msi") item.ImageKey = "exe";
                    else if (ext == ".zip" || ext == ".rar" || ext == ".7z" || ext == ".xpx") item.ImageKey = "zip";
                    else item.ImageKey = "file";

                    item.Tag = f.FullName;
                    item.SubItems.Add(f.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(string.IsNullOrEmpty(ext) ? "File" : ext.TrimStart('.').ToUpperInvariant() + " File");
                    item.SubItems.Add(FormatSize(f.Length));
                    item.SubItems.Add("Ready");
                    target.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("PopulateFolder error: " + ex.Message);
            }
            finally
            {
                target.EndUpdate();
            }
        }

        public void PopulateRemotePeers()
        {
            cboRemotePeer.Items.Clear();
            cboRemotePeer.Items.Add("Local: Downloads Folder");

            TrustedDeviceService trustedService = ServiceRegistry.Resolve<TrustedDeviceService>("TrustedDeviceService");
            if (trustedService != null)
            {
                var trusted = trustedService.GetTrustedDevices();
                foreach (var t in trusted)
                {
                    cboRemotePeer.Items.Add(new MainForm.DeviceItem
                    {
                        DeviceId = t.DeviceId,
                        DeviceName = t.Name,
                        IpAddress = t.IpAddress,
                        Port = AppSettings.Instance.TransferPort > 0 ? AppSettings.Instance.TransferPort : 15001,
                        ConnectionType = t.ConnectionType,
                        IsTrusted = true
                    });
                }
            }

            if (cboRemotePeer.Items.Count > 0 && cboRemotePeer.SelectedIndex < 0)
            {
                cboRemotePeer.SelectedIndex = 0;
            }
        }

        private void CboRemotePeer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRemotePeer.SelectedItem is MainForm.DeviceItem)
            {
                MainForm.DeviceItem dev = (MainForm.DeviceItem)cboRemotePeer.SelectedItem;
                lblRemoteHeaderTitle.Text = "Peer: " + dev.DeviceName + " (" + dev.IpAddress + ")";
                listRemote.Items.Clear();

                ListViewItem item = new ListViewItem("Drag files here to transmit to " + dev.DeviceName);
                item.SubItems.Add("--");
                item.SubItems.Add("Remote Peer Drop Target");
                item.SubItems.Add("--");
                item.SubItems.Add("Ready for Drop");
                listRemote.Items.Add(item);
            }
            else
            {
                lblRemoteHeaderTitle.Text = "Local Destination: Downloads";
                string down = AppSettings.Instance.SelectedDownloadFolder;
                if (!string.IsNullOrEmpty(down) && Directory.Exists(down))
                {
                    PopulateFolder(listRemote, down, null);
                }
            }
        }

        private void UpdateSelectionStatus()
        {
            int count = listLocal.SelectedItems.Count;
            btnActSend.Enabled = count > 0;
            btnActCopy.Enabled = count > 0;
            btnActDelete.Enabled = count > 0;

            if (count > 0)
            {
                long totalBytes = 0;
                foreach (ListViewItem item in listLocal.SelectedItems)
                {
                    string path = item.Tag as string;
                    if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    {
                        try { totalBytes += new FileInfo(path).Length; } catch { }
                    }
                }
                lblStatusInfo.Text = string.Format("{0} item{1} selected ({2})", count, count == 1 ? "" : "s", FormatSize(totalBytes));
            }
            else
            {
                lblStatusInfo.Text = string.Format("{0} items in folder", listLocal.Items.Count);
            }
        }

        private void ListLocal_ItemActivate(object sender, EventArgs e)
        {
            if (listLocal.SelectedItems.Count == 0) return;
            string targetPath = listLocal.SelectedItems[0].Tag as string;
            if (string.IsNullOrEmpty(targetPath)) return;

            if (Directory.Exists(targetPath))
            {
                NavigateTo(targetPath);
            }
            else if (File.Exists(targetPath))
            {
                try
                {
                    Process.Start(targetPath);
                    NotifyStatus("Opened: " + Path.GetFileName(targetPath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectionStatus();
        }

        private void BtnNavBack_Click(object sender, EventArgs e)
        {
            if (_historyIndex > 0)
            {
                _isNavigatingHistory = true;
                _historyIndex--;
                NavigateTo(_history[_historyIndex]);
                _isNavigatingHistory = false;
            }
        }

        private void BtnNavForward_Click(object sender, EventArgs e)
        {
            if (_historyIndex < _history.Count - 1)
            {
                _isNavigatingHistory = true;
                _historyIndex++;
                NavigateTo(_history[_historyIndex]);
                _isNavigatingHistory = false;
            }
        }

        private void BtnNavUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPath) || _currentPath == "THIS_PC") return;
            DirectoryInfo parent = Directory.GetParent(_currentPath);
            if (parent != null) NavigateTo(parent.FullName);
            else NavigateTo("THIS_PC");
        }

        private void BtnNavRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentPath))
            {
                NavigateTo(_currentPath);
            }
            PopulateRemotePeers();
        }

        private void TxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string path = txtAddress.Text.Trim();
                if (path.Equals("This PC", StringComparison.OrdinalIgnoreCase))
                {
                    NavigateTo("THIS_PC");
                }
                else if (Directory.Exists(path))
                {
                    NavigateTo(path);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPath) || _currentPath == "THIS_PC") return;
            string filter = (txtSearch.Text == "Search files...") ? "" : txtSearch.Text;
            PopulateFolder(listLocal, _currentPath, filter);
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search files...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Search files...";
                txtSearch.ForeColor = Color.FromArgb(156, 163, 175);
            }
        }

        // Quick Jump buttons
        private void BtnJumpThisPc_Click(object sender, EventArgs e) { NavigateTo("THIS_PC"); }
        private void BtnJumpDesktop_Click(object sender, EventArgs e) { NavigateTo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)); }
        private void BtnJumpDocuments_Click(object sender, EventArgs e) { NavigateTo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)); }
        private void BtnJumpDownloads_Click(object sender, EventArgs e)
        {
            string down = AppSettings.Instance.SelectedDownloadFolder;
            if (string.IsNullOrEmpty(down) || !Directory.Exists(down))
            {
                down = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            NavigateTo(down);
        }
        private void BtnJumpPictures_Click(object sender, EventArgs e) { NavigateTo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)); }

        // Action Toolbar
        private void BtnActToggleDual_Click(object sender, EventArgs e)
        {
            splitPanes.Panel2Collapsed = !splitPanes.Panel2Collapsed;
            btnActToggleDual.Checked = !splitPanes.Panel2Collapsed;
            NotifyStatus(splitPanes.Panel2Collapsed ? "Single-pane mode enabled." : "Dual-pane mode enabled.");
        }

        private void BtnActSend_Click(object sender, EventArgs e)
        {
            List<string> selected = GetSelectedFiles();
            if (selected.Count > 0 && SendFilesRequested != null)
            {
                SendFilesRequested(selected.ToArray());
            }
        }

        private void BtnActCopy_Click(object sender, EventArgs e)
        {
            List<string> files = GetSelectedFiles();
            if (files.Count > 0)
            {
                System.Collections.Specialized.StringCollection col = new System.Collections.Specialized.StringCollection();
                col.AddRange(files.ToArray());
                Clipboard.SetFileDropList(col);
                NotifyStatus(string.Format("Copied {0} file(s) to clipboard.", files.Count));
            }
        }

        private void BtnActDelete_Click(object sender, EventArgs e)
        {
            List<string> files = GetSelectedFiles();
            if (files.Count == 0) return;

            string msg = string.Format("Are you sure you want to delete the selected {0} item(s)?", files.Count);
            if (MessageBox.Show(msg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (string f in files)
                {
                    try
                    {
                        if (File.Exists(f)) File.Delete(f);
                        else if (Directory.Exists(f)) Directory.Delete(f, true);
                    }
                    catch { }
                }
                PopulateFolder(listLocal, _currentPath, txtSearch.Text);
                NotifyStatus("Deleted selected item(s).");
            }
        }

        private void BtnActNewFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPath) || _currentPath == "THIS_PC" || !Directory.Exists(_currentPath)) return;
            try
            {
                string baseName = "New Folder";
                string newDir = Path.Combine(_currentPath, baseName);
                int count = 1;
                while (Directory.Exists(newDir))
                {
                    newDir = Path.Combine(_currentPath, string.Format("{0} ({1})", baseName, count++));
                }
                Directory.CreateDirectory(newDir);
                PopulateFolder(listLocal, _currentPath, txtSearch.Text);
                NotifyStatus("Created: " + Path.GetFileName(newDir));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuDetails_Click(object sender, EventArgs e) { listLocal.View = View.Details; listRemote.View = View.Details; }
        private void MenuList_Click(object sender, EventArgs e) { listLocal.View = View.List; listRemote.View = View.List; }
        private void MenuIcons_Click(object sender, EventArgs e) { listLocal.View = View.LargeIcon; listRemote.View = View.LargeIcon; }

        private List<string> GetSelectedFiles()
        {
            List<string> list = new List<string>();
            foreach (ListViewItem item in listLocal.SelectedItems)
            {
                string path = item.Tag as string;
                if (!string.IsNullOrEmpty(path)) list.Add(path);
            }
            return list;
        }

        // Drag and Drop
        private void ListLocal_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<string> files = GetSelectedFiles();
            if (files.Count > 0)
            {
                DataObject data = new DataObject(DataFormats.FileDrop, files.ToArray());
                DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        private void ListRemote_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListRemote_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    if (cboRemotePeer.SelectedItem is MainForm.DeviceItem)
                    {
                        MainForm.DeviceItem dev = (MainForm.DeviceItem)cboRemotePeer.SelectedItem;
                        if (SendFilesRequested != null)
                        {
                            SendFilesRequested(files);
                        }
                    }
                    else
                    {
                        string destFolder = AppSettings.Instance.SelectedDownloadFolder;
                        if (Directory.Exists(destFolder))
                        {
                            foreach (string f in files)
                            {
                                try
                                {
                                    string dest = Path.Combine(destFolder, Path.GetFileName(f));
                                    if (File.Exists(f) && f != dest) File.Copy(f, dest, true);
                                }
                                catch { }
                            }
                            PopulateFolder(listRemote, destFolder, null);
                            NotifyStatus(string.Format("Copied {0} file(s) to Downloads.", files.Length));
                        }
                    }
                }
            }
        }

        private void NotifyStatus(string message)
        {
            if (StatusMessageChanged != null)
            {
                StatusMessageChanged(message);
            }
        }

        private string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
