using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;


namespace AudioPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int min, max, total = 0;
            var player = new Player();
            //player._isPlaying = false; //недоступно для изменений
            //player.Volume = 500; недоступно для изменений
            var songs = CreateSongs(out min, out max, ref total);
            player.Songs = songs;
            Console.WriteLine($"Total Duration= {total}, Min Duration = {min}, Max Duration = {max}");
            while (true)
            {
                switch (ReadLine())
                {
                    case "up"://увеличение громкости на 1
                        {
                            player.VolumeUp();
                            break;
                        }

                    case "down"://уменьшение громности на 1
                        {
                            player.VolumeDown();
                            break;
                        }

                    case "play"://воспроизведение
                        {
                            player.Play();
                            break;
                        }
                    case "upstep"://увеличение громкости на определенное значение
                        {
                            player.VolumeChangeUp(0);
                            break;
                        }
                    case "downstep"://уменьшение громкости на определенное значение
                        {
                            player.VolumeChangeDown(0);
                            break;
                        }
                    case "lock"://блокировка плеера
                        {
                            player.Lock();
                            break;
                        }
                    case "unlock"://разблокировка плеера
                        {
                            player.UnLock();
                            break;
                        }

                    case "stop"://остановка плеера
                        {
                            player.Stop();
                            break;
                        }
                    case "start"://запуск плеера
                        {
                            player.Start();
                            break;
                        }
                    case "create default"://создание дефолтной песни
                        {
                            CreateSong();
                            break;
                        }
                    case "create named"://создание именованной песни
                        {
                            CreateSong("Anaconda");
                            break;
                        }
                    case "create song"://создание песни со всеми определенными параметрами
                        {
                            CreateSong("Toxicity", "SOAD");
                            break;
                        }
                    case "add song"://добавление одной песни методом параметра-списка
                        {
                            player.Add("Toxicity");
                            break;
                        }
                    case "add song2"://добавление двух песен методом параметра-списка
                        {
                            player.Add("Toxicity", "Anaconda");
                            break;
                        }
                    case "add song arr"://добавление массива песен методом параметра-списка
                        {
                            player.Add(new string[] { "Toxicity", "Anaconda", "Sweet Dreams", "Here I am" });
                            break;
                        }
                    case "add artist"://добавление артиста с определенным именем
                        {
                            AddArtist("SOAD"); 
                            break;
                        }
                    case "add artist default"://добавление артиста с дефолтным именем
                        {
                            AddArtist();
                            break;
                        }
                    case "add album"://добавление альбома с определенным именем
                        {
                            AddAlbum("Toxicity","2001");
                            break;
                        }
                    case "add album default"://добавление альбома с дефолтным именем
                        {
                            AddAlbum();
                            break;
                        }
                    case "add album2"://добавление альбома с вызовом параметров по имени
                        {
                            AddAlbum(year: "2001", name: "Toxicity");
                            break;
                        }
                }
            }
        }
        /* весь этот блок кода может быть заменен методом с параметрами по умолчанию
         * правило перегрузки работает: переименование каждого конструктора ничего не изменило
        public static object CreateSong()
        {
            Song defaultSong = new Song();
            Random rand = new Random();
            defaultSong.Title = "Unknown Song";
            defaultSong.Duration = rand.Next(3000);
            defaultSong.Artist = new Artist();
            Console.WriteLine(defaultSong.Title + "  " + defaultSong.Artist.Name + "  " + defaultSong.Duration);
            return defaultSong;
        }
        public static object CreateSong(string title)
        {
            Song defaultSong = new Song();
            Random rand = new Random();
            defaultSong.Title = title;
            defaultSong.Duration = rand.Next(3000);
            defaultSong.Artist = new Artist();
            Console.WriteLine(defaultSong.Title + "  " + defaultSong.Artist.Name + "  " + defaultSong.Duration);
            return defaultSong;
        }
        public static object CreateSong(string title, string artistName)
        {
            Song defaultSong = new Song();
            Random rand = new Random();
            defaultSong.Title = title;
            defaultSong.Duration = rand.Next(3000);
            defaultSong.Artist = new Artist();
            defaultSong.Artist.Name = artistName;
            Console.WriteLine(defaultSong.Title + "  " + defaultSong.Artist.Name + "  " + defaultSong.Duration);
            return defaultSong;
        }*/
        private static object CreateSong(string title= "Unknown Song", string artistName="Unknown Artist")
        {
            Song defaultSong = new Song();
            Random rand = new Random();
            defaultSong.Title = title;
            defaultSong.Duration = rand.Next(3000);
            defaultSong.Artist = new Artist();
            defaultSong.Artist.Name = artistName;
            Console.WriteLine(defaultSong.Title + "  " + defaultSong.Artist.Name + "  " + defaultSong.Duration);
            return defaultSong;
        }

        private static Song[] CreateSongs(out int min, out int max, ref int total)
        {
            Song[] songs = new Song[5];
            Random rand = new Random();
            int MinDuration = int.MaxValue, MaxDuration = int.MinValue, TotalDuration = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                var song1 = new Song();
                song1.Title = "Song " + i;
                song1.Duration = rand.Next(3000);
                song1.Artist = new Artist();
                songs[i] = song1;
                TotalDuration += song1.Duration;
                MinDuration = song1.Duration < MinDuration ? song1.Duration : MinDuration;
                MaxDuration = song1.Duration > MaxDuration ? song1.Duration : MaxDuration;
            }
            min = MinDuration;
            max = MaxDuration;
            total = TotalDuration;
            return songs;
        }
        private static object AddArtist(string name= "Unknown Artist")
        {
            Artist addArtist = new Artist();
            addArtist.Name = name;
            Console.WriteLine(name);
            //блок кода для выведения значения полей на консоль
            IEnumerable<FieldInfo> fields = addArtist.GetType().GetTypeInfo().DeclaredFields;
            Console.WriteLine("Значения полей:");
            foreach (var field in fields.Where(x => !x.IsStatic))
            {
                Console.WriteLine("{0}={1}", field.Name, field.GetValue(addArtist));
            }
            return addArtist;
        }
        private static object AddAlbum(string name = "Unknown Album", string year="-")
        {
            Album addAlbum = new Album();
            addAlbum.Name = name;
            addAlbum.Year = year;
            Console.WriteLine(name+" "+year);
            //блок кода для выведения значения полей на консоль
            IEnumerable<FieldInfo> fields = addAlbum.GetType().GetTypeInfo().DeclaredFields;
            Console.WriteLine("Значения полей:");
            foreach (var field in fields.Where(x => !x.IsStatic))
            {
                Console.WriteLine("{0}={1}", field.Name, field.GetValue(addAlbum));
            }
            return addAlbum;
        }
    }
}
