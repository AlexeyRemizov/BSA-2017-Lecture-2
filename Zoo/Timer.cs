using System;
using System.Timers;

namespace Zoo
{
    class Timer
    {
        private readonly System.Timers.Timer _internalTimer = new System.Timers.Timer(5000);

        public Timer(EventHandler eventHandler)
        {
            _internalTimer.Elapsed += new ElapsedEventHandler(eventHandler);
            _internalTimer.Enabled = true;
        }
    }
}
