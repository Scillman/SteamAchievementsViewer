using SteamKit2;
using SteamKit2X2.Internal;

/**
 * http://api.steampowered.com/ISteamWebAPIUtil/GetSupportedAPIList/v0001/
 * https://steamdb.info/
 */
namespace SteamKit2X2
{
    class OldSchool
    {
        public OldSchool()
        {
        }

        public void Test(long appId)
        {
            // Get the interface the method is bound to.
            using (dynamic steamUserStats = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                // Get all the items from the API.
                KeyValue items = steamUserStats.GetSchemaForGame2(appid: appId, l: "english");

                // Loop through all the achievements.
                foreach (var item in items["availableGameStats"]["achievements"].Children)
                {
                    // Construct the SteamKit2X.Achievements.AppAchievement object from the returned values.
                    var achievement = new AppAchievement(
                        item["name"].AsString(),
                        item["defaultvalue"].AsInteger(),
                        item["displayName"].AsString(),
                        item["hidden"].AsBoolean(),
                        item["description"].AsString(),
                        item["icon"].AsString(),
                        item["icongray"].AsString()
                    );
                }
            }
        }

        private class AppAchievement
        {
            public AppAchievement(string name, int defaultValue, string displayName, bool hidden, string description, string icon, string iconGray) { }
        }
    }
}
