using System;

namespace SteamKit2X2
{
    internal static class Utility
    {
        /// <summary>
        /// Converts the given unsigned integer into a DateTime object.
        /// </summary>
        /// <param name="time">The time that has to be converted to a DateTime object.</param>
        /// <returns>A DateTime object representation of the given time.</returns>
        /// <remarks>Credits: LukeH @ stackoverflow.com</remarks>
        public static DateTime FromUnixTime(this uint time)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds((long)time);
        }
    }
}
