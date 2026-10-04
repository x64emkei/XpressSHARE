using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XpressShare.Core
{
    public static class IconHelper
    {
        public static Bitmap CreateSendIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float p = size * 0.15f;
                    PointF[] pts = new PointF[]
                    {
                        new PointF(p, p),
                        new PointF(size - p, size * 0.5f),
                        new PointF(p, size - p),
                        new PointF(size * 0.45f, size * 0.5f),
                        new PointF(p, p)
                    };
                    g.DrawPolygon(pen, pts);
                    g.DrawLine(pen, size * 0.45f, size * 0.5f, size - p, size * 0.5f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateFolderIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float x = size * 0.12f;
                    float y = size * 0.22f;
                    float w = size * 0.76f;
                    float h = size * 0.56f;

                    GraphicsPath path = new GraphicsPath();
                    path.AddLine(x, y + 4, x, y + h);
                    path.AddLine(x, y + h, x + w, y + h);
                    path.AddLine(x + w, y + h, x + w, y + 6);
                    path.AddLine(x + w, y + 6, x + w * 0.55f, y + 6);
                    path.AddLine(x + w * 0.55f, y + 6, x + w * 0.45f, y);
                    path.AddLine(x + w * 0.45f, y, x + 4, y);
                    path.AddLine(x + 4, y, x, y + 4);
                    path.CloseFigure();

                    g.DrawPath(pen, path);
                }
            }
            return bmp;
        }

        public static Bitmap CreateDeviceIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float x = size * 0.15f;
                    float y = size * 0.18f;
                    float w = size * 0.70f;
                    float h = size * 0.48f;

                    // Monitor frame
                    g.DrawRectangle(pen, x, y, w, h);
                    // Stand
                    g.DrawLine(pen, size * 0.5f, y + h, size * 0.5f, size * 0.78f);
                    g.DrawLine(pen, size * 0.35f, size * 0.78f, size * 0.65f, size * 0.78f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateCheckIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(2.0f, size / 10f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    PointF[] pts = new PointF[]
                    {
                        new PointF(size * 0.22f, size * 0.52f),
                        new PointF(size * 0.42f, size * 0.72f),
                        new PointF(size * 0.78f, size * 0.28f)
                    };
                    g.DrawLines(pen, pts);
                }
            }
            return bmp;
        }

        public static Bitmap CreateCrossIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(2.0f, size / 10f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;

                    float p = size * 0.28f;
                    g.DrawLine(pen, p, p, size - p, size - p);
                    g.DrawLine(pen, size - p, p, p, size - p);
                }
            }
            return bmp;
        }

        public static Bitmap CreateGearIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    float cx = size * 0.5f;
                    float cy = size * 0.5f;
                    float rOuter = size * 0.35f;
                    float rInner = size * 0.16f;

                    // Inner circle
                    g.DrawEllipse(pen, cx - rInner, cy - rInner, rInner * 2, rInner * 2);

                    // Outer cogs
                    for (int i = 0; i < 8; i++)
                    {
                        double angle = i * Math.PI / 4.0;
                        float x1 = cx + (float)(Math.Cos(angle) * (rOuter - 2));
                        float y1 = cy + (float)(Math.Sin(angle) * (rOuter - 2));
                        float x2 = cx + (float)(Math.Cos(angle) * (rOuter + 3));
                        float y2 = cy + (float)(Math.Sin(angle) * (rOuter + 3));
                        g.DrawLine(pen, x1, y1, x2, y2);
                    }
                    g.DrawEllipse(pen, cx - (rOuter - 2), cy - (rOuter - 2), (rOuter - 2) * 2, (rOuter - 2) * 2);
                }
            }
            return bmp;
        }

        public static Bitmap CreateInboxIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float x = size * 0.15f;
                    float y = size * 0.40f;
                    float w = size * 0.70f;
                    float h = size * 0.45f;

                    // Tray
                    PointF[] tray = new PointF[]
                    {
                        new PointF(x, y),
                        new PointF(x, y + h),
                        new PointF(x + w, y + h),
                        new PointF(x + w, y),
                        new PointF(x + w * 0.70f, y),
                        new PointF(x + w * 0.60f, y + h * 0.35f),
                        new PointF(x + w * 0.40f, y + h * 0.35f),
                        new PointF(x + w * 0.30f, y),
                        new PointF(x, y)
                    };
                    g.DrawLines(pen, tray);

                    // Downward arrow
                    g.DrawLine(pen, size * 0.5f, size * 0.15f, size * 0.5f, size * 0.50f);
                    g.DrawLine(pen, size * 0.35f, size * 0.38f, size * 0.5f, size * 0.52f);
                    g.DrawLine(pen, size * 0.65f, size * 0.38f, size * 0.5f, size * 0.52f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateUserIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;

                    float cx = size * 0.5f;
                    float headR = size * 0.20f;
                    g.DrawEllipse(pen, cx - headR, size * 0.18f, headR * 2, headR * 2);

                    // Shoulders arc
                    g.DrawArc(pen, size * 0.18f, size * 0.54f, size * 0.64f, size * 0.50f, 180, 180);
                }
            }
            return bmp;
        }

        public static Bitmap CreateHomeIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float p = size * 0.15f;
                    PointF[] roof = new PointF[]
                    {
                        new PointF(p, size * 0.45f),
                        new PointF(size * 0.5f, p),
                        new PointF(size - p, size * 0.45f)
                    };
                    g.DrawLines(pen, roof);

                    float bx = size * 0.22f;
                    float bw = size * 0.56f;
                    float by = size * 0.45f;
                    float bh = size * 0.42f;
                    g.DrawRectangle(pen, bx, by, bw, bh);

                    // Door
                    float dw = size * 0.20f;
                    float dh = size * 0.24f;
                    g.DrawRectangle(pen, size * 0.5f - dw / 2, by + bh - dh, dw, dh);
                }
            }
            return bmp;
        }

        public static Bitmap CreateTransferIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    // Top arrow pointing right
                    float y1 = size * 0.35f;
                    g.DrawLine(pen, size * 0.18f, y1, size * 0.82f, y1);
                    g.DrawLine(pen, size * 0.62f, y1 - size * 0.15f, size * 0.82f, y1);
                    g.DrawLine(pen, size * 0.62f, y1 + size * 0.15f, size * 0.82f, y1);

                    // Bottom arrow pointing left
                    float y2 = size * 0.65f;
                    g.DrawLine(pen, size * 0.82f, y2, size * 0.18f, y2);
                    g.DrawLine(pen, size * 0.38f, y2 - size * 0.15f, size * 0.18f, y2);
                    g.DrawLine(pen, size * 0.38f, y2 + size * 0.15f, size * 0.18f, y2);
                }
            }
            return bmp;
        }

        public static Bitmap CreateLightningIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    PointF[] bolt = new PointF[]
                    {
                        new PointF(size * 0.55f, size * 0.15f),
                        new PointF(size * 0.28f, size * 0.52f),
                        new PointF(size * 0.50f, size * 0.52f),
                        new PointF(size * 0.42f, size * 0.85f),
                        new PointF(size * 0.72f, size * 0.44f),
                        new PointF(size * 0.50f, size * 0.44f),
                        new PointF(size * 0.55f, size * 0.15f)
                    };
                    g.DrawPolygon(pen, bolt);
                }
            }
            return bmp;
        }

        public static Bitmap CreateCameraIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float x = size * 0.15f;
                    float y = size * 0.30f;
                    float w = size * 0.70f;
                    float h = size * 0.52f;

                    // Body
                    g.DrawRectangle(pen, x, y, w, h);

                    // Flash / top bump
                    g.DrawLine(pen, size * 0.35f, y, size * 0.40f, y - size * 0.10f);
                    g.DrawLine(pen, size * 0.40f, y - size * 0.10f, size * 0.60f, y - size * 0.10f);
                    g.DrawLine(pen, size * 0.60f, y - size * 0.10f, size * 0.65f, y);

                    // Lens
                    float lr = size * 0.16f;
                    g.DrawEllipse(pen, size * 0.5f - lr, y + h * 0.5f - lr, lr * 2, lr * 2);
                }
            }
            return bmp;
        }

        public static Bitmap CreateClipboardIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float x = size * 0.22f;
                    float y = size * 0.25f;
                    float w = size * 0.56f;
                    float h = size * 0.62f;

                    // Board
                    g.DrawRectangle(pen, x, y, w, h);

                    // Clip on top
                    float cw = size * 0.28f;
                    float ch = size * 0.14f;
                    g.DrawRectangle(pen, size * 0.5f - cw / 2, size * 0.15f, cw, ch);

                    // Document lines
                    g.DrawLine(pen, x + 4, y + size * 0.20f, x + w - 4, y + size * 0.20f);
                    g.DrawLine(pen, x + 4, y + size * 0.35f, x + w - 4, y + size * 0.35f);
                }
            }
            return bmp;
        }

        public static Bitmap CreateDocumentIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                using (Pen pen = new Pen(color, Math.Max(1.5f, size / 14f)))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    float x = size * 0.22f;
                    float y = size * 0.15f;
                    float w = size * 0.56f;
                    float h = size * 0.70f;
                    float fold = size * 0.18f;

                    PointF[] doc = new PointF[]
                    {
                        new PointF(x, y),
                        new PointF(x + w - fold, y),
                        new PointF(x + w, y + fold),
                        new PointF(x + w, y + h),
                        new PointF(x, y + h),
                        new PointF(x, y)
                    };
                    g.DrawPolygon(pen, doc);
                    g.DrawLine(pen, x + w - fold, y, x + w - fold, y + fold);
                    g.DrawLine(pen, x + w - fold, y + fold, x + w, y + fold);
                }
            }
            return bmp;
        }

        public static Bitmap CreateCircleIcon(Color color, int size, bool filled)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ConfigureGraphics(g);
                float pad = Math.Max(1.5f, size * 0.15f);
                float r = size - pad * 2;
                if (filled)
                {
                    using (Brush br = new SolidBrush(color))
                    {
                        g.FillEllipse(br, pad, pad, r, r);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(color, Math.Max(1.5f, size / 12f)))
                    {
                        g.DrawEllipse(pen, pad, pad, r, r);
                    }
                }
            }
            return bmp;
        }

        // Convenient alias overloads
        public static Bitmap GetSendIcon(int size, Color color) { return CreateSendIcon(color, size); }
        public static Bitmap GetFolderIcon(int size, Color color) { return CreateFolderIcon(color, size); }
        public static Bitmap GetDeviceIcon(int size, Color color) { return CreateDeviceIcon(color, size); }
        public static Bitmap GetCheckIcon(int size, Color color) { return CreateCheckIcon(color, size); }
        public static Bitmap GetCrossIcon(int size, Color color) { return CreateCrossIcon(color, size); }
        public static Bitmap GetGearIcon(int size, Color color) { return CreateGearIcon(color, size); }
        public static Bitmap GetInboxIcon(int size, Color color) { return CreateInboxIcon(color, size); }
        public static Bitmap GetUserIcon(int size, Color color) { return CreateUserIcon(color, size); }
        public static Bitmap GetHomeIcon(int size, Color color) { return CreateHomeIcon(color, size); }
        public static Bitmap GetTransferIcon(int size, Color color) { return CreateTransferIcon(color, size); }
        public static Bitmap GetLightningIcon(int size, Color color) { return CreateLightningIcon(color, size); }
        public static Bitmap GetCameraIcon(int size, Color color) { return CreateCameraIcon(color, size); }
        public static Bitmap GetClipboardIcon(int size, Color color) { return CreateClipboardIcon(color, size); }
        public static Bitmap GetDocumentIcon(int size, Color color) { return CreateDocumentIcon(color, size); }
        public static Bitmap GetCircleIcon(int size, Color color, bool filled) { return CreateCircleIcon(color, size, filled); }

        private static void ConfigureGraphics(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(Color.Transparent);
        }
    }
}
