using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttons
{
    public enum State
    {
        Checked,
        Unchecked
    }

    public class Button
    {
        public string Caption { get; set; }
        public int[] StartPoint { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Button(string caption, int startPointX, int startPointY, int width, int height)
        {
            Caption = caption;
            StartPoint = new int[] { startPointX, startPointY };
            Width = width;
            Height = height;
        }

        public void Zoom(int percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new Exception("Incoorect percent value");
            }

            Width = (int)(Width - (Width * percent / 100));
            Height = (int)(Height - (Height * percent / 100));
        }

        public void Subscribe(User user)
        {
            user.Zoom += HandleZoom;
        }

        public void HandleZoom(object sender, ZoomEventArgs e)
        {
            Zoom(e.Percent);
            Console.WriteLine($"{Caption} zoomed");
        }

        public override string ToString()
        {
            return Caption;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Button button)
            {
                if (button.Caption == Caption && button.Width == Width && button.Height == Height)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class CheckButton : Button
    {
        public State State { get; set; }
        
        public CheckButton(string caption, int startPointX, int startPointY, int width, int height)
            : base(caption, startPointX, startPointY, width, height)
        {
            State = State.Unchecked;
        }

        public void Check()
        {
            if (State == State.Unchecked)
            {
                State = State.Checked;
            }
            else
            {
                State = State.Unchecked;
            }
        }

        public void Subscribe(User user)
        {
            user.Click += HandleClick;
        }

        public void HandleClick(object sender, EventArgs e)
        {
            Check();
            Console.WriteLine($"{Caption} clicked");
        }
    }
}
