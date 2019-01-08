using System;

namespace Cave
{
    /// <summary>
    /// Provides an item containing the creation <see cref="DateTime"/>
    /// </summary>
    public sealed class EstimationItem //MakeInternal:KEEP
    {
        /// <summary>
        /// Creates a new <see cref="EstimationItem"/> with the current <see cref="DateTime"/> value and the specified progress
        /// </summary>
        /// <param name="progress"></param>
        public EstimationItem(float progress)
        {
            Progress = progress;
        }

        /// <summary>
        /// Obtains the <see cref="DateTime"/> (utc) value this item was created
        /// </summary>
        public DateTime DateTime { get; } = DateTime.UtcNow;

        /// <summary>
        /// Obtains the progress at the <see cref="DateTime"/> this item was created
        /// </summary>
        public float Progress { get; }
    }
}
