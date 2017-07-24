using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search
{
    public class PacketEnqueuer
    {
        Queue queue = new Queue();
        MemoryStream cache = new MemoryStream();
        public void Write(byte[] buffer)
        {
            Write(buffer, 0, buffer.Length);
        }
        public void Write(byte[] buffer, int offset, int size)
        {
            cache.Write(buffer, offset, size);

            while (true)
            {
                if (cache.Length < 5) break;
                byte[] cache_array = cache.GetBuffer();
                uint len = BitConverter.ToUInt32(cache_array, 1);
                len += 5;
                if (cache.Length < len) break;

                byte[] data = new byte[len];
                Buffer.BlockCopy(cache_array, 0, data, 0, (int)len);
                Packet item = new Packet();
                item.Unpack(data);
                queue.Enqueue(item);

                // new MemoryStream will help in GC
                var _cache = new MemoryStream();
                _cache.Write(cache_array, (int)len, (int)(cache.Length - len));
                cache = _cache;
            }
        }
        public uint Count
        {
            get
            {
                return (uint)queue.Count;
            }
        }
        public Packet Next()
        {
            if (queue.Count > 0)
            {
                return (Packet)queue.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}
