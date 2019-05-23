using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public interface IPlayingItem
    {
        string Title { get; set; }
        int Duration { get; set; }
        string Path { get; set; }
    }  
}

