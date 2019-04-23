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
            var player = new Player();
            var songClass = new Song();
            List<Song> songList = new List<Song>();
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
                    case "add"://добавление коллекции песен
                        {
                            player.Add(songList);
                            break;
                        }
                    case "shuffle"://перемешивание коллекции песен
                        {
                            player.Shuffle(songList);
                            break;
                        }
                    case "sort"://сортировка коллекции песен
                        {
                            player.SortByTitle(songList);
                            break;
                        }
                    case "show"://отображение коллекции песен
                        {
                            songClass.ShowList(songList);
                            break;
                        }
                    case "filter"://фильтр коллекции песен
                        {
                            songClass.FilterByGenre(songList);
                            break;
                        }
                }
            }
        }
    }

}
