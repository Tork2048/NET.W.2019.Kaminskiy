// <copyright file="TimerEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CountDown
{
    /// <summary>
    /// Data class for Timer events.
    /// </summary>
    public class TimerEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="seconds">
        /// Amount of seconds.
        /// </param>
        public TimerEventArgs(int seconds)
        {
            this.Seconds = seconds;
        }

        /// <summary>
        /// Gets the amount of seconds.
        /// </summary>
        public int Seconds { get; private set; }
    }
}
