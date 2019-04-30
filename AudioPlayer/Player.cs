using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Player
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
        List<Song> songList = new List<Song>();
        public void Play()
        {
            
        }
        
        public void Add(List<Song> song)
        {
            song.Add(new Song() { Title = "Toxicity", Duration = 500, Like=null, Genre=Song.Genres.Rock });
            song.Add(new Song() { Title = "Nightcall", Duration = 300, Like=false, Genre = Song.Genres.Synthwave
            });
            song.Add(new Song() { Title = "What I've done", Duration = 900, Like = false, Genre = Song.Genres.Rock });
            song.Add(new Song() { Title = "Shout", Duration = 500, Like = true, Genre = Song.Genres.Metalcore });
            song.Add(new Song() { Title = "Aerials", Duration = 700, Like = true, Genre = Song.Genres.Rock });
            song.Add(new Song() { Title = "Pain", Duration = 900, Like = null, Genre = Song.Genres.Rock });
            song.Add(new Song() { Title = "Anaconda", Duration = 900, Like = false, Genre = Song.Genres.Pop });
            Console.WriteLine("Defaul Song List is added.");
        }
        public void GetSongData(List<Song> song)//L9-HW-Player-3/3.
        {
            for (int i= 0; i<song.Count; i++)            
            {
                (string title,  int duration, _,  bool? like,  object genre, _, _) = song[i];
                Console.WriteLine($"Title={title}, Duration={duration}, Like={like}, Genre={genre}");
            }
        }
    }
}
