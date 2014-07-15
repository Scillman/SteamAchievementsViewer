using SteamKit2;
using System;

namespace SteamKit2X.Users
{
    /// <summary>
    /// A steam user.
    /// </summary>
    public class User : IComparable
    {
        /// <summary>
        /// Get the steamd id of the user.
        /// </summary>
        public ulong SteamID { get; private set; }

        /// <summary>
        /// Get the name of the user.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Creates a new user instance.
        /// </summary>
        /// <param name="steamID">The SteamID of the user.</param>
        /// <param name="name">The name of the user.</param>
        public User(ulong steamID, string name = "[unknown]")
        {
            this.SteamID = steamID;
            this.Name = name;
        }

        /// <summary>
        /// Determines if the <see cref="SteamKit2X.Users.User"/> objects are the same.
        /// </summary>
        /// <param name="userA">The first user that has to be compared.</param>
        /// <param name="userB">The second user that has to be compared.</param>
        /// <returns>true if the users are the same; false otherwise.</returns>
        public static bool operator ==(User userA, User userB)
        {
            // When userA is null.
            if (ReferenceEquals(userA, null))
            {
                // If userB is null than they are equal not otherwise.
                return ReferenceEquals(userB, null);
            }

            // If both are objects, compare them.
            return userA.Equals(userB);
        }

        /// <summary>
        /// Determines if the <see cref="SteamKit2X.Users.User"/> objects are different.
        /// </summary>
        /// <param name="userA">The first user that has to be compared.</param>
        /// <param name="userB">The second user that has to be compared.</param>
        /// <returns>true if the users are different; false otherwise.</returns>
        public static bool operator !=(User userA, User userB)
        {
            return !(userA == userB);
        }

        /// <summary>
        /// Explicitly convert the user object into an ulong.
        /// </summary>
        /// <param name="user">The user that has to be converted.</param>
        /// <returns>The Steam ID of the user.</returns>
        public static explicit operator ulong(User user)
        {
            return user.SteamID;
        }

        /// <summary>
        /// Compare this user to an other user.
        /// </summary>
        /// <param name="obj">The other user.</param>
        /// <returns>An indication of their relative values.</returns>
        public int CompareTo(object obj)
        {
            // The object may not be null.
            if (obj == null)
                return 1;

            // Convert the object, it must be an user object otherwise return 1.
            var user = obj as User;
            if (user == null)
                return 1;

            // Compare the users based on their Steam ID.
            return this.SteamID.CompareTo(user.SteamID);
        }

        /// <summary>
        /// Determines whether the objects are the same.
        /// </summary>
        /// <param name="obj">The user that has to be compared with this one.</param>
        /// <returns>true when it is the same user; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            // The object may not be null.
            if (obj == null)
                return false;

            // Convert the object, it must be an user object otherwise return false.
            var user = obj as User;
            if (user == null)
                return false;

            // Compare the users based on their Steam ID.
            return this.SteamID.Equals(user.SteamID);
        }

        /// <summary>
        /// Gets the hash code of the user.
        /// </summary>
        /// <returns>The Steam ID, these are unique.</returns>
        public override int GetHashCode()
        {
            return (int) (new SteamID(this.SteamID)).AccountID;
        }
    }
}
