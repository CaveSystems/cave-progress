using System;

namespace Cave.Progress
{
    /// <summary>
    /// Provides the progress instance to use for events.
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ProgressEventArgs"/> class
        /// </summary>
        /// <param name="progress"></param>
        public ProgressEventArgs(IProgress progress)
        {
            Progress = progress;
        }

        /// <summary>
        /// Progress object implementing the <see cref="IProgress"/> interface
        /// </summary>
        public IProgress Progress { get; }
    }
}