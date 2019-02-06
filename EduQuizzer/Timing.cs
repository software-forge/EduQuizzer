using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuizzer.Timing
{
    // Argumenty zdarzenia końca odliczania
    public class TimeSettingChangedEventArgs : EventArgs
    {

    }

    // struktura czy klasa?
    public struct TimeSetting
    {
        public int hours;
        public int minutes;
    }

    // Ta klasa wykonuje odliczanie i wywołuje zdarzenie
    public class CountdownTimer
    {
        private Timer Timer { get; set; }

        public CountdownTimer()
        {

        }
    }

    // Panel nastawiania czasu
    public class TimePicker : Panel
    {
        public NumericUpDown HoursUpDown { get; set; }
        public NumericUpDown MinutesUpDown { get; set; }

        public event EventHandler<TimeSettingChangedEventArgs> TimeSettingChanged;
        public delegate void TimeSettingChangedDelegate(object sender, TimeSettingChangedEventArgs e);

        public TimePicker()
        {
            HoursUpDown = new NumericUpDown();
            HoursUpDown.Minimum = 0;
            HoursUpDown.Maximum = 5;
            HoursUpDown.Increment = 1;

            MinutesUpDown = new NumericUpDown();
            MinutesUpDown.Minimum = 0;
            MinutesUpDown.Maximum = 55;
            MinutesUpDown.Increment = 5;

            HoursUpDown.ValueChanged += HoursChanged;
            MinutesUpDown.ValueChanged += MinutesChanged;
        }

        public void HoursChanged(object sender, EventArgs e)
        {

        }

        public void MinutesChanged(object sender, EventArgs e)
        {

        }
    }
}
