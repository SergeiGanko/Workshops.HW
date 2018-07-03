using System;
using System.Threading;

namespace MemoryLeak
{
    /// <summary>
    /// Class Clock
    /// </summary>
    public sealed class Clock
    {
        private readonly int seconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clock"/> class.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        /// <exception cref="ArgumentException">Throw when seconds below zero</exception>
        public Clock(int seconds)
        {
            if (seconds < 0)
            {
                throw new ArgumentException($"Invalid argument {nameof(seconds)}");
            }

            this.seconds = seconds;
        }

        /// <summary>
        /// Occurs when time expired.
        /// </summary>
        public event EventHandler<TimeExpiredEventArgs> TimeExpired = delegate { };

        /// <summary>
        /// Starts the countdown.
        /// </summary>
        public void StartCountdown()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(this.seconds);
            do
            {
                timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            while (timeSpan != TimeSpan.Zero);

            if (timeSpan == TimeSpan.Zero)
            {
                OnTimeExpired(this, new TimeExpiredEventArgs($"{this.seconds} seconds is over!"));
            }
        }

        /// <summary>
        /// Called when time expired.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeExpiredEventArgs"/> instance containing the event data.</param>
        private void OnTimeExpired(object sender, TimeExpiredEventArgs e)
        {
            EventHandler<TimeExpiredEventArgs> tempHandler = TimeExpired;
            tempHandler?.Invoke(sender, e);
        }
    }
}