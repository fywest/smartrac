using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ReaderGui
{
    public partial class Form2 : Form
    {
        ReadFeig readFeig;
        Feig feig;
        string inipath;
        string infPath;

        List<string> str_commandContent = new List<string>();

        public Form2()
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Form1.iniPath))
            {
                inipath = Path.Combine(Application.StartupPath,"HF_reader_FEIG2_new.ini");
                infPath = inipath.Replace(".ini", ".inf");
                //Form1.iniPath = inipath;// @"C:\Users\fywes\git_fywest\smartrac\ReaderGui\bin\Debug\HF_reader_FEIG2_configuration.ini";
            }
            readFeig = new ReadFeig(inipath,infPath);
            
            InitListBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = Util.ListToStr(readFeig.ICsNameList);
            MessageBox.Show(str);
        }

        private void InitListBox1()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.BeginUpdate();
            //for (int x = 1; x <= 50; x++)
            //{
            foreach(var item in Util.ListToStrArray(readFeig.ModelList))
                listBox1.Items.Add(item);
            //}

            listBox1.EndUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            contentClear();
            string selectModel = listBox1.SelectedItem.ToString();

            this.feig=getSelectedReader(selectModel);

            //string[] str_lines=readFeig.ini.INIGetAllItems(feig.model+"_class");
            //string str_command= commandToStr(feig.command[0]);
            string str_commandList = commandListToStr(feig);
            textBox1.Text = Util.StrArrayToStr(feig.protocols,",")+"\r\n"+ Util.StrArrayToStr(feig.ICs,",") + "\r\n" + str_commandList;

            if(str_commandContent.Count == 1)
            {
                textBox2.Text = str_commandContent[0];
            }
           else if(str_commandContent.Count == 2)
            {
                textBox2.Text = str_commandContent[0];
                textBox3.Text = str_commandContent[1];
            }



            
        }

        private Feig getSelectedReader(string selectedModel)
        {
            Feig feig_temp = new Feig();
            foreach(Feig temp in readFeig.feigList)
            {
                if(string.Compare(temp.model,selectedModel)==0)
                {
                    feig_temp = temp;
                    return feig_temp;
                }
            }
            return null;
        }

        private string commandListToStr(Feig feig)
        {
            List<string> str_command=new List<string>();
            foreach(Command temp in feig.command)
            {
                str_command.Add(commandToStr(temp));
                if(temp.content.Contains("$FILE$"))
                {
                    string keyword = feig.model+ "-SetupCommands-" + temp.icName;
                    string str_content = readFeig.inf.getContent(keyword);
                    str_commandContent.Add(str_content);
                }
            }

            string str_commandList = string.Join(";", str_command.ToArray());
            return str_commandList;
        }
        private string commandToStr(Command command)
        {
            string[] str = new string[2];
            str[0] = command.icName;
            str[1] = command.content;
            return string.Join(":", str);
        }

        private void contentClear()
        {
            str_commandContent.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
