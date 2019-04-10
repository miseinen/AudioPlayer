using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace AudioPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var song1 = new Song();
            song1.Title = "Дым сигарет с ментолом";
            song1.Duration = 300;
            song1.Artist = new Artist()
            {
                Name = "Нэнси"
            };
            var song2 = new Song();
            song2.Title = "Anaconda";
            song1.Duration = 300;
            song1.Artist = new Artist()
            {
                Name = "Nicki Minaj"
            };
            var player = new Player();
            player.Songs = new[] { song1, song2 };
            while (true)
            {
                switch (ReadLine())
                {
                    case "up":
                        {
                            player.VolumeUp();
                            break;
                        }
                        
                    case "down":
                        {
                            player.VolumeDown();
                            break;
                        }
                        
                    case "play":
                        {
                            player.Play();
                            break;
                        }
                    case "upstep":
                        {
                            player.VolumeChangeUp(0);
                            break;
                        }
                    case "downstep":
                        {
                            player.VolumeChangeDown(0);
                            break;
                        }
                    case "lock":
                        {
                            player.Lock();
                            break;
                        }
                    case "unlock":
                        {
                            player.UnLock();
                            break;
                        }
                        
                    case "stop":
                        {
                            player.Stop();
                            break;
                        }
                    case "start":
                        {
                            player.Start();
                            break;
                        }
                }
            }
        }
    }
}
