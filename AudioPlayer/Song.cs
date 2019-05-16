using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace AudioPlayer
{
    [Serializable]
    public class Song: PlayingItem
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
        GenericPlayer player = new GenericPlayer();

        public void Clear(List<Song>song)//AL6-Player1/2-AudioFiles.
        {
            for (int i = song.Count-1; i >= 0; i--)
            {
                song.RemoveAt(i);
            }
        }
        public void Load(List<Song> songList)//AL6-Player1/2-AudioFiles.
        {
            List<string> path = new List<string>();
            DirectoryInfo DirInfo = new DirectoryInfo(@"d:\Курсы\Song");
            var j = DirInfo.EnumerateFiles().Count();
            var songs = from wav in DirInfo.EnumerateFiles()
                        select wav;
            foreach (var wav in songs)
            {
                path.Add(wav.FullName);
            }
            for (int i = 0; i < path.Count; i++)
            {
                FileInfo songInfo = new FileInfo(path[i]);
                System.Media.SoundPlayer sp = new System.Media.
                SoundPlayer(path[i]);
                songList.Add(new Song() { Title = songInfo.Name, Path=songInfo.FullName });
            }
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
        /*
        public  void Add(List<Song> song)
        {
            song.Add(new Song() { Title = "Toxicity", Duration = 500, Like = null, Genre = Song.Genres.Rock });
            song.Add(new Song(){Title = "Nightcall",Duration = 300,Like = false, Genre = Song.Genres.Synthwave});
            song.Add(new Song() { Title = "What I've done", Duration = 900, Like = false, Genre = Song.Genres.Rock });
            song.Add(new Song() { Title = "Shout", Duration = 500, Like = true, Genre = Song.Genres.Metalcore });
            song.Add(new Song() { Title = "Aerials", Duration = 700, Like = true, Genre = Song.Genres.Rock });
            song.Add(new Song() { Title = "Pain", Duration = 900, Like = null, Genre = Song.Genres.Rock });
            song.Add(new Song() { Title = "Anaconda", Duration = 900, Like = false, Genre = Song.Genres.Pop });
        }
        */
        public void GetSongData(List<Song> song)//L9-HW-Player-3/3.
        {
            for (int i = 0; i < song.Count; i++)
            {
                (string title, int duration, _, bool? like, object genre, _, _) = song[i];
                Console.WriteLine($"Title={title}, Duration={duration}, Like={like}, Genre={genre}");
            }
        }
    }
}
