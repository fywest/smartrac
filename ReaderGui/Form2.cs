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
        string iniPath;
        string infPath;

        List<string> str_commandContent = new List<string>();

        public Form2()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Form1.iniPath))
            {
                iniPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_configuration_ver2.ini");
                infPath = iniPath.Replace(".ini", ".inf");
                //Form1.iniPath = inipath;// @"C:\Users\fywes\git_fywest\smartrac\ReaderGui\bin\Debug\HF_reader_FEIG2_configuration.ini";
            }
            else
            {
                iniPath = Form1.iniPath;
                infPath = Form1.infPath;
            }
            readFeig = new ReadFeig(iniPath,infPath);

            
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

            if(str_commandContent.Count >= 1)
            {
                textBox2.Text = str_commandContent[0];
            }
           if(str_commandContent.Count == 2)
            {
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

        private void button2_Click(object sender, EventArgs e)
        {
            testIni();
            //readFeig.ini.INIWriteValue("t1", "h1", "r1");
        }

        private void testIni()
        {
            string iniWritePath = Path.Combine(Application.StartupPath, "test.ini");
            //readFeig.ini.INIWriteValue("t1", "h1", "r1");

            string file = iniWritePath;
            Ini iniTest = new Ini(file);
            //写入/更新键值
            iniTest.INIWriteValue("Desktop", "Color", "Red");
            iniTest.INIWriteValue("Desktop", "Width", "3270");

            iniTest.INIWriteValue("Toolbar", "Items", "Save,Delete,Open");
            iniTest.INIWriteValue("Toolbar", "Dock", "True");

            //写入一批键值
            iniTest.INIWriteItems("Menu", "File=文件\0View=视图\0Edit=编辑");

            //获取文件中所有的节点
            string[] sections = iniTest.INIGetAllSectionNames();

            //获取指定节点中的所有项
            string[] items = iniTest.INIGetAllItems("Menu");

            //获取指定节点中所有的键
            string[] keys = iniTest.INIGetAllItemKeys("Menu");

            //获取指定KEY的值
            string value = iniTest.INIGetStringValue("Desktop", "color");

            //删除指定的KEY
            iniTest.INIDeleteKey("desktop", "color");

            //删除指定的节点
            iniTest.INIDeleteSection("desktop");

            //清空指定的节点
            iniTest.INIEmptySection("toolbar");
        }
    }
}
