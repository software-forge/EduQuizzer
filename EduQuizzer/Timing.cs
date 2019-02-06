using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuizzer.Timing
{
    public class CountdownTimer
    {
        public Timer Timer { get; private set; }

        public int FullMinutes { get; private set; }

        public int MinutesLeft { get; private set; }
        public int SecondsLeft { get; private set; }

        public event EventHandler <EventArgs> CountdownFinished;
        public event EventHandler <EventArgs> TimerTicked;

        public CountdownTimer(int minutes)
        {
            FullMinutes = minutes;

            MinutesLeft = FullMinutes;
            SecondsLeft = 0;

            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += TimerTick;
        }

        public void Start()
        {
            if(!Timer.Enabled)
            {
                Timer.Start();
            }
        }

        public void Stop()
        {
            if(Timer.Enabled)
            {
                Timer.Stop();
            }
        }

        public void Reset()
        {
            if(Timer.Enabled)
            {
                Timer.Stop();
            }

            MinutesLeft = FullMinutes;
            SecondsLeft = 0;
        }

        public void Reset(int minutes)
        {
            if(Timer.Enabled)
            {
                Timer.Stop();
            }

            FullMinutes = minutes;
            MinutesLeft = FullMinutes;
            SecondsLeft = 0;
        }

        public void TimerTick(object sender, EventArgs e)
        {
            SecondsLeft--;

            if(SecondsLeft < 0)
            {
                SecondsLeft = 59;
                MinutesLeft--;

                if(MinutesLeft < 0)
                {
                    Reset();

                    if (CountdownFinished != null)
                    {
                        CountdownFinished.Invoke(this, new EventArgs());
                    }
                }
            }

            if(TimerTicked != null)
            {
                TimerTicked.Invoke(this, new EventArgs());
            }
        }
    }
}
