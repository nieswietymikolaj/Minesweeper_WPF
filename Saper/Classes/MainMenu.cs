using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Saper.Classes
{
    public class MainMenu
    {
        private SoundPlayer player;

        public string musicPath { get; set; }
        public bool musicFlag { get; set; }

        public int mapSize { get; set; }
        public int bombAmount { get; set; }
        public string level { get; set; }

        public bool gameOn { get; set; }
        public int playTime { get; set; }
        public string nickname { get; set; }


        public MainMenu() { }

        public MainMenu(string musicPath, bool musicFlag, int mapSize, int bombAmount, string level)
        {
            this.musicPath = musicPath;
            this.musicFlag = musicFlag;
            this.mapSize = mapSize;
            this.bombAmount = bombAmount;
            this.level = level;

            gameOn = false;
            playTime = 0;
        }

        public void SetMapSize(int mapSize)
        {
            this.mapSize = mapSize;
            this.level = "własny";
        }

        public void SetBombAmount(int bombAmount)
        {
            this.bombAmount = bombAmount;
            this.level = "własny";
        }

        public void SetLevel(int mapSize, int bombAmount, string level)
        {
            this.mapSize = mapSize;
            this.bombAmount = bombAmount;
            this.level = level;
        }

        public void PlaySong()
        {
            player = new SoundPlayer(musicPath);
            player.PlayLooping();
            musicFlag = true;
        }

        public void StopMusic()
        {
            player.Stop();
            musicFlag = false;
        }

        public void PlayExplosion()
        {
            player = new SoundPlayer("Sounds/Explosion.wav");
            player.Play();
        }

        public void PlayFanfare()
        {
            player = new SoundPlayer("Sounds/Fanfare.wav");
            player.Play();
        }
    }
}
