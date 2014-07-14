
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
    }
}
