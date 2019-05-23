using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    
    public static class ExtensionClass
    {
        public static List<T> Shuffle<T>(this List<T> playingItem)//L9-HW-Player-1/3,B7-Player1/2. SongsListShuffle
        {
            List<T> shuffleList = new List<T>(playingItem.Count);
            //коллекция чисел  от 0 до song.Count для последующей генерации случайного уникального индекса
            var nums = Enumerable.Range(0, playingItem.Count).ToList();
            Random rand = new Random();
            for (int i = 0; i < playingItem.Count; i++)
            {
                int j = rand.Next(0, nums.Count);
                int index = nums[j];//создание уникального индекса
                //Console.WriteLine(song[index].Title);
                shuffleList.Add(playingItem[index]);
                nums.RemoveAt(j);//удаление уже использованного уникального индекса из списка чисел
            }
            return shuffleList;
        }
        
        public static List<Song> SortByTitle(this List<Song> song)//L9-HW-Player-1/3,B7-Player2/2.SongsListSort
        {
            List<Song> sortList = new List<Song>(song.Count);
            string[] forSort = new string[song.Count];//массив для сортировки названий песен
            for (int i = 0; i < song.Count; i++)
            {
                forSort[i] = song[i].Title;
            }
            Array.Sort(forSort);
            foreach (var title in forSort)
            {
                sortList.Add(new Song() { Title = title });
            }
            //блок кода для привязки к названию песни соответсвующего пути
            for (int i = 0; i < song.Count; i++)
            {
                for (int j = 0; j < song.Count; j++)
                {
                    if (sortList[i].Title == song[j].Title)
                    {
                        sortList[i].Path = song[j].Path;
                    }
                }
            }
            return sortList;
        }
        public static string StringCut(this string playingItem)//L9-HW-Player-2/3.
        {
            
            int length = playingItem.Length;
            if (playingItem.Length > 10)
            {
                playingItem = playingItem.Remove(9, length - 9);
                playingItem = $"{playingItem}...";
                Console.WriteLine(playingItem);
            }
            else Console.WriteLine(playingItem);
            return playingItem;
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
