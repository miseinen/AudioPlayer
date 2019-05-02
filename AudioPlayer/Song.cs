using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class Song
    {
        public bool? Like { get; set; }
        public int Duration;
        public string Title;
        public string Path;
        public string Lyrics;
        public Artist Artist;
        public Album Album;
        public Band Band;
        public object Genre;
        public enum Genres//BL8-Player3/3.SongGenres.
        {
            Rock,
            Pop,
            Metalcore,
            Rapcore,
            Jazz,
            Synthwave
        }

        public void LikeSong()
        {
            Like = true;
        }

        public void DislikeSong()
        {
            Like = false;
        }

        public void ShowList(List<Song> song)//BL8-Player2/3.LikeDislike.
        {
            for (int i = 0; i < song.Count; i++)
            {
                if (song[i].Like == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{song[i].Title}, {song[i].Genre}");
                    Console.ResetColor();
                }
                else if (song[i].Like == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{song[i].Title}, {song[i].Genre}");
                    Console.ResetColor();
                }
                else Console.WriteLine($"{song[i].Title}, {song[i].Genre}");
            }
        }

        public void FilterByGenre(List<Song> song)//BL8-Player4/4.FilterByGenre.
        {
            List<Song> filtredList = new List<Song>();
            Console.Write("0-Rock,1-Pop,2-Metalcore,3-Rapcore,4-Jazz,5-Synthwave\n" +
                "Input literal fo select by genre:");
            int selectGenre = Convert.ToInt32(Console.ReadLine());
            var selectedSong = from item in song
                               where (int)item.Genre == selectGenre
                               select new { title = item.Title, duration=item.Duration, like=item.Like, genre=item.Genre};
            foreach(var item in selectedSong)
            {
                filtredList.Add(new Song() { Title = item.title, Duration=item.duration, Like=item.like,
                Genre=item.genre});
            }
            ShowList(filtredList);
        }
    }
}
