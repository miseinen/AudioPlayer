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
            var totalskin = new TotalColorSkin();
            var player = new Player();
            var songClass = new Song();
            List<Song> songList = new List<Song>();
            skinchange:
            WriteLine("Choose Skin\nclassic,color,total, crazy:");
            switch (ReadLine())//первым делом нужно выбрать скин иначе будет ошибка на null
            {
                case "classic":
                    {
                        player.Skin = new ClassicSkin();
                        player.Skin.Render("Skin was changed.");
                        break;
                    }
                case "color":
                    {
                        player.Skin = new ColorSkin();
                        player.Skin.Render("Skin was changed.");
                        break;
                    }
                case "total":
                    {
                        player.Skin = new TotalColorSkin();
                        player.Skin.Render("Skin was changed.");
                        break;
                    }
                case "crazy":
                    {
                        player.Skin = new CrazyTotalColorSkin();
                        player.Skin.Render("Skin was changed.");
                        break;
                    }
            }

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
                            player.Skin.NewScreen();
                            player.Play(songList);
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
                            player.Skin.NewScreen();
                            player.Add(songList);
                            break;
                        }
                    case "shuffle"://перемешивание коллекции песен
                        {
                            player.Skin.NewScreen();
                            songList=songList.Shuffle();
                            break;
                        }
                    case "sort"://сортировка коллекции песен
                        {
                            player.Skin.NewScreen();
                            songList =songList.SortByTitle();
                            break;
                        }
                    case "show"://отображение коллекции песен
                        {
                            player.Skin.NewScreen();
                            songClass.ShowList(songList);
                            break;
                        }
                    case "filter"://фильтр коллекции песен
                        {
                            player.Skin.NewScreen();
                            songClass.FilterByGenre(songList);
                            break;
                        }
                    case "cut"://обрезка названия песни
                        {
                            player.Skin.NewScreen();
                            var cutTitle=
                            from item in songList
                            select item.Title;
                            foreach (var item in songList)
                            {
                                item.Title.StringCut();
                            }
                            break;
                        }
                    case "deconstruct"://деконструкция песни
                        { 
                            player.GetSongData(songList);
                            break;
                        }
                    case "skin"://смена скина
                        {
                            goto skinchange;
                        }
                }
            }
        }
    }

}
