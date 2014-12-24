using SteamKit2;
using System;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Counter-Strike: Global Offensive
    /// </summary>
    internal sealed class IGCVersion_730
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>NO KEY</remarks>
        public ServerVersion GetServerVersion()
        {
            // Get the interface link.
            using (dynamic data = WebAPI.GetInterface("IGCVersion_730"))
            {
                // Call the actual method.
                KeyValue items = data.GetServerVersion();

                // Ensure the version data has succesfully been retrieved.
                if (items["success"].AsBoolean())
                {
                    // Store the version data in an object.
                    ServerVersion version = new ServerVersion();
                    version.success = true;
                    version.deploy_version = items["deploy_version"].AsInteger();
                    version.active_version = items["active_version"].AsInteger();

                    // Return the version data.
                    return version;
                }
            }

            // Return null on failure.
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException" />
        [Obsolete("This method is not implemented.", true)]
        public void GetClientVersion()
        {
            throw new NotImplementedException("This method is not implemented.");
        }

        public class ServerVersion
        {
            public bool success { get; set; }
            public int deploy_version { get; set; }
            public int active_version { get; set; }

            /// <summary>
            /// The time at which the response was send. (Unix Epoch)
            /// </summary>
            public uint response_time { get; set; }
        }
    }
}
