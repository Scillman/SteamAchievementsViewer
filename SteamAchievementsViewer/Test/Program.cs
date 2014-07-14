using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamKit2X.Achievements;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var achievements = GameAchievement.Load(1250);
            foreach (var achievement in achievements)
            {
                Console.WriteLine(achievement.ToString());
            }

            Console.ReadKey();
        }
    }
}
