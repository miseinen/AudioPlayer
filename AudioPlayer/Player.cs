using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {
        private int _volume;
        private const int _maxVolume=100;
        public int Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if (value > _maxVolume)
                {
                    _volume = _maxVolume;
                }
                else if (value < 0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }
            }
        }
        public bool isLock;
        public Song[] Songs;

        public void Play()
        {
            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine(Songs[i].Title);
                System.Threading.Thread.Sleep(2000);
            }
        }

        public void VolumeUp()
        {
            Volume += 5;
            Console.WriteLine($"Volume is {Volume}.");
        }

        public void VolumeDown()
        {
            Volume -= 5;
            Console.WriteLine($"Volume is {Volume}.");
        }
    }
}
