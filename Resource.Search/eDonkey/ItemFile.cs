using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search
{
    public class ItemFile
    {
        public byte[] hash;
        public ItemClient[] clients;
    }
    public class ItemClient
    {
        public uint id;
        public TcpClient tcpclient;
        public UdpClient udpclient;
        public PacketEnqueuer queue;
        public ItemFile[] files;
    }
    //Dictionary<byte[], ItemFile> files;
    //Queue<ItemClient> clients;
}
