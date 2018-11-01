using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Command
{

    class Program
    {
        enum LockStatus { Local_all,Local_one,local_none};
        enum MirrorConf { UID,COUNTER,SIGNATURE};

        static void write_url()
        {
            string url = "https://example.com?id={14B-UID}&sig={16B-SIGNATURE}";
            bool secureMode = true;
            string icType = "SIC43NT";
            LockStatus lockStatus = LockStatus.Local_all;
            MirrorConf mirrorConf = MirrorConf.UID;
            bool uidMirrorFromIC = false;
            string keySource = "File";
            string key = null;
            byte byte_x = 0x00000001;

            Console.WriteLine($"str_url: {url}\n" +
                $"secureMode: {secureMode}\n" +
                $"icType: {icType}\n" +
                $"lockStatus: {lockStatus}\n" +
                $"mirrorConf: {mirrorConf}\n" +
                $"uidMirrorFromIC: {uidMirrorFromIC}\n" +
                $"keySource: {keySource}\n" +
                $"key: {key}\n");
            Console.WriteLine(byte_x);
            Console.WriteLine("0x{0:x}", byte_x);

        }



        public static string HexStringToASCII(string hexstring)
        {
            byte[] bt = HexStringToBinary(hexstring);
            string lin = "";
            for (int i = 0; i < bt.Length; i++)
            {
                lin = lin + bt[i] + " ";
            }


            string[] ss = lin.Trim().Split(new char[] { ' ' });
            char[] c = new char[ss.Length];
            int a;
            for (int i = 0; i < c.Length; i++)
            {
                a = Convert.ToInt32(ss[i]);
                c[i] = Convert.ToChar(a);
            }

            string b = new string(c);
            return b;
        }

        public static byte[] HexStringToBinary(string hexstring)
        {

            string[] tmpary = hexstring.Trim().Split(' ');
            byte[] buff = new byte[tmpary.Length];
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = Convert.ToByte(tmpary[i], 16);
            }
            return buff;
        }

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        static void test()
        {
            byte byteValue1 = 201;
            Console.WriteLine(byteValue1);

            byte byteValue2 = 0x00C9;
            Console.WriteLine(byteValue2);

            byte byteValue3 = 0b1100_1001;
            Console.WriteLine(byteValue3);

            //byte byte_sum = 0x00000001 || 0x00000010 || 0x00000100;
            ushort byte_001 = 0b0000_0001;
            ushort byte_010 = 0b0000_0010;
            ushort byte_100 = 0b0000_0100;
            ushort byte_or = (ushort)(byte_001 | byte_010 | byte_100);//byte_001 | byte_010 | byte_100;
            Console.WriteLine("hex : 0x{0:x}", byte_001 | byte_010 | byte_100);
            string binaryData = Convert.ToString(byte_or, 2);
            Console.WriteLine("binary : {0}", binaryData);

            string HexString = "68 6f 77 20 61 72 65 20 79 6f 75";
            string AsciiString = "how are you";
            string cmdString = "3A00B02402040C040CA00301D13A0334045536016E662E723F6F692E";
            Console.WriteLine(HexStringToASCII(HexString));
            //remove space from string
            string HexString_nospace = Regex.Replace(HexString, @"\s", ""); ;
            Console.WriteLine(HexString_nospace);
            Console.WriteLine(ConvertHex(HexString_nospace));
            Console.WriteLine(ConvertHex(cmdString));

        }

        static void testComand()
        {
            string[] lines = {
                "3A00B02402040C040CA00301D13A0334045536016E662E723F6F692E(8:28:1:A)3D6469 (8:24:1:A)(8:27:1:A)(8:26:1:A)(8:29:1:A)(8:20:1:A)(8:23:1:A)(8:22:1:A)(8:25:1:A)(8:16:1:A)(8:19:1:A)(8:18:1:A)(8:21:1:A)747426(8:17:1:A) 7326313D 003D6769(CRC:CRC:0:-1)|0600B000D572|165|0|0|1|WriteNDEF(0:)CharFilter(0:86)(0:6:0:1)|1|ReadNDEF(0:0)",
                "1600B024022D0304(Data1)0000(CRC:CRC:0:-1)|0600B000D572|50|0|0|0|TAG_SIGN_auth(0:0)CharFilter(0:20)(0:0:0:1)|1|rx(0:0)	# Write 10 byte key",
                "1200B02402290204 FF0F4130 D8184140(CRC:CRC:0:-1)|0600B000D572|40|0|0|1|config(0:0)|1|rx(0:0)	# Lock configuration",
                "0E00B024020301040F000000(CRC:CRC:0:-1)|0600B000D572|30|0|0|1|config(0:0)|1|rx(0:0)	# Set CC to read-only ",
                "0E00B02402020104FFFF0000(CRC:CRC:0:-1)|0600B000D572|30|0|0|1|config(0:0)|1|rx(0:0)	# Static lock page 0-15",
                "0E00B02402280104BD3FCFFF(CRC:CRC:0:-1)|0600B000D572|30|0|0|1|config(0:0)|1|rx(0:0)	# Dynamic lock page 16-23"
            };

            string[] parts = lines[5].Split('|','#');
            int i = 0;
            foreach(var s in parts)
            {
                i++;
                if(i==10)
                {
                    Console.WriteLine($"Description: <{s}>");
                }
                else
                {
                    Console.WriteLine($"Part[{i}]: <{s}>");
                }
                
            }

        }
        static void Main(string[] args)
        {
            //test();// byte ,hex ,ascii
            write_url();
            testComand();


        }
    }
}
