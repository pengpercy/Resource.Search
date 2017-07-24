using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search.Models
{
    public class Contact
    {
        public long Id { get; set; }
        public int IP { get; set; }
        public ushort UdpPort { get; set; }
        public ushort TcpPort { get; set; }
        public byte Version { get; set; }
    }
}
