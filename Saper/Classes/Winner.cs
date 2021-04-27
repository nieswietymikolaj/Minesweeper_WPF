using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper.Classes
{
    class Winner
    {
        public string place { get; set; }

        public string time { get; set; }

        public string nickname { get; set; }

        public string level { get; set; }

        public string bombAmount { get; set; }

        public string mapSize { get; set; }


        public Winner() { }

        public Winner(string place, string time, string nickname, string level, string bombAmount, string mapSize)
        {
            this.place = place;
            this.time = time;
            this.nickname = nickname;
            this.level = level;
            this.bombAmount = bombAmount;
            this.mapSize = mapSize;
        }
    }
}
