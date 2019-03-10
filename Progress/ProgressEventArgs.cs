using System;

namespace Cave.Progress
{
    /// <summary>
    /// Provides the progress instance to use for events.
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressEventArgs"/> class.
        /// </summary>
        /// <param name="progress"></param>
        public ProgressEventArgs(IProgress progress)
        {
            Progress = progress;
        }

        /// <summary>
        /// Gets the progress object implementing the <see cref="IProgress"/> interface.
        /// </summary>
        public IProgress Progress { get; }
    }
}
