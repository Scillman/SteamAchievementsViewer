using SteamKit2;
using System;
using System.Collections.Generic;

namespace SteamKit2X2.Internal.SteamAPI
{
    /// <summary>
    /// Team Fortress 2
    /// </summary>
    internal sealed class ITFItems_440
    {
        /// <summary>
        /// Gets the golden wrenches list. It contains the #100 steam users.
        /// </summary>
        /// <exception cref="System.Exception">Thrown when we could not get the golden wrenches.</exception>
        public List<GoldenWrench> GetGoldenWrenches2()
        {
            // Create a list that will hold all the golden wrenches.
            List<GoldenWrench> wrenches = new List<GoldenWrench>();

            // Open a link to the interface.
            using (dynamic data = WebAPI.GetInterface("ITFItems_440", API.AppKey))
            {
                // Execute the method on the interface.
                KeyValue items = data.GetGoldenWrenches2();

                // Loop through all the wrenches.
                foreach (var item in items["wrenches"].Children)
                {
                    // Convert the returned wrench data into a special wrench object.
                    GoldenWrench wrench = new GoldenWrench(
                        (ulong)item["steamID"].AsLong(),
                        (uint)item["timestamp"].AsInteger(),
                        (uint)item["itemID"].AsInteger(),
                        (uint)item["wrenchNumber"].AsInteger()
                    );

                    // Add the wrench to the list of wrenches.
                    wrenches.Add(wrench);
                }
            }

            // Return the list of all the wrenches.
            return wrenches;
        }

        /// <summary>
        /// An object representing a Team Fortress 2 golden wrench.
        /// </summary>
        /// <remarks>The types are guessed from the given output.</remarks>
        public class GoldenWrench : IEquatable<GoldenWrench>, IComparable, IComparable<GoldenWrench>
        {
            /// <summary>
            /// The Steam ID of the user who won the golden wrench.
            /// </summary>
            public ulong steamID { get; private set; }

            /// <summary>
            /// The timestamp of the wrench. (Unix Epoch)
            /// </summary>
            public uint timestamp { get; private set; }

            /// <summary>
            /// The item ID of the wrench.
            /// </summary>
            public uint itemID { get; private set; } /* Guess this to be 32-bit as it is within range. */

            /// <summary>
            /// The number of the wrench. (1-100)
            /// </summary>
            public uint wrenchNumber { get; private set; }

            /// <summary>
            /// Creates a new GoldenWrench object.
            /// </summary>
            /// <param name="steamID">The SteamID of the user who won the wrench.</param>
            /// <param name="timestamp">The time at which the user won the wrench.</param>
            /// <param name="itemID">The wrench's specific item ID.</param>
            /// <param name="wrenchNumber">The number of the wrench. (1-100)</param>
            internal GoldenWrench(ulong steamID, uint timestamp, uint itemID, uint wrenchNumber)
            {
                this.steamID = steamID;
                this.timestamp = timestamp;
                this.itemID = itemID;
                this.wrenchNumber = wrenchNumber;
            }

            /// <summary>
            /// Returns a string that represents the current object.
            /// </summary>
            /// <returns>A string that represents the current object.</returns>
            public override string ToString()
            {
                return string.Format("ID: {0}\r\nTimestamp: {1}\r\nItemID: {2}\r\nWrenchNumber: {3}", steamID, timestamp, itemID, wrenchNumber);
            }

            /// <summary>
            /// Determines if the GoldenWrench objects are the same.
            /// </summary>
            /// <param name="x">The first wrench that has to be compared.</param>
            /// <param name="y">The second wrench that has to be compared.</param>
            /// <returns>true if the wrenches are the same; false otherwise.</returns>
            public static bool operator ==(GoldenWrench x, GoldenWrench y)
            {
                // When the first object is null.
                if (ReferenceEquals(x, null))
                {
                    // If the second object is null than they are equal not otherwise.
                    return ReferenceEquals(y, null);
                }

                // If both are objects, compare them.
                return x.Equals(y);
            }

            /// <summary>
            /// Determines if the GoldenWrench objects are different.
            /// </summary>
            /// <param name="x">The first wrench that has to be compared.</param>
            /// <param name="y">The second wrench that has to be compared.</param>
            /// <returns>true if the wrenches are different; false otherwise.</returns>
            public static bool operator !=(GoldenWrench x, GoldenWrench y)
            {
                return !(x == y);
            }

            /// <summary>
            /// Returns a value indicating whether this instance is equal to a specified System.UInt32.
            /// </summary>
            /// <param name="obj">A value to compare to this instance.</param>
            /// <returns>true if obj has the same value as this instance; otherwise, false.</returns>
            public override bool Equals(object obj)
            {
                // Compare this wrench with the object.
                return Equals(obj as GoldenWrench);
            }

            /// <summary>
            /// Returns a value indicating whether this instance is equal to a specified System.UInt32.
            /// </summary>
            /// <param name="other">A value to compare to this instance.</param>
            /// <returns>true if obj has the same value as this instance; otherwise, false.</returns>
            public bool Equals(GoldenWrench other)
            {
                // If the object is null.
                if (other == null)
                    return false;

                // Compare this wrench's number with the other wrench's number.
                return wrenchNumber.Equals(other.wrenchNumber);
            }

            /// <summary>
            /// Compares this instance to a specified object and returns an indication of their relative values.
            /// </summary>
            /// <param name="obj">An unsigned integer to compare.</param>
            /// <returns>
            /// A signed number indicating the relative values of this instance and value.Return
            /// value Description Less than zero This instance is less than value. Zero This
            /// instance is equal to value. Greater than zero This instance is greater than
            /// value.
            /// </returns>
            public int CompareTo(object obj)
            {
                // Compare this wrenchwith the other object.
                return CompareTo(obj as GoldenWrench);
            }

            /// <summary>
            /// Compares this instance to a specified GoldenWrench object and returns an indication of their relative values.
            /// </summary>
            /// <param name="other">An unsigned integer to compare.</param>
            /// <returns>
            /// A signed number indicating the relative values of this instance and value.Return
            /// value Description Less than zero This instance is less than value. Zero This
            /// instance is equal to value. Greater than zero This instance is greater than
            /// value.
            /// </returns>
            public int CompareTo(GoldenWrench other)
            {
                // If the object is null.
                if (other == null)
                    return 1;

                // Compare this wrench's number with the other wrench's timestamp.
                return wrenchNumber.CompareTo(other.wrenchNumber);
            }

            /// <summary>
            /// Returns the hash code for this instance.
            /// </summary>
            /// <returns>A 32-bit signed integer hash code.</returns>
            public override int GetHashCode()
            {
                return wrenchNumber.GetHashCode();
            }
        }
    }
}
