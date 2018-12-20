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
        string infPath;// = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.inf");
        string txtPath;// = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.txt");

        List<Command> commandList;

        public string output_command;
        FileStream inf;
        StreamReader infRead;
        FileStream txtOut;
        StreamWriter txtWrite;

        public Inf(string infpath)
        {
            infPath = infpath;
            commandList = new List<Command>();
            getCommandList();
            saveCommandList("temp.inf");//in debug folder
        }

        public void getCommandList()
        {
   

            Command command_tmp;
            inf = new FileStream(infPath, FileMode.Open, FileAccess.Read);
            infRead = new StreamReader(inf, System.Text.Encoding.Default);

            string s = infRead.ReadLine();
            int len;
            
            while (s != null)
            {
                
                len = s.Length;
                if (len > 0 && s.Contains("$FILE$"))//s[0].Equals('$')&&s[len-1].Equals('$'))
                {
                    command_tmp.icName = s.Substring(6,len-6);//remove $
                    s = infRead.ReadLine();
                    string lines = "";
                    while (!s.Contains("$END$"))
                    {
                        lines += s;
                        lines += "\r\n";

                        s = infRead.ReadLine();


                    }
                    command_tmp.content = lines;
                    commandList.Add(command_tmp);
                   
 
                }

                s = infRead.ReadLine();
            }

            infRead.Close();
            inf.Close();
            
        }

        public string getContentFromList(string commandKeyword)
        {
            foreach(var item in commandList)
            {
                if(item.icName.Contains(commandKeyword))
                {
                    return item.content;
                }
            }

            return null;
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

        public void saveCommand(Command command)
        {
            txtOut = new FileStream(txtPath, FileMode.Create, FileAccess.Write);
            txtWrite = new StreamWriter(txtOut, System.Text.Encoding.Default);
            txtWrite.WriteLine(command.icName);
            txtWrite.WriteLine(command.content);
            txtWrite.Close();
            txtOut.Close();
        }

        public void saveCommandExtentToCmdFile(Command command)
        {

            txtOut = new FileStream(infPath, FileMode.Append, FileAccess.Write);
            txtWrite = new StreamWriter(txtOut, System.Text.Encoding.Default);


            txtWrite.WriteLine("\n$FILE$" + command.icName);
            txtWrite.WriteLine(command.content);
            txtWrite.WriteLine("$END$\n");
            txtWrite.WriteLine();

            txtWrite.Close();
            txtOut.Close();
        }

        public void removeCommandFromCmdFile(Command command)
        {
            inf = new FileStream(infPath, FileMode.Open, FileAccess.Read);
            infRead = new StreamReader(inf, System.Text.Encoding.Default);

            string tempPath = infPath.Replace(".inf", ".tmp");
            txtOut = new FileStream(tempPath, FileMode.Create, FileAccess.Write);
            txtWrite = new StreamWriter(txtOut, System.Text.Encoding.Default);

            output_command = "";
            string s = infRead.ReadLine();
            bool found = false;
            while (s != null)
            {
                if (s.Contains(command.icName))
                {
                    found = true;
                    s = infRead.ReadLine();
                    continue;
                }
                if (found)
                {
                    if (s.Contains("$END$"))
                    {
                        found = false;
                    }
                    s = infRead.ReadLine();
                    continue;
                }

                output_command += s;
                output_command += "\r";

                s = infRead.ReadLine();

            }

            txtWrite.WriteLine(output_command);

            txtWrite.Close();
            txtOut.Close();

            infRead.Close();
            inf.Close();
            File.Delete(infPath);
            File.Move(tempPath, infPath);
        }

        public void saveCommandList(string tempPath)
        {
            
            string txtPath = Path.Combine(Application.StartupPath, tempPath);
            txtOut = new FileStream(txtPath, FileMode.Create, FileAccess.Write);
            txtWrite = new StreamWriter(txtOut, System.Text.Encoding.Default);
            foreach(Command command in commandList)
            {
                txtWrite.WriteLine("$FILE$"+command.icName);
                txtWrite.WriteLine(command.content);
            }
           
            txtWrite.Close();
            txtOut.Close();
        }

    }

    
}
