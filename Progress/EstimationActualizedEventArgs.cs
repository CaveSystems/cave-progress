using System;

namespace Cave
{
    /// <summary>
    /// Provides an event for <see cref="IEstimation"/> classes to notify about actualizations.
    /// </summary>
    public sealed class EstimationActualizedEventArgs : EventArgs // MakeInternal:KEEP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimationActualizedEventArgs"/> class.
        /// </summary>
        public EstimationActualizedEventArgs(DateTime estimatedEndTime)
        {
            EstimatedEndTime = estimatedEndTime;
        }

        /// <summary>
        /// Gets the estimated end time.
        /// </summary>
        public DateTime EstimatedEndTime { get; }
    }
}
