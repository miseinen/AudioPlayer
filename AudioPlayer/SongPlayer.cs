using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace AudioPlayer
{
    public class SongPlayer : GenericPlayer, IDisposable
    {
        public event Action<List<Song>> SongStartedEvent;//A.L7.Player1/2
        public static CancellationTokenSource cancelplay = new CancellationTokenSource();
        CancellationToken token = cancelplay.Token;
        private System.Media.SoundPlayer _sp;
        private bool disposed = false;

        public async Task Play(List<Song> song)//LA8.Player1/2. AsyncPlaySong 
        {
            foreach (var item in song)
            {
                SongStartedEvent?.Invoke(song);
                if (token.IsCancellationRequested)//установка токена отмены
                {
                    break;
                }
                _sp = new System.Media.SoundPlayer(item.Path);
                Program.SkinForRef.Render(item.Title);
                await Task.Run(() => _sp.Load());
                await Task.Run(()=> _sp.PlaySync());
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
        public void Dispose()//AL4-Player1/1. IDisposable
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _sp = null;
                }
                disposed = true;
            }
        }
        ~SongPlayer()
        {
            Dispose(false);
        }
    }
}
