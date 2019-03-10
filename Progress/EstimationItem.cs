using System;

namespace Cave
{
    /// <summary>
    /// Provides an item containing the creation <see cref="DateTime"/>.
    /// </summary>
    public sealed class EstimationItem // MakeInternal:KEEP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimationItem"/> class.
        /// </summary>
        /// <param name="progress"></param>
        public EstimationItem(float progress)
        {
            Progress = progress;
        }

        /// <summary>
        /// Gets the <see cref="DateTime"/> (utc) value this item was created.
        /// </summary>
        public DateTime DateTime { get; } = DateTime.UtcNow;

        /// <summary>
        /// Gets the progress at the <see cref="DateTime"/> this item was created.
        /// </summary>
        public float Progress { get; }
    }
}
