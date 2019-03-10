using System;
using System.Collections.Generic;
using System.Threading;

#if !NET20
using System.Linq;
#endif

namespace Cave.Progress
{
    /// <summary>
    /// Provides progress management using callback events on progress change and completion.
    /// </summary>
    public class ProgressManagerBase : IProgressManager
    {
        int nextIdentifier;
#if NET20
        Dictionary<IProgress, IProgress> items = new Dictionary<IProgress, IProgress>();
#else
        HashSet<IProgress> items = new HashSet<IProgress>();
#endif

        class ProgressItem : IProgress
        {
            ProgressManagerBase manager;
            public ProgressItem(ProgressManagerBase manager)
            {
                this.manager = manager;
                Identifier = Interlocked.Increment(ref this.manager.nextIdentifier);
            }
            public int Identifier { get; }
            public float Value { get; private set; }
            public bool Completed { get; private set; }
            public string Text { get; private set; }
            public void Complete()
            {
                lock (this)
                {
                    Value = 1;
                    Completed = true;
                    manager.OnUpdated(this);
                }
            }
            public void Update(float value, string text = null)
            {
                lock (this)
                {
                    if (Completed)
                    {
                        throw new InvalidOperationException();
                    }

                    if (value < Value)
                    {
                        return;
                    }

                    if (value > 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value));
                    }

                    if (text != null)
                    {
                        Text = text;
                    }
                    Value = value;

                    manager.OnUpdated(this);
                }
            }

            public override string ToString()
            {
                return $"{Value.ToString("P")} : {Text}";
            }
        }

        void OnUpdated(IProgress progress)
        {
            Updated?.Invoke(progress, new ProgressEventArgs(progress));
            if (progress.Completed)
            {
                lock (this)
                {
                    items.Remove(progress);
                }
            }
        }

        /// <summary>
        /// Provides an event for each progress update / completion
        /// </summary>
        public event EventHandler<ProgressEventArgs> Updated;

        /// <summary>
        /// Creates a new progress object implementing the <see cref="IProgress"/> interface.
        /// </summary>
        /// <remarks>
        /// This function does not call the <see cref="Updated"/> event for the newly created <see cref="IProgress"/> instance.
        /// The <see cref="Updated"/> event will be fired upon the first <see cref="IProgress.Update(float, string)"/> call.
        /// </remarks>
        /// <returns>Retruns a new instance implementing the <see cref="IProgress"/> interface.</returns>
        public IProgress CreateProgress()
        {
            var result = new ProgressItem(this);
            lock (this)
            {
#if NET20
                items.Add(result, result);
#else
                items.Add(result);
#endif
            }
            return result;
        }

        /// <summary>
        /// Gets the current progress items.
        /// </summary>
        public IEnumerable<IProgress> Items
        {
            get
            {
                lock (this)
                {
#if NET20
                    return new List<IProgress>(items.Keys);
#else
                    return items.ToList();
#endif
                }
            }
        }
    }
}
