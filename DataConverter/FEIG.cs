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

        private static string b2s(byte inb)//244 (decimal to hex =F4)
        {
            string tmp = inb.ToString("X2");//F4
            return tmp;
        }

        public static string SendWriteMultiplePagesNdefCommand(byte startAddr, byte blockSize, string url)//4,4,url = "parley.mtag.io/nn6r8u"
        {
            string cmdString, str;
            int len;
 
            int NdefLen = NDEF.GetNdefLength(url, blockSize);//60
            hBlockNum = (byte)(NdefLen / blockSize);//15
            str = b2s(hComAddress) + b2s(hWriteIsoOpCode) + b2s(hWriteNdefOpCode) + b2s(hWriteMode)
                + b2s(startAddr) + b2s(hBlockNum) + b2s(blockSize);// + GetNdefLength(url);
            //   str = "00B0240A040F04"= 0+176+36+10+4+15+4
            len = 1 + str.Length / 2 + NdefLen + 2;//70 (decimal to hex = 46)
            str = len.ToString("X2") + str;//str = "4600B0240A040F04"
            cmdString = str + "(Data1)(CRC:CRC:0:-1)";//cmdString = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)"
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
            if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidAndCounterMirror) t = (byte)(196 + Ntag.nMirrorByte * 16);//244=196+3*16
            string tt = b2s(t);//F4
            string hmacString = cmdHmacMirrorString + "16" + b2s(Ntag.nMirrorPage) + "00" + b2s(t);//"6600B0240A161704(Data2)BD010007"+"16"+"17->11"+"00"+"F4"
            //hmacString = "6600B0240A161704(Data2)BD010007161100F4"
            if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidAndCounterMirror) ret = hmacString + "00000590(Data3)0000(Data4)(CRC:CRC:0:-1)";
            else ret = hmacString + "00000580(Data3)0000(Data4)(CRC:CRC:0:-1)";

            return ret; //ret = "6600B0240A161704(Data2)BD010007161100F400000590(Data3)0000(Data4)(CRC:CRC:0:-1)"
        }

       
                 
   }


}
