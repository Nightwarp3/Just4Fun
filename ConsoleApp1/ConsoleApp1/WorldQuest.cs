using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class WorldQuest
    {
        public WorldQuest()
        {
            rewards = new List<string>();
            name = "";
            timeLeft = "";
            faction = "";
            zone = "";
        }

        public List<string> rewards;
        public string name;
        public string timeLeft;
        public string faction;
        public string zone;
    }
}
