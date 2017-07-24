using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = File.ReadAllBytes("nodes.dat");
            var binaryReader = new BinaryReader(new MemoryStream(bytes));

            bool doHaveVerifiedContacts = false;
            int validContacts = 0;
            uint numContacts = binaryReader.ReadUInt32();
            uint fileVersion = 0;
            if (numContacts == 0)
            {
                if (binaryReader.BaseStream.Length >= 8)
                {
                    fileVersion = binaryReader.ReadUInt32();
                    if (fileVersion == 3)
                    {
                        uint bootstrapEdition = binaryReader.ReadUInt32();
                        if (bootstrapEdition == 1)
                        {
                            // this is a special bootstrap-only nodes.dat, handle it in a separate reading function
                            //ReadBootstrapNodesDat(file);
                            binaryReader.Close();
                            return;
                        }
                    }
                    if (fileVersion >= 1 && fileVersion <= 3)
                    {
                        numContacts = binaryReader.ReadUInt32();
                    }
                }
            }
            else
            {
                // Don't read version 0 nodes.dat files, because they can't tell the kad version of the contacts stored.
                Console.WriteLine("Failed to read nodes.dat file - too old. This version (0) is not supported anymore.");
                numContacts = 0;
            }

            if (numContacts != 0 && numContacts * 25 <= (binaryReader.BaseStream.Length - binaryReader.BaseStream.Position))
            {
                for (uint i = 0; i < numContacts; i++)
                {
                    //CUInt128 id = binaryReader.ReadUInt128();
                    var id1 = binaryReader.ReadUInt64();
                    var id2 = binaryReader.ReadUInt64();
                    uint ip = binaryReader.ReadUInt32();
                    //var ip3 = ConvertToAddress(ip);
                    //Console.Write(ip3);
                    ushort udpPort = binaryReader.ReadUInt16();
                    ushort tcpPort = binaryReader.ReadUInt16();
                    byte contactVersion = 0;
                    contactVersion = binaryReader.ReadByte();
                    //CKadUDPKey kadUDPKey;
                    bool verified = false;
                    if (fileVersion >= 2)
                    {
                        //kadUDPKey.ReadFromFile(file);
                        verified = binaryReader.ReadByte() != 0;
                        if (verified)
                        {
                            doHaveVerifiedContacts = true;
                        }
                    }
                    // IP appears valid
                    //               if (contactVersion > 1)
                    //               {
                    //                   if (IsGoodIPPort(wxUINT32_SWAP_ALWAYS(ip), udpPort))
                    //                   {
                    //                       if (!theApp->ipfilter->IsFiltered(wxUINT32_SWAP_ALWAYS(ip)) &&
                    //                           !(udpPort == 53 && contactVersion <= 5 /*No DNS Port without encryption*/))
                    //                       {
                    //                           // This was not a dead contact, inc counter if add was successful
                    //                           if (AddUnfiltered(id, ip, udpPort, tcpPort, contactVersion, kadUDPKey, verified, false, false))
                    //                           {
                    //                               validContacts++;
                    //                           }
                    //                       }
                    //                   }
                    //               }
                    //               else
                    //               {
                    //                   DEBUG_ONLY(kad1Count++; )
                    //}
                }
            }












            string result = Encoding.Default.GetString(bytes);
            Console.WriteLine(result);
            File.WriteAllText("nodes.txt", result);
            Console.ReadKey();
        }

       
    }
}
