using System;
using System.Diagnostics;
using System.IO;

namespace SteamKit2X2.Internal
{
    /// <summary>
    /// Steam API specifics.
    /// </summary>
    internal static class API
    {
        /// <summary>
        /// The key as stored in memory.
        /// </summary>
        private static string _appKey;

        /// <summary>
        /// The application key, for Steam, as a singleton.
        /// </summary>
        internal static string AppKey
        {
            get
            {
                // Ensure it is not empty.
                if (_appKey == null)
                {
#if DEBUG
                    try
                    {
                        // Load the key from file.
                        _appKey = File.ReadAllText("System\\Data\\app.key");
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("Could not get the application key.");
                        return null;
                    }
#else
                    _appKey = "YOURAPIKEY";
#endif
                }
                return _appKey;
            }
        }
    }
}
