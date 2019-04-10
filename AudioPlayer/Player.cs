using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {
        private int _volume;
        private const int _maxVolume=100;
        public int Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if (value > _maxVolume)
                {
                    _volume = _maxVolume;
                }
                else if (value < 0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }
            }
        }
        public bool IsLock;
        private bool _isPlaying;
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
        }
        public Song[] Songs;
        public void VolumeUp()
        {
            Volume += 1;
            Console.WriteLine($"Звук был увеличен. Уровень громкости: {Volume}.");
        }

        public void VolumeDown()
        {
            Volume -= 1;
            Console.WriteLine($"Звук был уменьшен. Уровень громкости: {Volume}.");
        }
        public void VolumeChangeUp(int step)
        {
            Console.Write("Введите число, на сколько необходимо увеличить громкость: ");
            step = Convert.ToInt32(Console.ReadLine());
            Volume += step;
            Console.WriteLine($"Звук был увеличен. Уровень громкости: {Volume}.");
        }
        public void VolumeChangeDown(int step)
        {
            Console.Write("Введите число, на сколько необходимо уменьшить громкость: ");
            step = Convert.ToInt32(Console.ReadLine());
            Volume -= step;
            Console.WriteLine($"Звук был уменьшен. Уровень громкости: {Volume}.");
        }
        public void Lock()
        {
            IsLock = true;
            Console.WriteLine("Плеер заблокирован.");
        }
        public void UnLock()
        {
            IsLock = false;
            Console.WriteLine("Плеер разблокирован.");
        }
        
        public void Stop()
        {
            if (!IsLock)
            {
                _isPlaying = false;
                Console.WriteLine("Плеер остановлен.");
            }
        }
        public void Start()
        {
            if (!IsLock)
            {
                _isPlaying = true;
                Console.WriteLine("Плеер запущен.");
            }
        }
        
        public void Play()
        {
            if (_isPlaying)
            {
                for (int i = 0; i < Songs.Length; i++)
                {
                    Console.WriteLine(Songs[i].Title);
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }
    }
}
