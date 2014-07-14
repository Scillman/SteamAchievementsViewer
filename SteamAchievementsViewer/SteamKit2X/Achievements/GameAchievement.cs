
namespace SteamKit2X.Achievements
{
    /// <summary>
    /// An achievement of a game.
    /// </summary>
    public class GameAchievement : Achievement
    {
        /// <summary>
        /// The default value for the achievement.
        /// </summary>
        public string DefaultValue { get; private set; }

        /// <summary>
        /// Whether the achievement is hidden or not.
        /// </summary>
        public bool Hidden { get; private set; }

        /// <summary>
        /// The icon of the achievement when achieved.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// The icon of the achievement when not yet achieved.
        /// </summary>
        public string IconGray { get; private set; }

        /// <summary>
        /// Creates a new game specific achievement.
        /// </summary>
        /// <param name="apiName">The API name of the achievement.</param>
        /// <param name="defaultValue">The default value of the achievement.</param>
        /// <param name="displayName">The display name/title of the achievement.</param>
        /// <param name="hidden">Whether the achievement has to be hidden or not.</param>
        /// <param name="description">The description of the achievement.</param>
        /// <param name="icon">The icon of the achievement when achieved.</param>
        /// <param name="iconGray">The icon of the achievement when not yet achieved.</param>
        public GameAchievement(string apiName, string defaultValue, string displayName,
                bool hidden, string description, string icon, string iconGray)
            : base(apiName, displayName, description)
        {
            this.DefaultValue = defaultValue;
            this.Hidden = hidden;
            this.Icon = icon;
            this.IconGray = iconGray;
        }
    }
}
