using System;

namespace Cave
{
    /// <summary>
    /// Provides an interface for calculating the estimated completion time of a process or task based on its progress.
    /// </summary>
    public interface IEstimation //MakeInternal:KEEP
    {
        /// <summary>
        /// Obtains the time the process was started
        /// </summary>
        DateTime StartTime { get; }

        /// <summary>
        /// Resets the progress, sets <see cref="StartTime"/> to <see cref="DateTime.UtcNow"/> and
        /// begins a new estimation.
        /// </summary>
        void Reset();

        /// <summary>
        /// Obtains the current progress of the process
        /// </summary>
        float Progress { get; }

        /// <summary>
        /// Gets/sets the current progress of the process in percent
        /// </summary>
        float ProgressPercent { get; }

        /// <summary>
        /// Actualizes <see cref="EstimatedCompletionTime"/> by setting the progress
        /// </summary>
        /// <param name="progress">The progress in range [0.0 .. 1.1]</param>
        void Update(float progress);

        /// <summary>
        /// Actualizes <see cref="EstimatedCompletionTime"/> by setting the progress
        /// </summary>
        /// <param name="currentValue">The current value of the progress</param>
        /// <param name="maximum">The maximum value of the progress</param>
        void Update(float currentValue, float maximum);

        /// <summary>
        /// Actualize the <see cref="EstimatedCompletionTime"/> by setting the progress
        /// </summary>
        /// <param name="currentValue">The current value of the progress (0..max)</param>
        /// <param name="offset">The start value of the progress (0..1)</param>
        /// <param name="maximum">The maximum value of the progress</param>
        void Update(float offset, float currentValue, float maximum);

        /// <summary>
        /// Obtains the estimated completion time of the process
        /// </summary>
        DateTime EstimatedCompletionTime { get; }

        /// <summary>
        /// Obtains the estimated time left based on the current time.
        /// </summary>
        TimeSpan EstimatedTimeLeft { get; }

        /// <summary>
        /// Obtains the elapsed time
        /// </summary>
        TimeSpan Elapsed { get; }
    }
}
