using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
   

    public class FEIG
    {
        /* */
        public static bool hConverted = false;

        /* FEIG protocol header */
        public static byte hCommandLen;
        public const byte hComAddress = 0;
        //public static byte hCommandByte;
        public static ushort hCRC16;
        
        /* Write command header */
        public static byte hWriteNdefLen;
        public const byte hWriteIsoOpCode = 0xB0;
        public const byte hWriteNdefOpCode = 0x24;
        public const byte hWriteMode = 0x0A; // selected
        public static byte hBlockAddress = 0x04; // start address
        public static byte hBlockNum = 0x04; // 4 Bytes / block
        public const byte hBlockSize = 0x04; // 1 block size

        public static string cmd1 = "";
        public static string cmd2 = "";

        private static string b2s(byte inb)
        {
            string tmp = inb.ToString("X2");
            return tmp;
        }

        public static string SendWriteMultiplePagesNdefCommand(byte startAddr, byte blockSize, string url)
        {
            string cmdString, str;
            int len;
 
            int NdefLen = NDEF.GetNdefLength(url, blockSize);
            hBlockNum = (byte)(NdefLen / blockSize);
            str = b2s(hComAddress) + b2s(hWriteIsoOpCode) + b2s(hWriteNdefOpCode) + b2s(hWriteMode)
                + b2s(startAddr) + b2s(hBlockNum) + b2s(blockSize);// + GetNdefLength(url);
            len = 1 + str.Length / 2 + NdefLen + 2;
            str = len.ToString("X2") + str;
            cmdString = str + "(Data1)(CRC:CRC:0:-1)";
            return cmdString;
        }

        public static string SendWriteMultiplePagesHmacCommand()
        {
            byte t=0;
            string ret = "";
            const string cmdHmacMirrorString   = "6600B0240A161704(Data2)BD010007";// 160A00F400000590(Data3)0000(Data4)(CRC:CRC:0:-1)";
            const string cmdHmacNoMirrorString = "6600B0240A161704(Data2)BD010007";// 1600000400000580(Data3)0000(Data4)(CRC:CRC:0:-1)";
            const string cmdUrlOnlyString      = "1600B0240A280304BDFFFFFFFF00000400000540(CRC: CRC:0:-1)";
            //if (Ntag.nLockMode)
            if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidAndCounterMirror) t = (byte)(196 + Ntag.nMirrorByte * 16);
            string tt = b2s(t);
            string hmacString = cmdHmacMirrorString + "16" + b2s(Ntag.nMirrorPage) + "00" + b2s(t);
            if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidAndCounterMirror) ret = hmacString + "00000590(Data3)0000(Data4)(CRC:CRC:0:-1)";
            else ret = hmacString + "00000580(Data3)0000(Data4)(CRC:CRC:0:-1)";

            return ret; 
        }

       
                 
   }


}
