// /*--------------------------------------------------------------------------------------+
// |
// |     $Source: ClockRotation.cs $
// |
// |  $Copyright: (c) 2014 Bentley Systems, Incorporated. All rights reserved. $
// |
// +--------------------------------------------------------------------------------------*/

using System;

namespace XkcdClock
{
    public class ClockRotation
    {
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
    }
}