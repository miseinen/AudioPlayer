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
                    case "u":
                        {
                            player.VolumeUp();
                        }
                        break;
                    case "d":
                        {
                            player.VolumeDown();
                        }
                        break;
                    case "p":
                        {
                            player.Play();
                        }
                        break;
                }
            }
        }
    }
}
