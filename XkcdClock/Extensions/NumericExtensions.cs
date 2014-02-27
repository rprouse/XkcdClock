// /*--------------------------------------------------------------------------------------+
// |
// |     $Source: NumericExtensions.cs $
// |
// |  $Copyright: (c) 2014 Bentley Systems, Incorporated. All rights reserved. $
// |
// +--------------------------------------------------------------------------------------*/

using System;

namespace XkcdClock.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="value">The value to convert in degrees.</param>
        public static double ToRadians( this double value )
        {
            return ( Math.PI/180d )*value;
        }
    }
}