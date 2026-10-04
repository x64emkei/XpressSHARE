using System;
using System.Reflection;
using System.Windows.Forms;

namespace XpressShare.Controls
{
    /// <summary>
    /// Flicker-free double-buffered panel container for .NET Framework 3.5 Windows Forms.
    /// Eliminates white flashes, repainting artifacts, and visual blinking during layouts.
    /// </summary>
    public class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Enables the protected DoubleBuffered property on any WinForms control (ListView, DataGridView, SplitContainer, etc.)
        /// </summary>
        public static void EnableDoubleBuffering(Control control)
        {
            if (control == null) return;
            try
            {
                PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                if (pi != null)
                {
                    pi.SetValue(control, true, null);
                }
            }
            catch { }
        }
    }
}
