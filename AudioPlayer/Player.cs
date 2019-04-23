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
        public void Shuffle(List<Song> song)//B7-Player1/2. SongsListShuffle
        {
            List<Song> shuffleList = new List<Song>(song.Count);
            //коллекция чисел  от 0 до song.Count для последующей генерации случайного уникального индекса
            var nums = Enumerable.Range(0, song.Count).ToList();
            Random rand = new Random();
            for (int i = 0; i < song.Count; i++)
            {
                int j = rand.Next(0, nums.Count);
                int index = nums[j];//создание уникального индекса
                //Console.WriteLine(song[index].Title);
                shuffleList.Add(new Song() { Title = song[index].Title, Duration = song[index].Duration });
                nums.RemoveAt(j);//удаление уже использованного уникального индекса из списка чисел
            }
            Console.WriteLine("New Shuffeling Collection:");
            for (int i = 0; i < shuffleList.Count; i++)
            {
                Console.WriteLine(shuffleList[i].Title);
                System.Threading.Thread.Sleep(shuffleList[i].Duration);
            }

        }
        public void SortByTitle(List<Song> song)//B7-Player2/2.SongsListSort
        {
            List<Song> sortList = new List<Song>(song.Count);
            for (int i = 0; i < song.Count; i++)
            {
                sortList.Add(new Song { Title = song[i].Title, Duration = song[i].Duration });
            }
            string[] forSort = new string[sortList.Count];//массив для сортировки названий песен
            for (int i = 0; i < sortList.Count; i++)
            {
                forSort[i] = sortList[i].Title;
            }
            Array.Sort(forSort);
            //блок кода для привязки к названию песни соответсвующей длительности
            for (int i = 0; i < sortList.Count; i++)
            {
                sortList[i].Title = forSort[i];
                for (int j = 0; j < song.Count; j++)
                {
                    if (song[j].Title == sortList[i].Title)
                    {
                        sortList[j].Duration = song[i].Duration;
                    }
                }
            }
            Console.WriteLine("New Sorting Collection:");
            for (int i = 0; i < sortList.Count; i++)
            {
                Console.WriteLine(sortList[i].Title);
                System.Threading.Thread.Sleep(sortList[i].Duration);
            }
        }
    }
}
