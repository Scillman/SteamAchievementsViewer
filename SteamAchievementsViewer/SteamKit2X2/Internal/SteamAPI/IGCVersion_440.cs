using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Team Fortress 2
    /// </summary>
    internal sealed class IGCVersion_440
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>NO KEY</remarks>
        public ClientVersion GetClientVersion()
        {
            // Get the interface link.
            using (dynamic data = WebAPI.GetInterface("IGCVersion_440"))
            {
                // Call the actual method.
                KeyValue items = data.GetClientVersion();

                // Ensure the version data has succesfully been retrieved.
                if (items["success"].AsBoolean())
                {
                    // Store the version data in an object.
                    ClientVersion version = new ClientVersion();
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
        /// <remarks>NO KEY</remarks>
        public ServerVersion GetServerVersion()
        {
            // Get the interface link.
            using (dynamic data = WebAPI.GetInterface("IGCVersion_440"))
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
                    version.min_allowed_version = items["min_allowed_version"].AsInteger();

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
            public int deploy_version { get; set; }
            public int active_version { get; set; }
        }

        public class ServerVersion
        {
            public bool success { get; set; }
            public int deploy_version { get; set; }
            public int active_version { get; set; }
            public int min_allowed_version { get; set; }
        }
    }
}
