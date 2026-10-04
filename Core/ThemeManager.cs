using System;
using System.Drawing;
using System.Windows.Forms;

namespace XpressShare.Core
{
    public static class ThemeManager
    {
        public static event EventHandler ThemeChanged;

        public static bool IsDarkMode
        {
            get { return AppSettings.Instance.DarkMode; }
            set
            {
                if (AppSettings.Instance.DarkMode != value)
                {
                    AppSettings.Instance.DarkMode = value;
                    AppSettings.Instance.Save();
                    if (ThemeChanged != null)
                    {
                        ThemeChanged(null, EventArgs.Empty);
                    }
                }
            }
        }

        public static void SetTheme(bool isDark)
        {
            IsDarkMode = isDark;
        }

        // Color definitions
        public static Color BackgroundColor
        {
            get { return IsDarkMode ? Color.FromArgb(21, 23, 26) : Color.FromArgb(245, 245, 245); }
        }

        public static Color PanelColor
        {
            get { return IsDarkMode ? Color.FromArgb(32, 35, 40) : Color.FromArgb(255, 255, 255); }
        }

        public static Color SecondaryPanelColor
        {
            get { return IsDarkMode ? Color.FromArgb(41, 45, 51) : Color.FromArgb(240, 240, 240); }
        }

        public static Color TextColor
        {
            get { return IsDarkMode ? Color.FromArgb(242, 242, 242) : Color.FromArgb(27, 31, 38); }
        }

        public static Color SecondaryTextColor
        {
            get { return IsDarkMode ? Color.FromArgb(184, 184, 184) : Color.FromArgb(90, 90, 90); }
        }

        public static Color BorderColor
        {
            get { return IsDarkMode ? Color.FromArgb(58, 63, 69) : Color.FromArgb(207, 207, 207); }
        }

        public static Color HeaderColor
        {
            get { return IsDarkMode ? Color.FromArgb(168, 0, 0) : Color.FromArgb(217, 0, 0); }
        }

        public static Color AccentRed
        {
            get { return IsDarkMode ? Color.FromArgb(224, 0, 0) : Color.FromArgb(217, 0, 0); }
        }

        public static Color ButtonColor
        {
            get { return IsDarkMode ? Color.FromArgb(25, 25, 25) : Color.FromArgb(27, 31, 38); }
        }

        public static Color ButtonHoverColor
        {
            get { return IsDarkMode ? Color.FromArgb(45, 48, 55) : Color.FromArgb(58, 63, 69); }
        }

        public static Color ButtonTextColor
        {
            get { return Color.White; }
        }

        public static Color SidebarColor
        {
            get { return IsDarkMode ? Color.FromArgb(17, 19, 23) : Color.FromArgb(37, 42, 48); }
        }

        public static Color SecondaryButtonColor
        {
            get { return IsDarkMode ? Color.FromArgb(45, 48, 55) : Color.FromArgb(243, 244, 246); }
        }

        public static Color SecondaryButtonTextColor
        {
            get { return IsDarkMode ? Color.FromArgb(242, 242, 242) : Color.FromArgb(37, 42, 48); }
        }

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = BackgroundColor;
            form.ForeColor = TextColor;

            ApplyThemeRecursive(form);
        }

        public static bool IsSidebarControl(Control c)
        {
            Control cur = c;
            while (cur != null)
            {
                if (cur.Name == "panelSidebar" || cur.Name == "panelSidebarMenu" || cur.Name == "panelSidebarBrand" || (cur.Tag as string) == "Sidebar")
                    return true;
                cur = cur.Parent;
            }
            return false;
        }

        private static void ApplyThemeRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                string tag = c.Tag as string ?? string.Empty;

                if (tag == "NoTheme")
                {
                    continue;
                }

