using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace blizzButton
{
    public class blizzButton : Control
    {
        Image pressedImage,hoverImage,inactiveImage;
        int fontSize = 11;
        bool pressed = false,hovering=false;
        public void SetValues( Image BG, Image Click, Image MouseOver,Image Inactive, int FontSize=11)
        {
            BackgroundImage = new Bitmap(BG,this.Size);
            pressedImage = new Bitmap(Click, this.Size);
            hoverImage = new Bitmap(MouseOver, this.Size);
            inactiveImage = new Bitmap(Inactive, this.Size);
            fontSize = FontSize;
        }
        public Image ActiveImage
        {
            get
            {
                return BackgroundImage;
            }
            set
            {
                this.BackgroundImage = value;
            }
        }
        public Image PressedImage
        {
            get
            {
                return pressedImage;
            }
            set
            {
                this.pressedImage = value;
            }
        }
        public Image InactiveImage
        {
            get
            {
                return inactiveImage;
            }
            set
            {
                this.inactiveImage = value;
            }
        }
        public Image HoverImage
        {
            get
            {
                return hoverImage;
            }
            set
            {
                this.hoverImage = value;
            }
        }
        public int FontSize
        {
            get
            {
                return this.fontSize;
            }
            set
            {
                this.fontSize = value;
            }
        }
        // When the mouse button is pressed, set the "pressed" flag to true 
        // and invalidate the form to cause a repaint.  The .NET Compact Framework 
        // sets the mouse capture automatically.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.pressed = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        // When the mouse is released, reset the "pressed" flag 
        // and invalidate to redraw the button in the unpressed state.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.hovering = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.hovering = false;
            this.Invalidate();
            base.OnMouseEnter(e);
        }
        // Override the OnPaint method to draw the background image and the text.
        protected override void OnPaint(PaintEventArgs e)
        {
            //SetValues(BackgroundImage, pressedImage, hoverImage, inactiveImage, fontSize);
            if (inactiveImage != null && pressedImage != null && BackgroundImage != null && hoverImage != null)
            {
                if (!this.Enabled)
                    e.Graphics.DrawImage(this.inactiveImage, 0, 0);
                else if (this.pressed)
                    e.Graphics.DrawImage(this.pressedImage, 0, 0);
                else if (!this.hovering)
                    e.Graphics.DrawImage(this.BackgroundImage, 0, 0);
                else e.Graphics.DrawImage(this.hoverImage, 0, 0);
            }
            

            // Draw the text if there is any.
            if (this.Text.Length > 0)
            {
                SizeF size = e.Graphics.MeasureString(this.Text, this.Font);
                Rectangle rect1 = new Rectangle(0, 0, this.Width, this.Height);
                // Center the text inside the client area of the PictureButton.
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(this.Text,
                    new Font("Century Gothic", this.fontSize),
                    Brushes.White, rect1, stringFormat);
            }

            // Draw a border around the outside of the 
            // control to look like Pocket PC buttons.
            e.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0,
                this.ClientSize.Width - 1, this.ClientSize.Height - 1);

            base.OnPaint(e);
        }
    }
}