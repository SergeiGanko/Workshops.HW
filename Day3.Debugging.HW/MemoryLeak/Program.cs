using System;
using System.Configuration;
using MemoryLeak.Events;
using MemoryLeak.Streams;
using MemoryLeak.UnmanagedResourses;

namespace MemoryLeak
{
    /// <summary>
    /// class Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            #region Memory leak example 1: Streams are not being close

            var source = ConfigurationManager.AppSettings["sourceFilePath"];
            var destination = ConfigurationManager.AppSettings["destinationFilePath"];

            Console.WriteLine($"Copying completed. Total bytes: {StreamExtension.ByByteCopy(source, destination)}\n");

            #endregion

            #region Memory leak example 2: Subscribing to events, and aren't being unsubscribe from event, before calling .Dispose()

            Clock countdown = new Clock(10);
            var falconHeavy = new Rocket(countdown);
            falconHeavy.Subscribe();
            countdown.StartCountdown();
            //falconHeavy.Dispose();

            #endregion

            #region Memory leak example 3: Allocating unmanaged resources and not freeing them after

            var pointer = WorkWithBitmap.GetHbitmapDemo("image.jpg");
            //WorkWithBitmap.DeleteObject(pointer);

            #endregion

            Console.ReadLine();
        }
    }
}
