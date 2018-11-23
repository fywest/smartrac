using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace DataConverter
{
    public class SWTEncoding 
    {
        /* SWT */
        public static bool cSwtRecipeCreation;
        public static int cReaderModel;

        /* Application modes */
        public static int cApplicationMode; // Predefined configuration: Counter solution, Fixed URL

        /* Parser */
        public static bool cParserFirstLineParsed;
        public static int cColumnToParse;
        public static UrlType cUrlType;
        public static NDEF.NdefRecordID cRecordType;

        public static bool b_uid_mirror, b_cnt_mirror, b_lock_control;

        public enum UrlType
        {
            StaticURL = 0,
            DynamicURL
           
        }

        public SWTEncoding()
        {
            // iniFile 2
            cParserFirstLineParsed = false;
        }

        public static string WriteHeader()
        {
            
            string ret = "Index;State;Batch-ID;TimeStamp";
            for (int i = 0; i < InitFile.out_columns; i++ )
            {
                ret += ";Data" + (i + 1).ToString() ;
            }
            InitFile.out_index = 0;
            return ret;
        }

        public static string PrepareHexData(string hex, bool padding)
        {
            string little_endian = null;
            int cnt = hex.Length;

            int len_idx = hex.Length;
            for (int i = 0; i < Math.Ceiling((double)hex.Length/8); i++)
            {
                for (int j = 3; j >= 0; j-- )
                {
                    int ind = 2*j+8*i;
                    if (ind+2<=hex.Length)
                    { 
                        little_endian += hex.Substring(ind, 2);
                    }
                    else if (padding) little_endian += "00";
                   
                }
            }
            return little_endian;
        }


        public static int SearchForURL(List<string> columns)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Contains("http") || columns[i].Contains("www"))
                {
                    cColumnToParse = i;
                    return i;
                }
            }
            return -1;
        }

        public static string GetRecordType(string column)//column = "https://parley.mtag.io/nn6r8u"
        {
            string ret="";

            if (column.Contains("http://www"))
            {
                cRecordType = NDEF.NdefRecordID.http_www;
                ret = column.Substring("http://www.".Length);
            }
            else if (column.Contains("https://www"))
            {
                cRecordType = NDEF.NdefRecordID.https_www;
                ret = column.Substring("https://www.".Length);
            }
            else if (column.Contains("http://"))
            {
                cRecordType = NDEF.NdefRecordID.http;
                ret = column.Substring("http://".Length);
            }
            else if (column.Contains("https://"))
            {
                cRecordType = NDEF.NdefRecordID.https;//cRecordType = https
                ret = column.Substring("https://".Length);//ret = "parley.mtag.io/nn6r8u"
            }
            else cRecordType = NDEF.NdefRecordID.Entire_URL;
            NDEF.ndefRecordId = cRecordType;//https;
            return ret;          
        }

        public static string Convert(string column, string refFile)////column = "https://parley.mtag.io/nn6r8u" refFile: = "20170123_SMT_mTAG_ID_10K_REF.csv"
        {
            string temp, ndef_h = "";
            string hmac, pass, crc_s;
            string sic = "";
            ushort crc;
            bool generate_ref = false;
           // string refFile = "";
            // Verify required argument
            if (column == null)
                throw new ArgumentNullException("columns");
            //refFile = "REF.csv";

            hmac = Utility.GetRandomHexNumber(32);//hmac = "662CC678FBA36DC7599ACB248DE3F9F6"
            pass = Utility.GetRandomHexNumber(8);//pass = "0BB496F3"
            column = GetRecordType(column);//column = "parley.mtag.io/nn6r8u"

            for (int i = 0; i < InitFile.in_columns; i++)//InitFile.in_columns = 5
            {
                if (InitFile.in_types[i] == "d")
                {
                    temp = System.Convert.ToInt32(column).ToString("X2");
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "s")
                {
                    
                    temp = "0336D101325504" + Utility.StringToHex(column) + Utility.StringToHex("?m=");
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "h")
                {
                    InitFile.converted_in_data.Add(column);
                }
                else if (InitFile.in_types[i] == "b49")
                {
                    InitFile.converted_in_data.Add("abC" + Utility.GetRandom49BNumber(9));
                }
                else if (InitFile.in_types[i] == "url")
                {
                    //temp = "0334D101305503" + StringToHex(columns[i].Substring(columns.IndexOf("//"))) + "FE";
                    temp = "031ED1011A5504" + Utility.StringToHex(column) + "FE";
                    InitFile.converted_in_data.Add(temp);

                    InitFile.converted_in_data.Add(hmac);
                    // h, password
                    InitFile.converted_in_data.Add(pass);
                    string cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                    string cmd2 = FEIG.SendWriteMultiplePagesHmacCommand();
                    // crc16, pack
                    crc = Utility.ComputeCRC16(Utility.StringToByteArray(hmac));
                    crc_s = crc.ToString("X4");
                    temp = Utility.LittleEndian(crc).ToString("X4");
                    InitFile.converted_in_data.Add(temp);
                    // h, authen
                    InitFile.converted_in_data.Add(pass);

                    InitFile.ref_data.Add(column);
                    InitFile.ref_data.Add(hmac);
                    InitFile.ref_data.Add(pass);
                    InitFile.ref_data.Add(crc_s);
                }
                else if (InitFile.in_types[i] == "url_fix2")
                {
                    temp = Utility.StringToHex(column.Substring(column.IndexOf("//"))) + Utility.StringToHex("/") + Utility.StringToHex(Utility.GetRandomHexNumber(4)) + "FE";
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "url_uid_counter")
                {
                    temp = Utility.StringToHex(column) + Utility.StringToHex("/") + Utility.AddZeroPadding(42) + "FE";
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "url_uid_counter_fix2")
                {
                    temp = "0334D101305504" + Utility.StringToHex(column) + Utility.StringToHex("/") + Utility.AddZeroPadding(42) + Utility.StringToHex(Utility.GetRandomHexNumber(4)) + "FE";
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "crc16")
                {
                    temp = Utility.LittleEndian(Utility.ComputeCRC16(Utility.StringToByteArray(column))).ToString("X4");
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "md5")
                {
                    temp = Utility.ComputeMD5(Utility.StringToByteArray(Utility.StringToHex(column)));
                    InitFile.converted_in_data.Add(temp);
                }
                else if (InitFile.in_types[i] == "standard")
                {
                    // url_uid_counter_fix2,h,h,crc16,h
                    // url
                    //temp = "0334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    generate_ref = true;
                    // for https://adidas.mtag.io/njw0jy
                    //temp = "0103A00C340334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    // for https://mtag.io/njw0jy
                    string ndef = "";

                    //ndef += PrepareNdefHeader(columns[i]);
                    //temp = "0103A00C34032DD101295504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    ndef_h = PrepareNdefHeader(column);
                    temp = ndef_h + Utility.StringToHex(column);

                    InitFile.converted_in_data.Add(temp);
                    if (!SWTEncoding.cParserFirstLineParsed)
                    {
                        FEIG.cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                        FEIG.cmd2 = FEIG.SendWriteMultiplePagesHmacCommand();

                    }

                    break;
                }
                // counter solution with 2B random suffix
                else if (InitFile.in_types[i] == "counter_solution")
                {
                    // url_uid_counter_fix2,h,h,crc16,h
                    // url
                    //temp = "0334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    generate_ref = true;
                    // for https://adidas.mtag.io/njw0jy
                    //temp = "0103A00C340334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    // for https://mtag.io/njw0jy
                    string ndef = "";

                    //ndef += PrepareNdefHeader(columns[i]);
                    //temp = "0103A00C34032DD101295504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    ndef_h = PrepareNdefHeader(column);//ndef = "0103A00C340334D101305504"
                    temp = ndef_h + Utility.StringToHex(column) + Utility.StringToHex("/") + Utility.AddZeroPadding(42) + Utility.StringToHex(Utility.GetRandomHexNumber(4)) + "FE";
                    //ndef_h = "0103A00C340334D101305504"+"2F"+"000000000000000000000000000000000000000000"+"CFD8"+"FE"
                    //temp temp = "0103A00C340334D1013055047061726C65792E6D7461672E696F2F6E6E367238752F00000000000000000000000000000000000000000043464438FE"
                    InitFile.converted_in_data.Add(temp);//temp = "0103A00C340334D1013055047061726C65792E6D7461672E696F2F6E6E367238752F00000000000000000000000000000000000000000035444133FE"
                    // h, hmac
                    InitFile.converted_in_data.Add(hmac);//hmac = "8CA73387DDAFC1BBB186E1FE2DDDC2D7"
                    // h, password
                    InitFile.converted_in_data.Add(pass);//pass = "44DC34BA"
                    if (!SWTEncoding.cParserFirstLineParsed)
                    {
                        FEIG.cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);//FEIG.cmd1 = "4600B0240A040F04(Data1)(CRC:CRC:0:-1)"
                        FEIG.cmd2 = FEIG.SendWriteMultiplePagesHmacCommand();//FEIG.cmd2 = ret = "6600B0240A161704(Data2)BD010007161100F400000590(Data3)0000(Data4)(CRC:CRC:0:-1)"

                    }
                        
                    // crc16, pack
                    crc = Utility.ComputeCRC16(Utility.StringToByteArray(hmac));//16105
                    crc_s = crc.ToString("X4");//crc_s = "3EE9" (decimal to hex)
                    temp = Utility.LittleEndian(crc).ToString("X4");//temp = "E93E" (decimal to hex for littleEndian)
                    InitFile.converted_in_data.Add(temp);//E93E
                    // h, authen
                    InitFile.converted_in_data.Add(pass);//pass = "44DC34BA"

                    InitFile.ref_data.Add(column);//column = "parley.mtag.io/nn6r8u"
                    InitFile.ref_data.Add(hmac);//hmac = "8CA73387DDAFC1BBB186E1FE2DDDC2D7"
                    InitFile.ref_data.Add(pass);//pass = "44DC34BA"
                    InitFile.ref_data.Add(crc_s);//crc_s = "3EE9"
                    break;
                }
                else if (InitFile.in_types[i] == "combo_normal")
                {
                    generate_ref = true;
                    // url_uid_counter_fix2,h,h,crc16,h
                    // url
                    //temp = "0334D101305504" + StringToHex(columns[i]) + StringToHex("/") + AddZeroPadding(42) + StringToHex(GetRandomHexNumber(4)) + "FE";
                    /////temp = "0103A00C340314D101105504" + StringToHex(column) + "FE";
                    //temp = "032CD101285504" + StringToHex(columns[i]) + "FE";
                    ndef_h = PrepareNdefHeader(column);
                    temp = ndef_h + Utility.StringToHex(column) + "FE";

                    InitFile.converted_in_data.Add(temp);
                    // h, hmac
                    InitFile.converted_in_data.Add(hmac);
                    // h, password
                    InitFile.converted_in_data.Add(pass);

                    if (!SWTEncoding.cParserFirstLineParsed)
                    {
                        FEIG.cmd1 = FEIG.SendWriteMultiplePagesNdefCommand(4, 4, column);
                     
                    }
                    // crc16, pack
                    crc = Utility.ComputeCRC16(Utility.StringToByteArray(hmac));
                    crc_s = crc.ToString("X4");
                    temp = Utility.LittleEndian(crc).ToString("X4");
                    InitFile.converted_in_data.Add(temp);
                    // h, authen
                    InitFile.converted_in_data.Add(pass);

                    InitFile.ref_data.Add(column);
                    InitFile.ref_data.Add(hmac);
                    InitFile.ref_data.Add(pass);
                    InitFile.ref_data.Add(crc_s);
                    break;
                }
                else if (InitFile.in_types[i] == "sic")
                {
                    sic = Utility.GetRandomHexNumber(8);
                    //generate_ref = true;
                    InitFile.converted_in_data.Add(sic);

                    InitFile.ref_data.Add(sic);
                    break;
                }
            }
            if (generate_ref == true)
            {
                string out_ref;
                out_ref = InitFile.ref_data[0] + "," + InitFile.ref_data[1] + "," + InitFile.ref_data[2] + "," + InitFile.ref_data[3];
                //out_ref = "parley.mtag.io/nn6r8u,8CA73387DDAFC1BBB186E1FE2DDDC2D7,44DC34BA,3EE9"
                if (!File.Exists(refFile))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(refFile))//refFile = "20170123_SMT_mTAG_ID_10K_REF.csv"
                    {
                        sw.WriteLine(out_ref);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(refFile))
                    {
                        sw.WriteLine(out_ref);
                    }

                }
                InitFile.ref_data.Clear();               

            }
            //ConvertFromDecimalToHex(columns);
            return ProcessCMD(InitFile.converted_in_data);
            //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000035000000FE334144;78C62C66C76DA3FB24CB9A59F6F9E38D;F396B40B;30BE;0BB496F3"
        }

        private static string b2s(byte inb)
        {
            string tmp = inb.ToString("X2");
            return tmp;
        }

        private static string PrepareNdefHeader(string url)//url = "parley.mtag.io/nn6r8u"
        {
            string ndef = "";
            string h = "";
            if (NDEF.nLockTlv) ndef += NDEF.sLockTlv;//ndef = "0103A00C34"
            NDEF.GetNdefRealLength(url);
                h = b2s(NDEF.ndefType) + b2s(NDEF.ndefSize) + b2s(NDEF.ndefOption) + b2s(NDEF.ndefTypeLen)
                 + b2s(NDEF.ndefPayloadLen) + b2s(NDEF.ndefRecordType) + b2s((byte)NDEF.ndefRecordId);
            //3+52+209+1+48+85+https=h = "0334D101305504"
            ndef = ndef + h;//ndef = "0103A00C340334D101305504"
            return ndef;
    }

        public static string ProcessCMD(List<string> columns)//ProcessCMD(InitFile.converted_in_data) (converted_in_data list)
        {
            int i, j;
            string tmp = "";
            string cmd_data = "";
            //string str_out_index = out_index.ToString();
            string str_out_status = InitFile.out_state.ToString();//0
            string str_out_batch_id = InitFile.out_batch_id.ToString();//
            string str_out_timestamp = InitFile.out_timestamp.ToString();//
            cmd_data = (++InitFile.out_index).ToString() + ";" + InitFile.out_state.ToString() + ";" + InitFile.out_batch_id.ToString() + ";" + InitFile.out_timestamp.ToString() + ";";
            //cmd_data = "1;0;;;"
            for (i = 0; i < InitFile.out_columns; i++)
            {
                for (j = 0; j < InitFile.out_data_index[i].Count; j++)
                {
                    tmp += columns[InitFile.out_data_index[i][j]];
                }
                //tmp = "0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446"
                if (InitFile.in_padding[i] == "y") tmp = PrepareHexData(tmp, true);
                //converted_out_data.Add(tmp);
                cmd_data += tmp;
                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446"
                if (i < InitFile.out_columns - 1) cmd_data += ";";
                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446;"
                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446;8733A78CBBC1AFDDFEE186B1D7C2DD2D"
                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446;8733A78CBBC1AFDDFEE186B1D7C2DD2D;BA34DC44"
                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446;8733A78CBBC1AFDDFEE186B1D7C2DD2D;BA34DC44;E93E;"
                //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446;8733A78CBBC1AFDDFEE186B1D7C2DD2D;BA34DC44;E93E;44DC34BA"
                tmp = "";

            }
            /*
            if (!FEIG.hConverted)
            {
                FEIG.SendWriteMultiplePagesCommand(4, 4, converted_out_data[0]);
                FEIG.hConverted = true;
            }*/
            InitFile.converted_in_data.Clear();
            return cmd_data;//cmd_data	"1;0;;;
            //cmd_data = "1;0;;;0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000043000000FE384446;8733A78CBBC1AFDDFEE186B1D7C2DD2D;BA34DC44;E93E;44DC34BA"

            //0CA00301D1340334045530016C7261706D2E79652E6761746E2F6F693872366E00002F750000000000000000000000000000000031000000FE364436;
            //B4F7F1F439DBEF8AC975A99F54603E0B;F7B7E17B;46B2;7BE1B7F7"

        }
    }
}