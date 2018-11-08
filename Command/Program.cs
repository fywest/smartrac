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
            //byte byte_x = 0x00000001;

            Console.WriteLine("Test command input parameter:".ToUpper());
            Console.WriteLine($"str_url: {url}\n" +
                $"secureMode: {secureMode}\n" +
                $"icType: {icType}\n" +
                $"lockStatus: {lockStatus}\n" +
                $"mirrorConf: {mirrorConf}\n" +
                $"uidMirrorFromIC: {uidMirrorFromIC}\n" +
                $"keySource: {keySource}\n" +
                $"key: {key}\n");
           // Console.WriteLine(byte_x);
            //Console.WriteLine("0x{0:x}", byte_x);

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

            foreach(var command in lines)
            {

                string[] parts = command.Split('|', '#');
                int i = 0;
                Console.WriteLine("test command:".ToUpper());
                foreach (var s in parts)
                {
                    i++;
                    if (i == 10)
                    {
                        Console.WriteLine($"Description: <{s}>");
                    }
                    else
                    {
                        Console.WriteLine($"Part[{i}]: <{s}>");
                    }

                }
                Console.WriteLine();

            }


        }

        //public static byte[] String2ByteArray(string str)
        //{
        //    char[] chars = str.ToArray();
        //    byte[] bytes = new byte[chars.Length * 2];

        //    for (int i = 0; i < chars.Length; i++)
        //        Array.Copy(BitConverter.GetBytes(chars[i]), 0, bytes, i * 2, 2);

        //    return bytes;
        //}

        //public static string ByteArray2String(byte[] bytes)
        //{
        //    char[] chars = new char[bytes.Length / 2];

        //    for (int i = 0; i < chars.Length; i++)
        //        chars[i] = BitConverter.ToChar(bytes, i * 2);

        //    return new string(chars);
        //}

        static void strByte()
        {
            string str = "hello";
            byte[] data_byte;
            //data_byte=String2ByteArray(str);
            //Console.WriteLine(data_byte[0].ToString());
            byte[] data_byte_unicode = Encoding.Unicode.GetBytes(str);
            int length_data_byte_unicode = data_byte_unicode.Length;
            byte[] data_byte_utf8 = Encoding.UTF8.GetBytes(str);
            int length_data_byte_utf8 = data_byte_utf8.Length;
            byte[] data_byte_utf32 = Encoding.UTF32.GetBytes(str);
            int length_data_byte_utf32 = data_byte_utf32.Length;
            //Console.WriteLine("binary : {0}", data_byte[0]);

            string str_from_byte_utf8 = Encoding.UTF8.GetString(data_byte_utf8);
            Console.WriteLine($"\n{str_from_byte_utf8}");
            str_from_byte_utf8 = Encoding.Unicode.GetString(data_byte_utf8);
            Console.WriteLine($"{str_from_byte_utf8}");
            str_from_byte_utf8 = Encoding.UTF32.GetString(data_byte_utf8);
            Console.WriteLine($"{str_from_byte_utf8}");

            string str_from_byte_unicode = Encoding.UTF8.GetString(data_byte_unicode);
            Console.WriteLine($"\n{str_from_byte_unicode}");
            str_from_byte_unicode = Encoding.Unicode.GetString(data_byte_unicode);
            Console.WriteLine($"{str_from_byte_unicode}");
            str_from_byte_unicode = Encoding.UTF32.GetString(data_byte_unicode);
            Console.WriteLine($"{str_from_byte_unicode}");

            string str_from_byte_utf32 = Encoding.UTF8.GetString(data_byte_utf32);
            Console.WriteLine($"\n{str_from_byte_utf32}");
            str_from_byte_utf32 = Encoding.Unicode.GetString(data_byte_utf32);
            Console.WriteLine($"{str_from_byte_utf32}");
            str_from_byte_utf32 = Encoding.UTF32.GetString(data_byte_utf32);
            Console.WriteLine($"{str_from_byte_utf32}");


            //Console.WriteLine("hex : 0x{0:x}", data_byte[0]);

            Console.WriteLine($" \nbyte.max:{byte.MaxValue}  char.max:{(int)char.MaxValue}");

            Console.WriteLine($"{System.Text.Encoding.Default.ToString()}");

        }

        static void byteCharBitwise()
        {

            byte[] byte_1 = { 0x31, 0x32, 0x33, 0x34 };//1,2,3,4
            char[] chars_1 = new char[4];
            chars_1[0] = (char)0b00110000;//(char)0x0030;//'0';
            chars_1[1] = '1';
            chars_1[2] = '2';
            chars_1[3] = '3';
            byte byte_2 = (byte)chars_1[3];
            Console.WriteLine($"byte maxvalue:{byte.MaxValue} \n" +
                $"char maxvalue:{(int)char.MaxValue} \n" +
                $"chars_1 length:{chars_1.Length} \n" +
                $"utf8 byte count:{Encoding.UTF8.GetByteCount(chars_1) } \n" +
                $"size of char:{sizeof(char)} \n" +
                $"size of byte:{sizeof(byte)}");

            Console.WriteLine($"{Convert.ToString(byte_2, 2)}");
            Console.WriteLine("{0}", Convert.ToString(byte_2, 2).PadLeft(8, '0'));

            Console.WriteLine($"{Encoding.ASCII.GetString(byte_1)}");

            byte byte_3 = 0b0101_0101;
            byte byte_4 = 0b1010_1010;
            byte byte_and = (byte)(byte_3 & byte_4);
            byte byte_or = (byte)(byte_3 | byte_4);
            byte byte_not = (byte)(byte_3 ^ byte_4);

            Console.WriteLine("{0}", Convert.ToString(byte_and, 2).PadLeft(8, '0'));
            Console.WriteLine("{0}", Convert.ToString(byte_or, 2).PadLeft(8, '0'));
            Console.WriteLine("{0}", Convert.ToString(byte_not, 2).PadLeft(8, '0'));

        }

        static void encode_utf8_MS()
        {
            // Create a character array.
            string gkNumber = Char.ConvertFromUtf32(0x10154);
            char[] chars = new char[] { 'z', 'a', '\u0306', '\u01FD', '\u03B2',
                                  gkNumber[0], gkNumber[1] };

            // Get UTF-8 and UTF-16 encoders.
            Encoding utf8 = Encoding.UTF8;
            Encoding utf16 = Encoding.Unicode;

            // Display the original characters' code units.
            Console.WriteLine("Original UTF-16 code units:");
            byte[] utf16Bytes = utf16.GetBytes(chars);
            foreach (var utf16Byte in utf16Bytes)
                Console.Write("{0:X2} ", utf16Byte);
            Console.WriteLine();

            // Display the number of bytes required to encode the array.
            int reqBytes = utf8.GetByteCount(chars);
            Console.WriteLine("\nExact number of bytes required: {0}",
                          reqBytes);

            // Display the maximum byte count.
            int maxBytes = utf8.GetMaxByteCount(chars.Length);
            Console.WriteLine("Maximum number of bytes required: {0}\n",
                              maxBytes);

            // Encode the array of chars.
            byte[] utf8Bytes = utf8.GetBytes(chars);

            // Display all the UTF-8-encoded bytes.
            Console.WriteLine("UTF-8-encoded code units:");
            foreach (var utf8Byte in utf8Bytes)
                Console.Write("{0:X2} ", utf8Byte);
            Console.WriteLine();
        }

        static void byte_unicode_ascii()
        {
            string unicodeString = "This string contains the unicode character Pi (\u03a0)";

            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("Ascii converted string: {0}", asciiString);
        }
        static void Main(string[] args)
        {
            //test();// byte ,hex ,ascii
            //write_url();
            //testComand();
            //strByte();//byte char string
            //byteCharBitwise();//byte and or not byte char
            //encode_utf8_MS();//Encoding.UTF8 Property
            byte_unicode_ascii();//encoding unicode ascii

            Console.ReadKey();
        }
    }
}
