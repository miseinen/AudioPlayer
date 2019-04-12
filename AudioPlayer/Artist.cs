using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Artist
    {
        public string Name;
        public Artist()
        {
            this.Name = "Unknown_Artist";
        }
        public Artist(string name)
        {
            this.Name =name;
        }
        public string Nickname;
        public string Country;
        public Album[] Albums;
        public Band Band;
        public Song[] Songs;
    }
}
