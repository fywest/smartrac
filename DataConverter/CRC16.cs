using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConverter
{
    class CRC16
    {
        static public ushort Compute(byte[] DATA)
        {
            ushort crc = 0xFFFF;
            int cnt = 10;
            for (int i = 0; i < DATA.Length; i++) // cnt = number of protocol bytes without CRC
            {
                crc ^= DATA[i];
                for (int j = 0; j < 8; j++)
                {
                    if (Convert.ToBoolean(crc & 0x0001))
                        crc = (ushort)((crc >> 1) ^ 0x8408);
                    //crc = (ushort)((crc >> 1) ^ 0x1021);
                    //crc = (ushort)((crc >> 1) ^ 0x8810);
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            return crc;
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "");
            hex = hex.Replace("$", "");
            if (hex.Length % 2 != 0) return null;
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static ushort LittleEndian(ushort inb)
        {
            byte[] b = new byte[2];
            b[0] = (byte)(((uint)inb >> 8) & 0xFF); ;
            b[1] = (byte)inb;
            return BitConverter.ToUInt16(b, 0);
        }
    }
}
