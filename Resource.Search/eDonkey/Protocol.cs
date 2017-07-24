using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search
{
    public class Protocol
    {
        public const byte PR_ED2K = 0xE3;
        public const byte PR_EMULE = 0xC5;
        public const byte TT_STRING = 0x02;
        public const byte TT_UINT32 = 0x03;
        public const byte TT_FLOAT = 0x04;
        public const byte OP_LOGINREQUEST = 0x01;
        public const byte CT_NICK = 0x01;
        public const byte CT_VERSION = 0x11;
        public const byte CT_FLAGS = 0x20;
        public const byte CT_MULEVERSION = 0xFB;
    }
}
