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
            get { return IsDarkMode ? Color.FromArgb(17, 19, 23) : Color.FromArgb(27, 31, 38); }
        }

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = BackgroundColor;
            form.ForeColor = TextColor;

            ApplyThemeRecursive(form);
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

                if (c is Panel)
                {
                    Panel p = (Panel)c;
                    if (p.Name == "panelHeader" || tag == "Header")
                    {
                        p.BackColor = HeaderColor;
                        p.ForeColor = Color.White;
                    }
                    else if (p.Name == "panelSidebar" || tag == "Sidebar")
                    {
                        p.BackColor = SidebarColor;
                        p.ForeColor = TextColor;
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
                    if (tag != "NavActive")
                    {
                        if (tag == "PrimaryAction")
                        {
                            btn.BackColor = ButtonColor;
                            btn.ForeColor = ButtonTextColor;
                            btn.FlatAppearance.BorderColor = BorderColor;
                        }
                        else if (tag != "Nav")
                        {
                            btn.BackColor = ButtonColor;
                            btn.ForeColor = ButtonTextColor;
                            btn.FlatAppearance.BorderColor = BorderColor;
                        }
                    }
                }
                else if (c is TextBox)
                {
                    TextBox txt = (TextBox)c;
                    txt.BackColor = SecondaryPanelColor;
                    txt.ForeColor = TextColor;
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown num = (NumericUpDown)c;
                    num.BackColor = SecondaryPanelColor;
                    num.ForeColor = TextColor;
                }
                else if (c is ComboBox)
                {
                    ComboBox cbo = (ComboBox)c;
                    cbo.BackColor = SecondaryPanelColor;
                    cbo.ForeColor = TextColor;
                }
                else if (c is ListView)
                {
                    ListView lv = (ListView)c;
                    lv.BackColor = PanelColor;
                    lv.ForeColor = TextColor;
                }
                else if (c is CheckBox)
                {
                    CheckBox chk = (CheckBox)c;
                    chk.ForeColor = TextColor;
                }
                else if (c is Label)
                {
                    Label lbl = (Label)c;
                    if (tag == "HeaderTitle")
                    {
                        lbl.ForeColor = Color.White;
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
                    ms.BackColor = PanelColor;
                    ms.ForeColor = TextColor;
                }
                else if (c is StatusStrip)
                {
                    StatusStrip ss = (StatusStrip)c;
                    ss.BackColor = PanelColor;
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
