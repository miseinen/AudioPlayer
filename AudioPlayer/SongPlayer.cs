using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace AudioPlayer
{
    public class SongPlayer : GenericPlayer
    {
        public  void Play(List<Song> song) 
        {
            for (int i = 0; i < song.Count; i++)
            {
                System.Media.SoundPlayer sp = new System.Media.
                SoundPlayer(song[i].Path);
                Console.WriteLine(song[i].Title);
                sp.Load();
                sp.PlaySync();
            }
        }
        public void SaveAsPlaylist(List<Song>songList)//AL6-Player2/2-PlaylistSrlz.
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));
            using (FileStream fs = new FileStream("songs.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, songList);
            }
        }
        public void LoadPlaylist(List<Song> songList)//AL6-Player2/2-PlaylistSrlz.
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Song>));
            using (FileStream fs = new FileStream("songs.xml", FileMode.OpenOrCreate))
            {
                songList = (List<Song>)formatter.Deserialize(fs);
            }
        }
    }
}
