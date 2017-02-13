using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Streamer
    {
        public ushort Id { get; set; }
        public User User { get; set; }
        public ushort Level { get; set; }
        public ushort Health { get; set; }
    }
}
