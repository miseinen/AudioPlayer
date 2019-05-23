using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class GenericPlayer
    {
        public event Action<bool> PlayerStartedEvent;//A.L7.Player1/2. Events
        public event Action<bool> PlayerStoppedEvent;
        public event Action<int> VolumeChangedEvent;
        public event Action<bool> PlayerLockedEvent;
        public event Action<bool> PlayerUnlockedEvent;
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
        
        public int VolumeUp()
        {
            if (!IsLock)
            {
                VolumeChangedEvent?.Invoke(++Volume);
            }
            return Volume;
        }

        public int VolumeDown()
        {
            if (!IsLock)
            {
                VolumeChangedEvent?.Invoke(--Volume);
            }
            return Volume;
        }

        public bool Lock()
        {
            IsLock = true;
            PlayerLockedEvent?.Invoke(IsLock);
            return IsLock;
        }

        public bool UnLock()
        {
            IsLock = false;
            PlayerUnlockedEvent?.Invoke(IsLock);
            return IsLock;
        }

        public void Stop()
        {
            PlayerStoppedEvent?.Invoke(isPlaying);
            if (!IsLock)
            {
                SongPlayer.cancelplay.Cancel();
                SongPlayer.cancelplay.Dispose();
                isPlaying = false;
            }
        }

        public void Start()
        {
            if (!IsLock)
            {
                isPlaying = true;
                PlayerStartedEvent?.Invoke(isPlaying);
            }
        }
    }

    public abstract class Skin
    {
        public abstract void NewScreen();
        public abstract void Render(string text);
    }

    public class ClassicSkin : Skin//A.L7.Player2/2. Visualizer
    {
        public override void NewScreen()
        {
            Console.Clear();
            Program.SkinForRef.Render($"\nStatusBar: " +
                $"Lock: {Program.IsLockForRef}; Volume: {Program.VolumeForRef}\nPlay:{Program.Statusplay}\n" +
                $"\nCommandBar:skin,load,play,lock/unlock,\nstart/stop,save playlist, load playlist" +
                $"\nPlaylist Command:sort,shuffle,show,clear" +
                $"\nVolume Command: up,down\n");
        }
        public override void Render(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ColorSkin : Skin//A.L7.Player2/2. Visualizer
    {
        Random rand = new Random();
        public override void NewScreen()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            string c = new string('\u058D', 40);
            Program.SkinForRef.Render($"{c}\nStatusBar: " +
                $"Lock: {Program.IsLockForRef}; Volume: {Program.VolumeForRef};\nPlay:{Program.Statusplay}\n{c}" +
                $"\nCommandBar:skin,load,play,lock/unlock,\nstart/stop,save playlist, load playlist" +
                $"\nPlaylist Command:sort,shuffle,show,clear" +
                $"\nVolume Command: up,down\n{c}");
        }
        public override void Render(string text)
        {
            Console.ForegroundColor = (ConsoleColor)rand.Next(1, 16);
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class TotalColorSkin : Skin//A.L7.Player2/2. Visualizer
    {
        Random rand = new Random();
        public override void NewScreen()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            string c = new string('\u058D', 40);
            Program.SkinForRef.Render($"{c}\nStatusBar: " +
               $"Lock: {Program.IsLockForRef}; Volume: {Program.VolumeForRef};\nPlay:{Program.Statusplay}\n{c}" +
               $"\nCommandBar:skin,load,play,lock/unlock,\nstart/stop,save playlist, load playlist" +
               $"\nPlaylist Command:sort,shuffle,show,clear" +
               $"\nVolume Command: up,down\n{c}");
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
    public class CrazyTotalColorSkin : Skin//A.L7.Player2/2. Visualizer,LA8.Player2/2**. AsyncCommands
    { 
        Random rand = new Random();
        public override void NewScreen()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            string c = new string('\u058D', 40);
            Program.SkinForRef.Render($"{c}\nStatusBar: " +
               $"Lock: {Program.IsLockForRef}; Volume: {Program.VolumeForRef};\nPlay:{Program.Statusplay}\n{c}" +
               $"\nCommandBar:skin,load,play,lock/unlock,\nstart/stop,save playlist, load playlist" +
               $"\nPlaylist Command:sort,shuffle,show,clear" +
               $"\nVolume Command: up,down\n{c}");
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

