using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
    public struct Ntag
    {
        /* applications
         * 1. URL only (no password) all memory locked
         * 2. URL + HMAC (1st memory RO, 2nd password), no counter
         * 3. URL + counter + 2B random + HMAC (1st memory RO, 2nd password)
         *      3.1 mirror page and byte need to be recalculated according to URL length
         */
        public enum MirrorConfMode
        {
            NoMirror = 0,
            UidMirror,
            CounterMirror,
            UidAndCounterMirror,
        }
        public enum LockMode
        {
            NoLock = 0,
            ReadOnlyAll,
            FirstRO_SecondHmacPW,
        }

       
        /* NTAG configuration bytes */

        // mirror
        public static MirrorConfMode nMirrorConf;
        public static int nMirrorOffset = 0;
        public static byte nMirrorByte = 0x00;
        public static byte nMirrorPage = 0x00;

        // password authentication
        public static int nAuth0 = 0xFF;
        public static int nProt = 0;
        public static string nPwd = "FFFFFFFF";
        public static string nPack = "0000";

        // configurations
        public static int nCfgLck = 0;
        public static int nNfcCntEn = 0;
        public static int nNfcCntPwdProt = 0;

        // locks
        public static LockMode nLockMode = LockMode.FirstRO_SecondHmacPW;
    }
}
