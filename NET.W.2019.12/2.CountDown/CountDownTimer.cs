// <copyright file="CountDownTimer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CountDown
{
    using System;
    using System.Timers;

    /// <summary>
    /// CountDown class.
    /// </summary>
    public class CountDownTimer
    {
        private System.Timers.Timer timer;
        private int alarmPeriod = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountDownTimer"/> class.
        /// </summary>
        public CountDownTimer()
        {
            this.SecondsLeft = 0;
            this.SecondTick += this.SecondsCounter;
        }

        /// <summary>
        /// Delegate that handles timer events
        /// </summary>
        /// <param name="sender">
        /// Object that raised the event.
        /// </param>
        /// <param name="e">
        /// Event data.
        /// </param>
        public delegate void SecondTickEventHandler(object sender, TimerEventArgs e);

        /// <summary>
        /// Event that occurs every second.
        /// </summary>
        public event SecondTickEventHandler SecondTick;

        /// <summary>
        /// Event that occurs after given amount of seconds.
        /// </summary>
        public event SecondTickEventHandler Alarm;

        /// <summary>
        /// Gets the amount of seconds until Alarm event occurs.
        /// </summary>
        public int SecondsLeft { get; private set; }

        /// <summary>
        /// External method that starts the countdown timer.
        /// </summary>
        /// <param name="seconds">
        /// Seconds until the alarm.
        /// </param>
        public void Start(int seconds)
        {
            if (this.timer == null)
            {
                this.SecondsLeft = seconds;
                this.alarmPeriod = seconds;
                this.TimerOneSecondStart();
            }
            else
            {
                throw new Exception(message: "Timer is already running");
            }
        }

        private void TimerOneSecondStart()
        {
            this.timer = new System.Timers.Timer(1000);
            this.timer.Elapsed += this.OnTimerElapsedEvent;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        private void OnTimerElapsedEvent(object source, ElapsedEventArgs e)
        {
            this.SecondTick?.Invoke(this, new TimerEventArgs(this.SecondsLeft));
        }

        private void SecondsCounter(object sender, TimerEventArgs e)
        {
            if (e.Seconds > 0)
            {
                this.SecondsLeft--;
            }
            else
            {
                this.timer.Stop();
                this.timer.Enabled = false;
                this.timer.Dispose();
                this.Alarm?.Invoke(this, new TimerEventArgs(this.alarmPeriod));
            }
        }
    }
}
