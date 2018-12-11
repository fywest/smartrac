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
        FileStream inf;
        StreamReader infRead;
        public Inf()
        {

        }

        public string getContent(string commandName)
        {
            string temp="";
            inf = new FileStream(infPath, FileMode.Open, FileAccess.Read);
            infRead = new StreamReader(inf, System.Text.Encoding.Default);

            int cnt = 0;
            string s = infRead.ReadLine();
            bool done = false;
            while(s!=null)
            {
                if (s.Contains(commandName))
                {
                    s = infRead.ReadLine();
                    while (!s.Contains("$END$"))
                    {
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
            }

            infRead.Close();
            inf.Close();
            return temp;

            

        }

    }

    
}
