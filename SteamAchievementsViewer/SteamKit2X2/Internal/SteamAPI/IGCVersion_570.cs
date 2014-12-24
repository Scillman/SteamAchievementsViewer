using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Dota 2
    /// </summary>
    internal sealed class IGCVersion_570
    {
        /// <summary>
        /// Gets the client version information for Dota 2.
        /// </summary>
        /// <returns>An object containing information about the version of the Dota 2 client; null on failure.</returns>
        /// <remarks>NO KEY</remarks>
        public ClientVersion GetClientVersion()
        {
            // Get the interface link.
            using (dynamic data = WebAPI.GetInterface("IGCVersion_570"))
            {
                // Call the actual method.
                KeyValue items = data.GetClientVersion();

                // Ensure the version data has succesfully been retrieved.
                if (items["success"].AsBoolean())
                {
                    // Store the version data in an object.
                    ClientVersion version = new ClientVersion();
                    version.success = true;
                    version.min_allowed_version = items["min_allowed_version"].AsInteger();
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
        /// <remarks>NO KEY</remarks>
        public ServerVersion GetServerVersion()
        {
            // Get the interface link.
            using (dynamic data = WebAPI.GetInterface("IGCVersion_570"))
            {
                // Call the actual method.
                KeyValue items = data.GetServerVersion();

                // Ensure the version data has succesfully been retrieved.
                if (items["success"].AsBoolean())
                {
                    // Store the version data in an object.
                    ServerVersion version = new ServerVersion();
                    version.success = true;
                    version.engine = items["engine"].AsInteger();
                    version.active_version = items["active_version"].AsInteger();
                    version.deploy_version = items["deploy_version"].AsInteger();
                    version.response_time = (uint)items["response_time"].AsInteger();

                    // Return the version data.
                    return version;
                }
            }

            // Return null on failure.
            return null;
        }

        public class ClientVersion
        {
            public bool success { get; set; }
            public int min_allowed_version { get; set; }
            public int active_version { get; set; }
        }

        public class ServerVersion
        {
            public bool success { get; set; }
            public int engine { get; set; }
            public int deploy_version { get; set; }
            public int active_version { get; set; }

            /// <summary>
            /// The time at which the response was send. (Unix Epoch)
            /// </summary>
            public uint response_time { get; set; }
        }
    }
}
