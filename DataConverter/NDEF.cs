using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
    public class NDEF
    {
        public enum NdefRecordID
        {
            Entire_URL = 0,
            http_www = 1,
            https_www = 2,
            http = 3,
            https = 4,
        }
        public static bool nLockTlv;
        public const string sLockTlv = "0103A00C34";

        /* NDEF header 03 13 D1 01 0F 55 04 */
        public const byte ndefType = 0x03;
        public static byte ndefSize = 0x00;
        public const byte ndefOption = 0xD1;
        public const byte ndefTypeLen = 0x01;
        public static byte ndefPayloadLen = 0x00;
        public const byte ndefRecordType = 0x55;
        public static NdefRecordID ndefRecordId;
        public static bool ndef2BSuffix;

        public static int GetNdefLength(string url, byte blockSize)
        {
            int len = 0;

            if (NDEF.nLockTlv) len += 5;
            len += 7; // NDEF header length
            len += url.Length;

            if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidAndCounterMirror) len += 21;
            else if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidMirror) len += 14;
            else if (Ntag.nMirrorConf == Ntag.MirrorConfMode.CounterMirror) len += 6;

            if (Ntag.nMirrorConf != Ntag.MirrorConfMode.NoMirror)
            {
                len += 1; //  plus / length
                Ntag.nMirrorOffset = len;
                Ntag.nMirrorPage = (byte)(len / blockSize + 4);
                Ntag.nMirrorByte = (byte)(len % blockSize);

            }


            if (NDEF.ndef2BSuffix) len += 4; // random numbers
            len += 1; // FE

            int mo = blockSize - (len % blockSize); // fill the block
            if (mo < blockSize) len += mo;
            return len;
        }

        public static int GetNdefRealLength(string url)
        {
            ndefPayloadLen = (byte)(url.Length);
            if (Ntag.nMirrorConf != Ntag.MirrorConfMode.NoMirror)
            {
                ndefPayloadLen++;
            }
                if (Ntag.nMirrorConf == Ntag.MirrorConfMode.UidAndCounterMirror) ndefPayloadLen += 25;
            ndefPayloadLen += 1; //FE
            ndefSize = (byte)(ndefPayloadLen + 4);
            return ndefPayloadLen;
        }
    }
}
