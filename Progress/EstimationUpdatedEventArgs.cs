using System;

namespace Cave
{
    /// <summary>
    /// Provides an event for <see cref="IEstimation"/> classes to notify about actualizations.
    /// </summary>
    public sealed class EstimationUpdatedEventArgs : EventArgs //MakeInternal:KEEP
    {
        /// <summary>
        /// Creates new <see cref="EstimationUpdatedEventArgs"/>
        /// </summary>
        public EstimationUpdatedEventArgs(DateTime estimatedEndTime)
        {
            EstimatedEndTime = estimatedEndTime;
        }

        /// <summary>
        /// Obtains the estimated end time
        /// </summary>
        public DateTime EstimatedEndTime { get; }
    }

}
