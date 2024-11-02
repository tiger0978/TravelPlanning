using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;


namespace 旅遊景點規劃
{
    public static class Timer_Service
    {
        public static Timer _timer = null;
        public static Action<object> _callback = null;
        public static String input = "";
        static ContainerControl control = null;

        public static void DebounceTime(this ContainerControl form, Action<object> callback, object state, int dueTime)
       {
             control = form;
            _callback = callback;
            input = state?.ToString();
            if (_timer != null)
            {
                
                _timer.Change(dueTime, -1);
                return;
            }
            _timer = new Timer(TriggerCallback, null, dueTime, -1);

        }
        public static void TriggerCallback(object state)
        {
            control.Invoke((Action)(() => {
                _callback(input);
            }));
        }
    }
}
