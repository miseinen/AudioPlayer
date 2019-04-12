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
            int min, max, total=0;
            var player = new Player();
            var songs = CreateSongs(out min, out max, ref total);
            player.Songs = songs;
            Console.WriteLine($"Total = {total}, Min = {min}, Max = {max}");
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

        private static Song[] CreateSongs(out int min, out int max, ref int total)
        {
            Song[] songs = new Song[5];
            Random rand = new Random();
            int MinDuration=int.MaxValue, MaxDuration=int.MinValue, TotalDuration=0;
            for (int i = 0; i < songs.Length; i++)
            {
                var song1 = new Song();
                song1.Title = "Song "+i;
                song1.Duration = rand.Next(3000);
                song1.Artist = new Artist();
                songs[i] = song1;
                TotalDuration += song1.Duration;
                MinDuration=song1.Duration < MinDuration ? song1.Duration : MinDuration;
                MaxDuration= song1.Duration > MaxDuration ? song1.Duration : MaxDuration;
            }
            min = MinDuration;
            max = MaxDuration;
            total = TotalDuration;
            return songs;
        }
    }
}
