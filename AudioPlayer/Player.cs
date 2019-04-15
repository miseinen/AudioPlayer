using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {
        private int volume;
        private const int maxVolume=100;
        public int Volume
        {
            get
            {
                return volume;
            }
            private set
            {
                if (value > maxVolume)
                {
                    volume = maxVolume;
                }
                else if (value < 0)
                {
                    volume = 0;
                }
                else
                {
                    volume = value;
                }
            }
        }
        public bool IsLock;
        private bool isPlaying;
        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
        }
        public Song[] Songs;
        public void VolumeUp()
        {
            Volume += 1;
            Console.WriteLine($"Volume was changed. Current Volume: {Volume}.");
        }

        public void VolumeDown()
        {
            Volume -= 1;
            Console.WriteLine($"Volume was changed. Current Volume: {Volume}.");
        }
        public void VolumeChangeUp(int step)
        {
            Console.Write("Increase Volume. Input value: ");
            step = Convert.ToInt32(Console.ReadLine());
            Volume += step;
            Console.WriteLine($"Volume was changed. Current Volume: {Volume}.");
        }
        public void VolumeChangeDown(int step)
        {
            Console.Write("Decrease Volume. Input value: ");
            step = Convert.ToInt32(Console.ReadLine());
            Volume -= step;
            Console.WriteLine($"Volume was changed.Current Volume: { Volume}.");
        }
        public void Lock()
        {
            IsLock = true;
            Console.WriteLine("Player is locked.");
        }
        public void UnLock()
        {
            IsLock = false;
            Console.WriteLine("Player is unloked.");
        }
        
        public void Stop()
        {
            if (!IsLock)
            {
                isPlaying = false;
                Console.WriteLine("Player is stopped.");
            }
        }
        public void Start()
        {
            if (!IsLock)
            {
                isPlaying = true;
                Console.WriteLine("Player is started.");
            }
        }
        
        public void Play()
        {
            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine(Songs[i].Title + "  " + Songs[i].Artist.Name + "  " + Songs[i].Duration);
                System.Threading.Thread.Sleep(Songs[i].Duration);
            }
        }

        public void Add(params string[] Song)
        {
            Random rand = new Random();
            for (int i = 0; i < Song.Length; i++)
            {
                Console.WriteLine(Song[i]);
            }
        }
    }
}
