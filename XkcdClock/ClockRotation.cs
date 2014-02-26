using System;
using System.ComponentModel;
using System.Timers;

namespace XkcdClock
{
    public class ClockRotation : INotifyPropertyChanged
    {
        private readonly Timer _timer;

        public ClockRotation()
        {
            // Update the clock every 30 seconds
            _timer = new Timer()
            {
                Interval = 30000,
                AutoReset = true,
                Enabled = true
            };
            _timer.Elapsed += (sender, e) => OnPropertyChanged( "InnerRotation" );
        }

        /// <summary>
        /// Gets the rotation of the world in the center of the diagram based on the time.
        /// </summary>
        public double InnerRotation
        {
            get { return Rotation(); } 
        }

        private const double SECONDS_IN_DAY = 24*60*60;

        private double Rotation()
        {
            var date = DateTime.UtcNow;
            var seconds = new TimeSpan( date.Hour, date.Minute, date.Second ).TotalSeconds;
            return seconds/SECONDS_IN_DAY*360d;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if ( handler != null ) handler( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}