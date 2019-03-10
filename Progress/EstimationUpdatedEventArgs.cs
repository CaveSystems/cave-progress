using System;

namespace Cave
{
    /// <summary>
    /// Provides an event for <see cref="IEstimation"/> classes to notify about actualizations.
    /// </summary>
    public sealed class EstimationUpdatedEventArgs : EventArgs // MakeInternal:KEEP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimationUpdatedEventArgs"/> class.
        /// </summary>
        public EstimationUpdatedEventArgs(DateTime estimatedEndTime)
        {
            EstimatedEndTime = estimatedEndTime;
        }

        /// <summary>
        /// Gets the estimated end time.
        /// </summary>
        public DateTime EstimatedEndTime { get; }
    }
}
