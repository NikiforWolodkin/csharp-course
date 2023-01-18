using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buttons
{
    public class ZoomEventArgs : EventArgs
    {
        public ZoomEventArgs(int percent) => Percent = percent;

        public int Percent { get; set; }
    }

    public class User
    {
        public event EventHandler<ZoomEventArgs> Zoom;
        public event EventHandler<EventArgs> Click;

        public void RaiseZoom(int percent) => OnZoom(new ZoomEventArgs(percent));
        public void RaiseClick() => OnClick(EventArgs.Empty);

        protected virtual void OnZoom(ZoomEventArgs e)
        {
            EventHandler<ZoomEventArgs> raiseEvent = Zoom;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }

        protected virtual void OnClick(EventArgs e)
        {
            EventHandler<EventArgs> raiseEvent = Click;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }
}
