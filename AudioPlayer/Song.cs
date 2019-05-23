using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace AudioPlayer
{
    [Serializable]
    public class Song: IPlayingItem
{
        public event Action<List<Song>> SongsListChangedEvent;//A.L7.Player1/2. Events
        public bool? Like { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
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

        public void Clear(List<Song>songList)//AL6-Player1/2-AudioFiles.
        {
            SongsListChangedEvent?.Invoke(songList);
            for (int i = songList.Count-1; i >= 0; i--)
            {
                songList.RemoveAt(i);
            }
        }

        public void Load(List<Song> songList)//AL6-Player1/2-AudioFiles.
        {
            Program.SkinForRef.Render("Input path of SongList: ");
            Path=Console.ReadLine();
            List<string> pathList = new List<string>();
            DirectoryInfo DirInfo = new DirectoryInfo(Path);
            var j = DirInfo.EnumerateFiles(".wav").Count();
            var songs = from wav in DirInfo.EnumerateFiles()
                        select wav;
            foreach (var wav in songs)
            {
                pathList.Add(wav.FullName);
            }
            for (int i = 0; i < pathList.Count; i++)
            {
                FileInfo songInfo = new FileInfo(pathList[i]);
                songList.Add(new Song() { Title = songInfo.Name, Path=songInfo.FullName });
            }
            SongsListChangedEvent?.Invoke(songList);
        }
        public List<Song> Sort(List<Song> songList)
        {
            SongsListChangedEvent?.Invoke(songList);
            songList=ExtensionClass.SortByTitle(songList);
            return songList;
        }
        public List<Song> Shuffled(List<Song> songList)
        {
            SongsListChangedEvent?.Invoke(songList);
            songList=ExtensionClass.Shuffle(songList);
            return songList;
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
                else Program.SkinForRef.Render($"{song[i].Title}, {song[i].Genre}");
            }
        }

        public void FilterByGenre(List<Song> songList)//BL8-Player4/4.FilterByGenre.
        {
            List<Song> filtredList = new List<Song>();
            Console.Write("0-Rock,1-Pop,2-Metalcore,3-Rapcore,4-Jazz,5-Synthwave\n" +
                "Input literal fo select by genre:");
            int selectGenre = Convert.ToInt32(Console.ReadLine());
            var selectedSong = from item in songList
                               where (int)item.Genre == selectGenre
                               select new { title = item.Title, duration=item.Duration, like=item.Like, genre=item.Genre};
            foreach(var item in selectedSong)
            {
                filtredList.Add(new Song() { Title = item.title, Duration=item.duration, Like=item.like,
                Genre=item.genre});
            }
            ShowList(filtredList);
            SongsListChangedEvent?.Invoke(songList);
        }
        
        public void GetSongData(List<Song> song)//L9-HW-Player-3/3.
        {
            for (int i = 0; i < song.Count; i++)
            {
                (string title, int duration, _, bool? like, object genre, _, _) = song[i];
                Program.SkinForRef.Render($"Title={title}, Duration={duration}, Like={like}, Genre={genre}");
            }
        }
        public void SerializedObject(Song test)//AL6-P6/7-ConsoleSrlz.
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Song));
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, test);
                formatter.Serialize(Console.Out, test);
                Console.WriteLine();
                ms.Position = 0;
                var result = (Song)formatter.Deserialize(ms);
                Console.WriteLine(result);
            }
        }
        
        public void SerializedObjectInFile(Song test)//AL6-P7/7-FileSrlz.
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Song));
            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test);
            }
        }
        public void DeserializedObjectInFile(Song test)//AL6-P7/7-FileSrlz.
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Song));
            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                test=(Song)formatter.Deserialize(fs);
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
    }
}
