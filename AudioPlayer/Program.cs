using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;



namespace AudioPlayer
{
    public class Program
    {
        public static bool Statusplay;
        public static Skin SkinForRef;
        public static int VolumeForRef;
        public static bool IsLockForRef;
        public static bool IsPlayingForRef;
        public bool isLockForRef;
        static void Main(string[] args)
        {
            var totalskin = new TotalColorSkin();
            var songplayer = new SongPlayer();
            var songPlayer = new Song();
            GenericPlayer player=new GenericPlayer();
            List<Song> songList = new List<Song>();
            skinchange:
            WriteLine("Choose Skin\nclassic,color,total, crazy:");
            switch (ReadLine())//первым делом нужно выбрать скин иначе будет ошибка на null
            {
                case "classic":
                    {
                        player.Skin = new ClassicSkin();
                        SkinForRef = player.Skin;
                        player.Skin.NewScreen();
                        break;
                    }
                case "color":
                    {
                        player.Skin = new ColorSkin();
                        SkinForRef = player.Skin;
                        player.Skin.NewScreen();
                        break;
                    }
                case "total":
                    {
                        player.Skin = new TotalColorSkin();
                        SkinForRef = player.Skin;
                        player.Skin.NewScreen();
                        break;
                    }
                case "crazy":
                    {
                        player.Skin = new CrazyTotalColorSkin();
                        SkinForRef = player.Skin;
                        player.Skin.NewScreen();
                        break;
                    }
            }

            while (true)
            {
                
                switch (ReadLine())//LA8.Player2/2**. AsyncCommands
                {
                    case "up"://увеличение громкости на 1
                        {
                            if (!IsLockForRef)//запрет команд при заблокированном плеере
                            {
                                player.VolumeChangedEvent += (volume) =>
                                {
                                    VolumeForRef = volume;
                                    player.Skin.NewScreen();
                                };
                                player.VolumeUp();
                            }
                            break;
                        }

                    case "down"://уменьшение громности на 1
                        {
                            if (!IsLockForRef)
                            {
                                player.VolumeChangedEvent += (volume) =>
                                {
                                    VolumeForRef = volume;
                                    player.Skin.NewScreen();
                                };
                                player.VolumeDown();
                            }
                            break;
                        }

                    case "play"://воспроизведение
                        {
                            if (!IsLockForRef)
                            {
                                Statusplay = true;
                                songplayer.SongStartedEvent += (songlist) =>
                                {
                                    player.Skin.NewScreen();
                                };
                                songplayer.Play(songList);
                                songplayer.Dispose();
                            }
                            break;
                        }
                    
                    case "lock"://блокировка плеера
                        {
                            if (!IsLockForRef)
                            {
                                player.PlayerLockedEvent += (IsLock) =>
                                {
                                    IsLockForRef = IsLock;
                                    player.Skin.NewScreen();
                                };
                                player.Lock();
                            }
                            break;
                        }
                    case "unlock"://разблокировка плеера
                        {
                            player.PlayerUnlockedEvent += (IsLock) =>
                            {
                                IsLockForRef = IsLock;
                                player.Skin.NewScreen();
                            };
                            player.UnLock();
                            break;
                        }

                    case "stop"://остановка плеера
                        {
                            if (!IsLockForRef)
                            {
                                Statusplay = false;
                                player.PlayerStoppedEvent += (isPlaying) =>
                                {
                                    IsPlayingForRef = isPlaying;
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Cancelled");
                                };
                                player.Stop();
                            }
                            break;
                        }
                    case "start"://запуск плеера
                        {
                            if (!IsLockForRef)
                            {
                                player.PlayerStartedEvent += (isPlaying) =>
                                {
                                    IsPlayingForRef = isPlaying;
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Started");
                                };
                                player.Start();
                            }
                            break;
                        }
                        
                    case "shuffle"://перемешивание коллекции песен
                        {
                            if (!IsLockForRef)
                            {
                                songPlayer.SongsListChangedEvent += (song) =>
                                {
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Playlist changed");
                                };
                                songList = songPlayer.Shuffled(songList);
                            }
                            break;
                        }
                    case "sort"://сортировка коллекции песен
                        {
                            if (!IsLockForRef)
                            {
                                songPlayer.SongsListChangedEvent += (song) =>
                                {
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Playlist changed");
                                };
                                songList = songPlayer.Sort(songList);
                            }
                            break;
                        }
                    case "show"://отображение коллекции песен
                        {
                            if (!IsLockForRef)
                            {
                                player.Skin.NewScreen();
                                songPlayer.ShowList(songList);
                            }
                            break;
                        }
                    case "filter"://фильтр коллекции песен
                        {
                            if (!IsLockForRef)
                            {
                                songPlayer.SongsListChangedEvent += (song) =>
                                {
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Playlist changed");
                                };
                                songPlayer.FilterByGenre(songList);
                            }
                            break;
                        }
                    case "cut"://обрезка названия песни
                        {
                            if (!IsLockForRef)
                            {
                                player.Skin.NewScreen();
                                for (int i = 0; i < songList.Count; i++)
                                {
                                    songList[i].Title = songList[i].Title.StringCut();
                                    System.Threading.Thread.Sleep(songList[i].Duration);
                                }
                            }
                            break;
                        }
                    case "deconstruct"://деконструкция песни
                        {
                            if (!IsLockForRef)
                            {
                                songPlayer.GetSongData(songList);
                            }
                            break;
                        }
                    case "skin"://смена скина
                        {
                            if (!IsLockForRef)
                            {
                                goto skinchange;
                            }
                            break;
                        }
                    case "clear"://очищение плейлиста
                        {
                            if (!IsLockForRef)
                            {
                                songPlayer.SongsListChangedEvent += (song) =>
                                {
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Playlist changed");
                                };
                                songPlayer.Clear(songList);
                            }
                            break;
                        }
                    case "load"://загрузка песен из папки
                        {
                            if (!IsLockForRef)
                            {
                                songPlayer.SongsListChangedEvent += (song) =>
                                {
                                    player.Skin.NewScreen();
                                    player.Skin.Render("Playlist changed");
                                };
                                player.Skin.NewScreen();
                                songPlayer.Load(songList);
                            }
                            break;
                        }
                    case "save playlist"://сохранение плейлиста
                        {
                            if (!IsLockForRef)
                            {
                                player.Skin.NewScreen();
                                songplayer.SaveAsPlaylist(songList);
                                player.Skin.Render("New playlist was saved.");
                            }
                            break;
                        }
                    case "load playlist"://загрузка плейлиста
                        {
                            if (!IsLockForRef)
                            {
                                player.Skin.NewScreen();
                                songplayer.LoadPlaylist(songList);
                                player.Skin.Render("New playlist was loaded.");
                            }
                            break;
                        }
                    case "test"://сериализация объекта на консоль
                        {
                            player.Skin.NewScreen();
                            songPlayer.SerializedObject(songPlayer);
                            break;
                        }
                    case "test in file"://сериализация объекта в файл
                        {
                            player.Skin.NewScreen();
                            songPlayer.SerializedObjectInFile(songPlayer);
                            songPlayer.DeserializedObjectInFile(songPlayer);
                            break;
                        }
                }
            }
        }
    }
}
