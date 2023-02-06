using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPoint
{
    public class Publisher
    {
        public EventHandler<EventArgs> Change;

        public void RaiseChange() => OnChange(EventArgs.Empty);

        protected virtual void OnChange(EventArgs e)
        {
            EventHandler<EventArgs> raiseEvent = Change;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }
    }
}
