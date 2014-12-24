using SteamKit2;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal sealed class IAccountRecoveryService
    {
        /// <summary>
        /// Send account recovery data
        /// </summary>
        /// <param name="loginuser_list"></param>
        /// <param name="install_config"></param>
        /// <param name="shasentryfile"></param>
        /// <param name="machineid"></param>
        /// <remarks>POST</remarks>
        public void ReportAccountRecoveryData(string loginuser_list, string install_config, string shasentryfile, string machineid)
        {
            using (dynamic data = WebAPI.GetInterface("IAccountRecoveryService", API.AppKey))
            {
                KeyValue items = data.ReportAccountRecoveryData(loginuser_list: loginuser_list, install_config: install_config, shasentryfile: shasentryfile, machineid: machineid, l: "english");
            }
        }

        /// <summary>
        /// Send account recovery data
        /// </summary>
        /// <param name="requesthandle"></param>
        /// <remarks>POST</remarks>
        public void RetrieveAccountRecoveryData(string requesthandle)
        {
            using (dynamic data = WebAPI.GetInterface("IAccountRecoveryService", API.AppKey))
            {
                KeyValue items = data.RetrieveAccountRecoveryData(requesthandle: requesthandle, l: "english");
            }
        }
    }
}
