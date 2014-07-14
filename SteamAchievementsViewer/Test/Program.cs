using SteamKit2X.Achievements;
using SteamKit2X;
using System;

/**
 * This project is sololy used for minor testing purposes.
 */
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var manager = new ClientManager(null, "Scillman", "password"))
            {
                var achievements = UserAchievement.Load(76561197991494515, 1250);
                foreach (var achievement in achievements)
                {
                    Console.WriteLine(achievement.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
