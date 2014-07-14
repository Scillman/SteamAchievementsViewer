using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamKit2X
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
                    try
                    {
                        // Load the key from file.
                        _appKey = File.ReadAllText("Data\\app.key");
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("Could not get the application key.");
                        return null;
                    }
                }
                return _appKey;
            }
        }
    }
}
