﻿using System;

namespace SteamKit2X.Achievements
{
    /// <summary>
    /// The general interface for achievements.
    /// </summary>
    public abstract class Achievement : IComparable<Achievement>
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
        /// <param name="achievement">The achievement that has to be compared to this achievement.</param>
        /// <returns></returns>
        public virtual int CompareTo(Achievement achievement)
        {
            // Ensure it is an SteamKit2X.Achievements.Achievement object.
            if (achievement == null)
                throw new ArgumentException("The object is not a SteamKit2X.Achievements.Achievement object.");

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
