using SteamKit2X.Achievements;
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
            var achievements = UserAchievement.Load(76561197991494515, 1250);
            foreach (var achievement in achievements)
            {
                Console.WriteLine(achievement.ToString());
            }

            Console.ReadKey();
        }
    }
}
