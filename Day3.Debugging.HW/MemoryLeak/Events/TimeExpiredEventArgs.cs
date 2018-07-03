using System;

namespace MemoryLeak
{
    /// <summary>
    /// Class contains TimeExpired event info
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TimeExpiredEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeExpiredEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">Throws when message is null or empty or whitespace</exception>
        public TimeExpiredEventArgs(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"Invalid argument {nameof(message)}");
            }
            this.Message = message;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }
    }
}