using System;
using System.IO;

namespace MemoryLeak.Streams
{
    /// <summary>
    /// class StreamsExtension
    /// </summary>
    public static class StreamExtension
    {
        #region Memory leak example 1: Streams are not being close

        /// <summary>
        /// Copies the content of file to another file
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <param name="destinationPath">The destination file path.</param>
        /// <returns>Returns copied bytes quantity</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            ValidateInput(sourcePath, destinationPath);

            int writtenBytes = 0;

            // Streams are not being close therefore memory leak. 
            FileStream readStream = File.OpenRead(sourcePath);
            FileStream writeStream = File.Create(destinationPath);
            readStream.CopyTo(writeStream);
            writtenBytes = (int)writeStream.Length;

            return writtenBytes;
        }

        /// <summary>
        /// The input validation method.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <exception cref="ArgumentException">Throws when sourcePath or destinationPath is invalid</exception>
        /// <exception cref="FileNotFoundException">Throws when file is not found</exception>
        private static void ValidateInput(string sourcePath, string destinationPath)
        {
            if (!IsValidFileName(sourcePath))
            {
                throw new ArgumentException($"String path ({nameof(sourcePath)}) is empty, null or whitespace.");
            }

            if (!IsValidFileName(destinationPath))
            {
                throw new ArgumentException($"String path ({nameof(destinationPath)}) is empty, null or whitespace.");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File {nameof(sourcePath)} not found");
            }
        }

        /// <summary>
        /// Defines the correctness of the incoming file path
        /// </summary>
        /// <param name="name">The string name.</param>
        /// <returns>
        ///   <c>true</c> if file path is correct string; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValidFileName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0
                                                    && !Path.GetFullPath(name).StartsWith(@"\\.\");
        }

        #endregion
    }
}