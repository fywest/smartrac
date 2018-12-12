using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderGui
{
    class Inf
    {
        string infPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.inf");
        string txtPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.txt");

        public string output_command;
        FileStream inf;
        StreamReader infRead;
        FileStream txtOut;
        StreamWriter txtWrite;

        public Inf()
        {

        }

        public string getContent(string commandName)
        {
            string temp="";
           
            inf = new FileStream(infPath, FileMode.Open, FileAccess.Read);
            infRead = new StreamReader(inf, System.Text.Encoding.Default);

            output_command ="";
            string s = infRead.ReadLine();
            bool done = false;
            while(s!=null)
            {
                if (s.Contains(commandName))
                {
                    s = infRead.ReadLine();
                    while (!s.Contains("$END$"))
                    {
                        output_command += s;
                        output_command += "\r";
                        temp += s;
                        temp += "\r\n";
                        s = infRead.ReadLine();

                        
                    }
                    done = true;
                }
                if(done)
                {
                    break;
                }
                s = infRead.ReadLine();
            }

            infRead.Close();
            inf.Close();
            return temp;           

        }

        public void saveCommand()
        {
            txtOut = new FileStream(txtPath, FileMode.Create, FileAccess.Write);
            txtWrite = new StreamWriter(txtOut, System.Text.Encoding.Default);
            txtWrite.WriteLine(output_command);
            txtWrite.Close();
            txtOut.Close();
        }

    }

    
}
