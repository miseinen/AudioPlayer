using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public static class ExtensionClass
    {
        public static List<Song> Shuffle(this List<Song> song)//L9-HW-Player-1/3,B7-Player1/2. SongsListShuffle
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
            return shuffleList;

        }
        public static List<Song> SortByTitle(this List<Song> song)//L9-HW-Player-1/3,B7-Player2/2.SongsListSort
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
            return sortList;
        }
        public static string StringCut(this List<Song> song)//L9-HW-Player-2/3.
        {
            string forCut=null;
            for (int i = 0; i <song.Count; i++)
            {
                forCut = song[i].Title;
                int length = forCut.Length;
                if (length > 10)
                {
                    forCut = forCut.Remove(9, length - 9);
                    Console.WriteLine($"{forCut}...");
                }
                else Console.WriteLine(song[i].Title);
            }
            return forCut;
        }
        public static void Deconstruct(this Song song, out string title, out int duration, 
            out Artist artist, out bool? like, out object genre, out Album album, out string lyrics)//L9-HW-Player-3/3.
        {
            title = song.Title;
            duration = song.Duration;
            artist = song.Artist;
            like = song.Like;
            genre = song.Genre;
            album = song.Album;
            lyrics = song.Lyrics;
        }
    }
}
