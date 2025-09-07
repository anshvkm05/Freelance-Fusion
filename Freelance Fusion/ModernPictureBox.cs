using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomControls
{
    /// <summary>
    /// Defines when the shadow effect is visible.
    /// </summary>
    public enum ShadowMode
    {
        None,
        OnHover,
        Always
    }

    public class ModernPictureBox : PictureBox
    {
        //- Fields for state and animation
        private bool _isHovering = false;
        private Timer _animationTimer = new Timer();

        //- Fields for storing animation progress
        private int _hoverAlpha = 0;

        #region Appearance Properties

        [Category("Appearance")]
        [Description("The radius for the picture box's corners.")]
        public int CornerRadius { get; set; } = 10;

        [Category("Appearance")]
        [Description("The size of the picture box's border.")]
        public int BorderSize { get; set; } = 0;

        [Category("Appearance")]
        [Description("The color of the picture box's border.")]
        public Color BorderColor { get; set; } = Color.DodgerBlue;

        #endregion

        #region Hover Properties

        [Category("Hover")]
        [Description("Enables a colored overlay effect when the mouse is hovering.")]
        public bool EnableHoverOverlay { get; set; } = true;

        [Category("Hover")]
        [Description("The color of the overlay that appears on hover.")]
        public Color HoverOverlayColor { get; set; } = Color.FromArgb(80, 0, 0, 0);

        #endregion

        #region Shadow Properties

        [Category("Appearance")]
        [Description("Determines when the shadow is visible.")]
        public ShadowMode ShadowStyle { get; set; } = ShadowMode.OnHover;

        [Category("Appearance")]
        [Description("The color of the hover shadow.")]
        public Color ShadowColor { get; set; } = Color.FromArgb(60, 0, 0, 0);

        [Category("Appearance")]
        [Description("The offset of the shadow from the control.")]
        public Point ShadowOffset { get; set; } = new Point(3, 3);

        #endregion

        public ModernPictureBox()
        {
            //- Set default properties and styles
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            SizeMode = PictureBoxSizeMode.StretchImage; // Default to a useful size mode
            BackColor = Color.Transparent;

            //- Configure the animation timer
            _animationTimer.Interval = 15; // Approx 60 FPS
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        /// <summary>
        /// Handles the animation timer tick to create smooth transitions.
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

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
                else
                {
                    _animationTimer.Stop(); // Stop timer when not needed
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
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the rectangle for the image itself, leaving space for the shadow
            Rectangle imageRect = Rectangle.Empty;
            if (ShadowStyle != ShadowMode.None)
            {
                // Make the image rectangle smaller to accommodate the shadow
                imageRect = new Rectangle(0, 0, Width - ShadowOffset.X - 1, Height - ShadowOffset.Y - 1);
            }
            else
            {
                // Use the full control area if shadow is disabled
                imageRect = new Rectangle(0, 0, Width - 1, Height - 1);
            }

            //-- Determine if and how to draw the shadow
            bool shouldDrawShadow = false;
            int shadowAlpha = 0;

            switch (ShadowStyle)
            {
                case ShadowMode.OnHover:
                    if (_hoverAlpha > 0 && !this.DesignMode)
                    {
                        shouldDrawShadow = true;
                        shadowAlpha = (_hoverAlpha * ShadowColor.A) / 255;
                    }
                    break;
                case ShadowMode.Always:
                    shouldDrawShadow = true;
                    shadowAlpha = ShadowColor.A;
                    break;
            }

            //-- Draw shadow if applicable
            if (shouldDrawShadow)
            {
                var shadowRect = imageRect;
                shadowRect.Offset(ShadowOffset); // Offset the rectangle for the shadow

                using (GraphicsPath shadowPath = GetRoundedRectPath(shadowRect, CornerRadius))
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(shadowAlpha, ShadowColor)))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }
            }

            //-- Draw the image with rounded corners
            using (GraphicsPath imagePath = GetRoundedRectPath(imageRect, CornerRadius))
            {
                // Use the path as a clipping region to draw the image
                g.SetClip(imagePath, CombineMode.Replace);

                // Draw the base image
                if (Image != null)
                {
                    // Use ClientRectangle to ensure the image fills the entire control area before being clipped
                    g.DrawImage(Image, ClientRectangle);
                }
                else
                {
                    // Draw a placeholder if no image is set
                    using (SolidBrush placeholderBrush = new SolidBrush(Color.Gainsboro))
                    {
                        g.FillRectangle(placeholderBrush, ClientRectangle);
                    }
                }

                g.ResetClip(); // Reset clip for subsequent drawing operations

                //-- Draw border over the clipped image
                if (BorderSize > 0)
                {
                    using (Pen borderPen = new Pen(BorderColor, BorderSize))
                    {
                        // Set alignment to inset to draw the border inside the path
                        borderPen.Alignment = PenAlignment.Inset;
                        g.DrawPath(borderPen, imagePath);
                    }
                }
            }

            //-- Draw hover overlay if enabled
            if (EnableHoverOverlay && _hoverAlpha > 0 && !this.DesignMode)
            {
                using (GraphicsPath imagePath = GetRoundedRectPath(imageRect, CornerRadius))
                using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb((_hoverAlpha * HoverOverlayColor.A) / 255, HoverOverlayColor)))
                {
                    g.FillPath(overlayBrush, imagePath);
                }
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
            // The timer continues to run to animate the fade-out
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _animationTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

