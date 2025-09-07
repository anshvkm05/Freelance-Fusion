using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomControls
{
    public class ModernButton : Control
    {
        //- Fields for state and animation
        private StringFormat _stringFormat = new StringFormat();
        private bool _isHovering = false;
        private bool _isPressing = false;
        private Timer _animationTimer = new Timer();

        //- Fields for storing animation progress and colors
        private int _hoverAlpha = 0;

        #region Appearance Properties

        [Category("Appearance")]
        [Description("The radius for the button's corners.")]
        public int CornerRadius { get; set; } = 10;

        [Category("Appearance")]
        [Description("The background color of the button.")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public override Color BackColor { get; set; }

        [Category("Appearance")]
        [Description("The text color of the button.")]
        [DefaultValue(typeof(Color), "White")]
        public override Color ForeColor { get; set; }

        #endregion

        #region Hover Properties

        [Category("Hover")]
        [Description("The background color of the button when the mouse is hovering over it.")]
        public Color HoverBackColor { get; set; } = Color.RoyalBlue;

        [Category("Hover")]
        [Description("The text color of the button when the mouse is hovering over it.")]
        public Color HoverForeColor { get; set; } = Color.White;

        [Category("Hover")]
        [Description("Enables a shadow effect when the mouse is hovering over the button.")]
        public bool EnableHoverShadow { get; set; } = true;

        [Category("Hover")]
        [Description("The color of the hover shadow.")]
        public Color ShadowColor { get; set; } = Color.FromArgb(60, 0, 0, 0);

        [Category("Hover")]
        [Description("The offset of the shadow from the button.")]
        public Point ShadowOffset { get; set; } = new Point(2, 2);

        #endregion

        #region Click Properties

        [Category("Click")]
        [Description("The background color of the button when it is being clicked.")]
        public Color ClickBackColor { get; set; } = Color.CornflowerBlue;

        [Category("Click")]
        [Description("The text color of the button when it is being clicked.")]
        public Color ClickForeColor { get; set; } = Color.White;

        #endregion

        #region Border Properties

        [Category("Appearance")]
        [Description("The size of the button's border.")]
        public int BorderSize { get; set; } = 0;

        [Category("Appearance")]
        [Description("The color of the button's border.")]
        public Color BorderColor { get; set; } = Color.DarkGray;

        [Category("Hover")]
        [Description("The border color of the button when the mouse is hovering over it.")]
        public Color HoverBorderColor { get; set; } = Color.FromArgb(105, 105, 105);

        [Category("Click")]
        [Description("The border color of the button when it is being clicked.")]
        public Color ClickBorderColor { get; set; } = Color.FromArgb(105, 105, 105);

        #endregion

        public ModernButton()
        {
            //- Set default properties and styles
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(150, 40);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BackColor = Color.DodgerBlue;
            ForeColor = Color.White;

            //- Center the text
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;

            //- Configure the animation timer
            _animationTimer.Interval = 15; // Approx 60 FPS
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        /// <summary>
        /// Handles the animation timer tick to create smooth color transitions.
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_isHovering)
            {
                if (_hoverAlpha < 255)
                {
                    _hoverAlpha += 15;
                    if (_hoverAlpha > 255) _hoverAlpha = 255;
                    Invalidate();
                }
            }
            else
            {
                if (_hoverAlpha > 0)
                {
                    _hoverAlpha -= 15;
                    if (_hoverAlpha < 0) _hoverAlpha = 0;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Creates a GraphicsPath for a rectangle with rounded corners.
        /// </summary>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            // top left arc
            path.AddArc(arcRect, 180, 90);
            // top right arc
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            // bottom right arc
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            // bottom left arc
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the rectangle for the button itself, leaving space for the shadow
            Rectangle buttonRect = Rectangle.Empty;
            if (EnableHoverShadow)
            {
                // Make the button rectangle smaller to accommodate the shadow
                buttonRect = new Rectangle(0, 0, Width - ShadowOffset.X - 1, Height - ShadowOffset.Y - 1);
            }
            else
            {
                // Use the full control area if shadow is disabled
                buttonRect = new Rectangle(0, 0, Width - 1, Height - 1);
            }

            //-- Determine current colors based on state
            Color backColor;
            Color foreColor;
            Color borderColor;

            if (_isPressing)
            {
                backColor = ClickBackColor;
                foreColor = ClickForeColor;
                borderColor = ClickBorderColor;
            }
            else
            {
                //-- Interpolate colors for hover animation
                backColor = InterpolateColor(BackColor, HoverBackColor, _hoverAlpha);
                foreColor = InterpolateColor(ForeColor, HoverForeColor, _hoverAlpha);
                borderColor = InterpolateColor(BorderColor, HoverBorderColor, _hoverAlpha);
            }

            //-- Draw shadow if enabled and hovering
            if (EnableHoverShadow && _isHovering && _hoverAlpha > 0)
            {
                var shadowRect = buttonRect;
                shadowRect.Offset(ShadowOffset); // Offset the rectangle for the shadow

                using (GraphicsPath shadowPath = GetRoundedRectPath(shadowRect, CornerRadius))
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb((_hoverAlpha * ShadowColor.A) / 255, ShadowColor.R, ShadowColor.G, ShadowColor.B)))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }
            }

            //-- Draw the button body and border
            using (GraphicsPath path = GetRoundedRectPath(buttonRect, CornerRadius))
            {
                // Draw background
                using (Brush backBrush = new SolidBrush(backColor))
                {
                    g.FillPath(backBrush, path);
                }

                // Draw border
                if (BorderSize > 0)
                {
                    using (Pen borderPen = new Pen(borderColor, BorderSize))
                    {
                        // Set alignment to inset to draw the border inside the path
                        borderPen.Alignment = PenAlignment.Inset;
                        g.DrawPath(borderPen, path);
                    }
                }
            }

            //-- Draw the button text
            using (Brush foreBrush = new SolidBrush(foreColor))
            {
                g.DrawString(Text, Font, foreBrush, ClientRectangle, _stringFormat);
            }
        }

        #region Mouse Event Overrides

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovering = true;
            _animationTimer.Start();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovering = false;
            // The timer continues to run to animate the color back to normal
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isPressing = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isPressing = false;
            Invalidate();
        }

        #endregion

        /// <summary>
        /// Linearly interpolates between two colors.
        /// </summary>
        private Color InterpolateColor(Color color1, Color color2, int alpha)
        {
            int r = color1.R + (alpha * (color2.R - color1.R)) / 255;
            int g = color1.G + (alpha * (color2.G - color1.G)) / 255;
            int b = color1.B + (alpha * (color2.B - color1.B)) / 255;
            int a = color1.A + (alpha * (color2.A - color1.A)) / 255;
            return Color.FromArgb(a, r, g, b);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stringFormat?.Dispose();
                _animationTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


