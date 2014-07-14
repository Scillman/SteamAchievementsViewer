using SteamKit2;
using System.Collections.Generic;

namespace SteamKit2X.Achievements
{
    /// <summary>
    /// A user related achievement.
    /// </summary>
    public class UserAchievement : Achievement
    {
        /// <summary>
        /// Indicates whether or not the user has achieved the achievement.
        /// </summary>
        public bool Achieved { get; private set; }

        /// <summary>
        /// Creates a new user related achievement instance.
        /// </summary>
        /// <param name="apiName">The API name of the achievement.</param>
        /// <param name="displayName">The display name/title of the achievement.</param>
        /// <param name="description">The description of the achievement.</param>
        /// <param name="achieved">Whether the user has achieved the achievement or not.</param>
        public UserAchievement(string apiName, string displayName, string description, bool achieved) :
            base(apiName, displayName, description)
        {
            Achieved = achieved;
        }

        /// <summary>
        /// Load the achievements of the user for the specified application.
        /// </summary>
        /// <param name="steamId">The steamd id of the user.</param>
        /// <param name="appId">The id of the application.</param>
        public static List<UserAchievement> Load(ulong steamId, uint appId)
        {
            // Create a list that is able to hold the achievements.
            var list = new List<UserAchievement>();

            // Get the interface the method is bound to.
            using (dynamic steamUserStats = WebAPI.GetInterface("ISteamUserStats", API.AppKey))
            {
                // Get all the items from the API.
                KeyValue items = steamUserStats.GetPlayerAchievements(appid: appId, steamid: steamId, l: "english");

                // Loop through all the achievements.
                foreach (var item in items["achievements"].Children)
                {
                    // Construct the SteamKit2X.Achievements.UserAchievement object from the returned values.
                    var achievement = new UserAchievement(
                        item["apiname"].AsString(),
                        item["name"].AsString(),
                        item["description"].AsString(),
                        item["achieved"].AsBoolean()
                    );

                    // Add the achievement to the list.
                    list.Add(achievement);
                }
            }

            return list;
        }
    }
}
