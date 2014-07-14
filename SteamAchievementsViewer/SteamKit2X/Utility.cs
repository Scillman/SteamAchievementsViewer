using System.Threading;

namespace SteamKit2X
{
    internal static class Utility
    {
        /// <summary>
        /// Indicates whether the signal has been set.
        /// </summary>
        /// <param name="control"></param>
        /// <returns>true when the signal has been set; false otherwise.</returns>
        public static bool IsSet(this ManualResetEvent control)
        {
            return control.WaitOne(0);
        }
    }
}
