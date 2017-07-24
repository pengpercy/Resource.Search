using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search
{
    public class Packet
    {
        public static byte[] TagEncode(byte tag, byte[] value)
        {
            return new byte[] { };
        }
        public static byte[] TagEncode(byte tag, string value)
        {
            return new byte[] { };
        }
        public static byte[] TagEncode(byte tag, uint value)
        {
            return new byte[] { };
        }
        public static byte[] TagEncode(byte tag, float value)
        {
            return new byte[] { };
        }
        public static byte[] PacketEncode(byte protocol, byte[] data)
        {
            return new byte[] { };
        }
        public byte[] Pack()
        {
            return new byte[] { };
        }
        public void Unpack(byte[] _data)
        { }
        public virtual void Generate()
        { throw new NotImplementedException(); }
        public virtual void Parse()
        { throw new NotImplementedException(); }
    }
}
