using System;

namespace SteamKit2X.Achievements
{
    /// <summary>
    /// The general interface for achievements.
    /// </summary>
    public abstract class Achievement : IComparable
    {
        /// <summary>
        /// Get the API name of the achievement.
        /// </summary>
        public string ApiName { get; private set; }

        /// <summary>
        /// Get the displayed name of the achievement.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Get the description of the achievement.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Create a new achievement.
        /// </summary>
        /// <param name="apiName">The API name of the achievement.</param>
        /// <param name="displayName">The display name/title of the achievement.</param>
        /// <param name="description">The description of the achievement.</param>
        public Achievement(string apiName, string displayName, string description)
        {
            ApiName = apiName;
            DisplayName = displayName;
            Description = description;
        }

        /// <summary>
        /// Allows comparison between <see cref="SteamKit2X.Achievements.Achievement"/> objects. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            // Ensure the object is not null.
            if (obj == null)
                return 1;

            // Turn the object into an achievement and ensure it is an SteamKit2X.Achievements.Achievement object.
            var achievement = obj as Achievement;
            if (achievement == null)
                throw new ArgumentException("The object is not an SteamKit2X.Achievements.Achievement object.");

            // Compare achievements by their API name.
            return ApiName.CompareTo(achievement.ApiName);
        }

        /// <summary>
        /// Turns the <see cref="SteamKit2X.Achievements.Achievement"/> object into its string representation.
        /// </summary>
        /// <returns>The object as a string.</returns>
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
