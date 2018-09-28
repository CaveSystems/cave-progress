using System;
using System.Collections.Generic;

namespace Cave.Progress
{
    /// <summary>
    /// Provides progress management using callback events on progress change and completion.
    /// </summary>
    public sealed class ProgressManager : ProgressManagerBase
    {
        static readonly object syncRoot = new object();
        static IProgressManager globalInstance;

        /// <summary>
        /// Allows access to the global static used instance.
        /// </summary>
        public static IProgressManager GlobalInstance
        {
            get
            {
                if (globalInstance == null)
                {
                    SetGlobalInstance(new ProgressManager());
                }

                return globalInstance;
            }
        }

        /// <summary>
        /// Allows to change the globally used instance.
        /// </summary>
        /// <remarks>
        /// All events of <see cref="IProgress"/> objects will be routed to the new global instance.
        /// </remarks>
        /// <param name="newGlobalInstance">New global instance to use</param>
        /// <param name="removeUpdatedEvent">Set to true to remove <see cref="Updated"/> handler from old instance preventing updates to old instance.</param>
        public static void SetGlobalInstance(IProgressManager newGlobalInstance, bool removeUpdatedEvent = false)
        {
            lock (syncRoot)
            {
                if (newGlobalInstance == null)
                {
                    throw new ArgumentNullException(nameof(newGlobalInstance));
                }

                if (globalInstance == newGlobalInstance)
                {
                    return;
                }

                if (removeUpdatedEvent)
                {
                    globalInstance.Updated -= OnUpdated;
                }

                newGlobalInstance.Updated += OnUpdated;
                globalInstance = newGlobalInstance;
            }
        }

        static void OnUpdated(object sender, ProgressEventArgs e)
        {
            lock (syncRoot)
            {
                Updated?.Invoke(GlobalInstance, e);
            }
        }

        /// <summary>
        /// Creates a new progress object implementing the <see cref="IProgress"/> interface.
        /// </summary>
        /// <remarks>
        /// This function does not call the <see cref="Updated"/> event for the newly created <see cref="IProgress"/> instance.
        /// The <see cref="Updated"/> event will be fired upon the first <see cref="IProgress.Update(float, string)"/> call.
        /// </remarks>
        /// <returns>Retruns a new instance implementing the <see cref="IProgress"/> interface.</returns>
        public new static IProgress CreateProgress() => GlobalInstance.CreateProgress();

        /// <summary>
        /// Provides an event for each progress update / completion
        /// </summary>
        public new static event EventHandler<ProgressEventArgs> Updated;

        /// <summary>
        /// Retrieves the current progress items
        /// </summary>
        public new static IEnumerable<IProgress> Items = GlobalInstance.Items;
    }
}