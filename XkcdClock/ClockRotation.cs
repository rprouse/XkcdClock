using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows.Media;
using XkcdClock.Extensions;

namespace XkcdClock
{
    public class ClockRotation : INotifyPropertyChanged
    {
        private const double SECONDS_IN_DAY = 24 * 60 * 60;
        private const int UPDATE_INTERVAL = 5000;
        private const double RADIUS = 365d;
        private readonly Timer _timer;
        private readonly Brush _dayBrush;
        private readonly Brush _nightBrush;

        public ClockRotation()
        {
            _dayBrush = CreateGradientBrush(Colors.Yellow, Colors.Orange, Colors.Red);
            _nightBrush = CreateGradientBrush(Colors.White, Colors.LightSkyBlue, Colors.SkyBlue);

            // Update the clock every 30 seconds
            _timer = new Timer()
            {
                Interval = UPDATE_INTERVAL,
                AutoReset = true,
                Enabled = true
            };
            _timer.Elapsed += (sender, e) =>
            {
                OnPropertyChanged("InnerRotation");
                OnPropertyChanged("LocalTime");
                OnPropertyChanged("X");
                OnPropertyChanged("Y");
            };
        }

        /// <summary>
        /// Gets the rotation of the world in the center of the diagram based on the time.
        /// </summary>
        public double InnerRotation
        {
            get { return Rotation(DateTime.UtcNow); }
        }

        /// <summary>
        /// The X position of the sun/moon rotating around the clock
        /// </summary>
        public double X
        {
            get
            {
                double rotation = Rotation(DateTime.Now) + 90;    // Midnight at the bottom
                double x = RADIUS * Math.Cos(rotation.ToRadians());
                return x;
            }
        }

        /// <summary>
        /// The Y position of the sun/moon rotating around the clock
        /// </summary>
        public double Y
        {
            get
            {
                double rotation = Rotation(DateTime.Now) + 90;    // Midnight at the bottom
                double y = RADIUS * Math.Sin(rotation.ToRadians());
                return y;
            }
        }

        /// <summary>
        /// Gets the color of the sun/moon.
        /// </summary>
        public Brush SunColor
        {
            get { return IsDay ? _dayBrush : _nightBrush; }
        }

        /// <summary>
        /// Gets the sun/moon symbol.
        /// </summary>
        public string SunSymbol
        {
            get { return IsDay ? "" : ""; }
        }

        /// <summary>
        /// Gets the local time to display in the tooltip.
        /// </summary>
        public string LocalTime
        {
            get { return DateTime.Now.ToShortTimeString(); }
        }

        private bool IsDay
        {
            get
            {
                var now = DateTime.Now;
                return (now.Hour >= 6 && now.Hour <= 18);
            }
        }

        private double Rotation(DateTime date)
        {
            var seconds = new TimeSpan(date.Hour, date.Minute, date.Second).TotalSeconds;
            return seconds / SECONDS_IN_DAY * 360d;
        }

        private Brush CreateGradientBrush(Color start, Color middle, Color end)
        {
            var brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(start, 0.0));
            brush.GradientStops.Add(new GradientStop(middle, 0.5));
            brush.GradientStops.Add(new GradientStop(end, 1.0));
            return brush;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}