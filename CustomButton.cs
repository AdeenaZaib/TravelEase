﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Components
{
    public class CustomButton : Button
    {
        //FIELDS
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;

        [Category("CustomControls")]
        public int BorderSize { get => borderSize; set {
                borderSize = value; this.Invalidate(); } }
        [Category("CustomControls")]
        public int BorderRadius { get => borderRadius;
            set {
                if (value <= this.Height)
                {
                    borderRadius = value;
                }
                else
                {
                    borderRadius = this.Height;
                }

                this.Invalidate();
            }
        }
        [Category("CustomControls")]
        public Color BorderColor { get => borderColor; set { borderColor = value;this.Invalidate(); } }


        //  CONSTRUCTOR
        public CustomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150,40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        //  METHODS
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //  BUTTON SURFACE
                    this.Region = new Region(pathSurface);
                    //  DRAW SURFACE BORDER FOR HD RESULT
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //  BUTTON BORDER
                    if (borderSize >= 1)
                        //  DRAW CONTROL BORDER
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else // NORMAL BUTTON
            {
                this.Region = new Region(rectSurface);
                if (borderSize >=1 )
                {
                     using(Pen penBorder = new Pen(borderColor, borderSize))
                     {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                     }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
            }
        }
    }

    
}