                if (IsSidebarControl(c))
                {
                    if (c is Panel)
                    {
                        Panel p = (Panel)c;
                        if (p.Name == "panelSidebarBrand")
                            p.BackColor = IsDarkMode ? Color.FromArgb(18, 20, 24) : Color.FromArgb(28, 32, 37);
                        else if (p.Name == "panelBrandRedAccent")
                            p.BackColor = AccentRed;
                        else if (p.Name == "panelSidebarDivider")
                            p.BackColor = IsDarkMode ? Color.FromArgb(40, 45, 52) : Color.FromArgb(55, 62, 71);
                        else
                            p.BackColor = SidebarColor;
                    }
                    else if (c is Label)
                    {
                        Label lbl = (Label)c;
                        if (lbl.Name == "lblBrandName")
                            lbl.ForeColor = Color.White;
                        else
                            lbl.ForeColor = Color.FromArgb(160, 166, 173);
                    }
                    else if (c is Button)
                    {
                        Button btn = (Button)c;
                        if ("ACTIVE".Equals(btn.Tag))
                        {
                            btn.BackColor = Color.FromArgb(50, 57, 66);
                            btn.ForeColor = Color.White;
                        }
                        else
                        {
                            btn.BackColor = Color.Transparent;
                            btn.ForeColor = Color.FromArgb(210, 215, 220);
                        }
                    }

                    if (c.HasChildren)
                    {
                        ApplyThemeRecursive(c);
                    }
                    continue;
                }

                if (c is Panel)
                {
                    Panel p = (Panel)c;
                    if (p.Name == "panelHeader" || tag == "Header")
                    {
                        p.BackColor = HeaderColor;
                        p.ForeColor = Color.White;
                    }
                    else if (p.Name == "panelDropZone")
                    {
                        p.BackColor = PanelColor;
                    }
                    else
                    {
                        p.BackColor = PanelColor;
                        p.ForeColor = TextColor;
                    }
                }
                else if (c is Button)
                {
                    Button btn = (Button)c;
                    if (tag == "PrimaryAction")
                    {
                        btn.BackColor = AccentRed;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = AccentRed;
                    }
                    else
                    {
                        btn.BackColor = SecondaryButtonColor;
                        btn.ForeColor = SecondaryButtonTextColor;
                        btn.FlatAppearance.BorderColor = BorderColor;
                    }
                }
                else if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.BackColor = IsDarkMode ? Color.FromArgb(24, 27, 31) : Color.White;
                    txt.ForeColor = TextColor;
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown num = (NumericUpDown)c;
                    num.BackColor = IsDarkMode ? Color.FromArgb(24, 27, 31) : Color.White;
                    num.ForeColor = TextColor;
                }
                else if (c is ComboBox)
                {
                    ComboBox cbo = (ComboBox)c;
                    cbo.BackColor = IsDarkMode ? Color.FromArgb(24, 27, 31) : Color.White;
                    cbo.ForeColor = TextColor;
                }
                else if (c is ListView)
                {
                    ListView lv = (ListView)c;
                    lv.BackColor = PanelColor;
                    lv.ForeColor = TextColor;
                }
                else if (c is DataGridView)
                {
                    DataGridView dgv = (DataGridView)c;
                    dgv.BackgroundColor = PanelColor;
                    dgv.DefaultCellStyle.BackColor = PanelColor;
                    dgv.DefaultCellStyle.ForeColor = TextColor;
                }
                else if (c is CheckBox)
                {
                    CheckBox chk = (CheckBox)c;
                    chk.ForeColor = TextColor;
                }
                else if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.ForeColor = TextColor;
                }
                else if (c is Label)
                {
                    Label lbl = (Label)c;
                    if (tag == "HeaderTitle")
                    {
                        lbl.ForeColor = TextColor;
                    }
                    else if (tag == "Accent")
                    {
                        lbl.ForeColor = AccentRed;
                    }
                    else if (tag == "Muted")
                    {
                        lbl.ForeColor = SecondaryTextColor;
                    }
                    else if (lbl.Parent != null && (lbl.Parent.Name == "panelHeader" || lbl.Parent.Tag as string == "Header"))
                    {
                        lbl.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl.ForeColor = TextColor;
                    }
                }
                else if (c is MenuStrip)
                {
                    MenuStrip ms = (MenuStrip)c;
                    ms.BackColor = SecondaryPanelColor;
                    ms.ForeColor = TextColor;
                }
                else if (c is StatusStrip)
                {
                    StatusStrip ss = (StatusStrip)c;
                    ss.BackColor = SecondaryPanelColor;
                    ss.ForeColor = SecondaryTextColor;
                }

                if (c.HasChildren)
                {
                    ApplyThemeRecursive(c);
                }
            }
        }
    }
}
