using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class GenericPlayer
    {
        public Skin Skin;
        private int volume;
        private const int maxVolume = 100;
        public int Volume
        {
            get
            {
                return volume;
            }
            private set
            {
                if (value > maxVolume)
                {
                    volume = maxVolume;
                }
                else if (value < 0)
                {
                    volume = 0;
                }
                else
                {
                    volume = value;
                }
            }
        }
        public bool IsLock;
        private bool isPlaying;
        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
        }

        public void VolumeUp()
        {
            Volume += 1;
            Skin.Render($"Volume was changed. Current Volume: {Volume}.");
        }

        public void VolumeDown()
        {
            Volume -= 1;
            Skin.Render($"Volume was changed. Current Volume: {Volume}.");
        }

        public void VolumeChangeUp(int step)
        {
            Skin.Render("Increase Volume. Input value: ");
            step = Convert.ToInt32(Console.ReadLine());
            Volume += step;
            Skin.Render($"Volume was changed. Current Volume: {Volume}.");
        }

        public void VolumeChangeDown(int step)
        {
            Skin.Render("Decrease Volume. Input value: ");
            step = Convert.ToInt32(Console.ReadLine());
            Volume -= step;
            Skin.Render($"Volume was changed.Current Volume: { Volume}.");
        }

        public void Lock()
        {
            IsLock = true;
            Skin.Render("Player is locked.");
        }

        public void UnLock()
        {
            IsLock = false;
            Skin.Render("Player is unloked.");
        }

        public void Stop()
        {
            if (!IsLock)
            {
                isPlaying = false;
                Skin.Render("Player is stopped.");
            }
        }

        public void Start()
        {
            if (!IsLock)
            {
                isPlaying = true;
                Skin.Render("Player is started.");
            }
        }
    }

    public abstract class Skin
    {
        public abstract void NewScreen();
        public abstract void Render(string text);
    }

    public class ClassicSkin : Skin
    {
        public override void NewScreen()
        {
            Console.Clear();
        }
        public override void Render(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ColorSkin : Skin//рандомным цветом каждая строка
    {
        Random rand = new Random();
        public override void NewScreen()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            string c = new string('\u058D', 30);
            Console.WriteLine(c);
        }
        public override void Render(string text)
        {
            Console.ForegroundColor = (ConsoleColor)rand.Next(1, 16);
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class TotalColorSkin : Skin//рандомным цветом каждый символ
    {
        Random rand = new Random();
        public override void NewScreen()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            string c = new string('\u058D', 30);
            Console.WriteLine(c);
        }
        public override void Render(string text)
        {
            Console.CursorVisible = false;
            foreach (char letter in text)
            {
                Console.ForegroundColor = (ConsoleColor)rand.Next(1, 15);
                Console.Write(letter);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    public class CrazyTotalColorSkin : Skin//мерцающим рандомным цветом каждый символ
    {                                      //но не работает со списком песен, показывает только одну строку
        Random rand = new Random();
        public override void NewScreen()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            string c = new string('\u058D', 30);
            Console.WriteLine(c);
        }
        public override void Render(string text)
        {
            Console.CursorVisible = false;
            while (!Console.KeyAvailable)//не знаю как настроить, чтобы и лист песен корректно выводило
            {
                foreach (char letter in text)
                {
                    Console.ForegroundColor = (ConsoleColor)rand.Next(1, 15);
                    Console.Write(letter);
                }
                Console.Write("\r");
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

