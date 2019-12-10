// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CountDown
{
    using System;

    /// <summary>
    /// Class that contains entry point(Main method).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Static Timer object is created here.
        /// </summary>
        public static readonly CountDownTimer Timer = new CountDownTimer();

        private static bool isrunning = true;

        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">
        /// Start arguments.
        /// </param>
        public static void Main(string[] args)
        {
            Timer.SecondTick += DisplayCountDown;
            Timer.Alarm += Alarm;
            Timer.Start(10);
            Console.WriteLine("Timer started. Application will close upon alarm");
            while (isrunning)
            {
            }
        }

        private static void DisplayCountDown(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.Seconds);
        }

        private static void Alarm(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Time's up - exiting");
            Console.Beep();
            isrunning = false;
        }
    }
}
