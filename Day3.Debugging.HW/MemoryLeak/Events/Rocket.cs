using System;

namespace MemoryLeak.Events
{
    /// <summary>
    /// Class Rocket
    /// </summary>
    public class Rocket : IDisposable
    {
        private readonly Clock _countdown;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rocket"/> class.
        /// </summary>
        /// <param name="countdown">The countdown.</param>
        public Rocket(Clock countdown)
        {
            _countdown = countdown;
        }

        /// <summary>
        /// Subscribes the specified clock.
        /// </summary>
        /// <param name="clock">The clock.</param>
        public void Subscribe() => _countdown.TimeExpired += CommandReceived;

        /// <summary>
        /// Commands the received.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeExpiredEventArgs"/> instance containing the event data.</param>
        public void CommandReceived(object sender, TimeExpiredEventArgs e)
        {
            Console.WriteLine(e.Message + " Rokcket launched!");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _countdown.TimeExpired -= CommandReceived;
        }
    }
}
