using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Viewer
    {
        public ushort Id { get; set; }
        public User User { get; set; }
        public Streamer Streamer { get; set; }
        public ushort ChatLevel { get; set; }
    }
}
