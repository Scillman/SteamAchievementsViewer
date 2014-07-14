using System;

namespace SteamAchievementsViewer.Steam
{
    public class Client : IDisposable
    {
        /// <summary>
        /// Indicates whether or not the object has been disposed already.
        /// </summary>
        public bool Disposed { get; private set; }

        /// <summary>
        /// Release all the used resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release all the used resources.
        /// </summary>
        /// <param name="disposing">false when unmanaged resources have to be reelased; true when all resources have to be released.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Do not dispose twice
            if (Disposed)
                return;

            // Ensure we do not dispose the object twice.
            Disposed = true;
        }
    }
}
