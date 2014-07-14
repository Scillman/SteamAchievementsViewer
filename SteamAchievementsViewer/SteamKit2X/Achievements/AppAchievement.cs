using SteamKit2;
using System.Collections.Generic;

namespace SteamKit2X.Achievements
{
    /// <summary>
    /// An achievement of an application.
    /// </summary>
    public class AppAchievement : Achievement
    {
        /// <summary>
        /// The default value for the achievement.
        /// </summary>
        public int DefaultValue { get; private set; }

        /// <summary>
        /// Whether the achievement is hidden or not.
        /// </summary>
        public bool Hidden { get; private set; }

        /// <summary>
        /// The url to the icon of the achievement when achieved.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// The url to the icon of the achievement when not yet achieved.
        /// </summary>
        public string IconGray { get; private set; }

        /// <summary>
        /// Creates a new application specific achievement.
        /// </summary>
        /// <param name="apiName">The API name of the achievement.</param>
        /// <param name="defaultValue">The default value of the achievement.</param>
        /// <param name="displayName">The display name/title of the achievement.</param>
        /// <param name="hidden">Whether the achievement has to be hidden or not.</param>
        /// <param name="description">The description of the achievement.</param>
        /// <param name="icon">The url to the icon of the achievement when achieved.</param>
        /// <param name="iconGray">The url to the icon of the achievement when not yet achieved.</param>
        public AppAchievement(string apiName, int defaultValue, string displayName, bool hidden, string description, string icon, string iconGray)
            : base(apiName, displayName, description)
        {
            this.DefaultValue = defaultValue;
            this.Hidden = hidden;
            this.Icon = icon;
            this.IconGray = iconGray;
        }

        /// <summary>
        /// Allows comparison between <see cref="SteamKit2X.Achievements.AppAchievement"/> objects. 
        /// </summary>
        /// <param name="achievement">The achievement that has to be compared to this achievement.</param>
        /// <returns></returns>
        public override int CompareTo(Achievement achievement)
        {
            // When the achievement is not a SteamKit2X.Achievements.AppAchievement abort.
            if (!(achievement is AppAchievement))
                return 1;
            return base.CompareTo(achievement);
        }

        /// <summary>
        /// Load the achievements of the specified application.
        /// </summary>
        /// <param name="appId">The id of the application.</param>
        public static List<AppAchievement> Load(uint appId)
        {
            // Create a list that is able to hold the achievements.
            var list = new List<AppAchievement>();

            // Get the interface the method is bound to.
            using (dynamic steamUserStats = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                // Get all the items from the API.
                KeyValue items = steamUserStats.GetSchemaForGame2(appid : appId, l : "english");

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

                    // Add the achievement to the list.
                    list.Add(achievement);
                }
            }

            return list;
        }
    }
}
