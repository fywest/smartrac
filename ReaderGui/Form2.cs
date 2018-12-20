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

        string str_conf_section;
        string str_conf_protocols;
        string str_conf_ICs;
        string str_conf_command;
        List<string> str_commandContent = new List<string>();
        List<string> str_commandKeywords = new List<string>();


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
            

            textBox6.Text = selectModel;
            str_conf_section = selectModel;

            textBox1.Text = Util.StrArrayToStr(feig.protocols, ",");
            str_conf_protocols= Util.StrArrayToStr(feig.protocols, ",");

            textBox4.Text = Util.StrArrayToStr(feig.ICs, ",");
            str_conf_ICs= Util.StrArrayToStr(feig.ICs, ",");

            string str_commandList = commandListToStr(feig);
            textBox5.Text = str_commandList;
            str_conf_command = str_commandList;

            if (str_commandContent.Count >= 1)
            {
                label3.Text = str_commandKeywords[0];
                textBox2.Text = str_commandContent[0];
            }
           if(str_commandContent.Count == 2)
            {
                label4.Text = str_commandKeywords[1];
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
                    //string str_content = readFeig.inf.getContent(keyword);
                    string str_content = readFeig.inf.getContentFromList(keyword);
                    str_commandContent.Add(str_content);
                    str_commandKeywords.Add(keyword);
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
            str_commandKeywords.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label3.Text = "Command Name";
            label4.Text = "Command Name";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //testIni();
            //readFeig.ini.INIWriteValue("t1", "h1", "r1");
            //string str_configuration = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", str_conf_section, str_conf_protocols, str_conf_ICs, str_conf_command,str_commandKeywords[0],str_commandContent[0]);
            //MessageBox.Show(str_configuration);

            string temp_section="CPR88";
            addSectionToConfFile(temp_section);
            List<Command> commandList = new List<Command>();
            Feig feig = new Feig();
            commandList = feig.getCommand(str_conf_command);
            foreach(Command item in commandList)
            {
                if(item.content.Contains("$FILE$"))
                {
                    //MessageBox.Show("hi");
                    
                    string keyword = temp_section + "-SetupCommands-" + item.icName;
                    addCommandToCommandFile(keyword);
                   
                }
            }
            readFeig.inf.getCommandList();
            


        }

        private void addSectionToConfFile(string str_section)
        {
            //string str_section = str_conf_section + "88";
            if(string.IsNullOrEmpty(str_conf_protocols))
            {
                MessageBox.Show("some value is empty.Please check");
            }
            string str_base_models = readFeig.ini.INIGetStringValue("Base", "SupportedModels");
            if (!str_base_models.Contains(str_section))
            {
                readFeig.ini.INIWriteValue("Base", "SupportedModels", str_base_models+","+str_section);
            }

           
            readFeig.ini.INIWriteValue(str_section, "SupportedProtocols", str_conf_protocols);
            readFeig.ini.INIWriteValue(str_section, "SupportedICs", str_conf_ICs);
            readFeig.ini.INIWriteValue(str_section, "SetupCommands", str_conf_command);

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

        private void button3_Click(object sender, EventArgs e)
        {
            
            

            string temp_section = "CPR88";
            Feig feig = new Feig();
            foreach(Feig item in readFeig.feigList)
            {
                if(item.model.Contains(temp_section))
                {
                    feig = item;
                    break;
                }
            }

            foreach (Command item in feig.command)
            {
                if (item.content.Contains("$FILE$"))
                {
                    //MessageBox.Show("hi");

                    string keyword = temp_section + "-SetupCommands-" + item.icName;
                    removeCommandToCommandFile(keyword);
                    readFeig.inf.getCommandList();
                }
            }
            removeSectionFromConfFile(temp_section);
        }

        private void removeSectionFromConfFile(string str_section)
        {
            string str_base_models = readFeig.ini.INIGetStringValue("Base", "SupportedModels");
            if (str_base_models.Contains(str_section))
            {
                List<string> str = Util.strToList(str_base_models);
                str.Remove(str_section);
                string new_base_models = Util.ListToStr(str,",");

                readFeig.ini.INIWriteValue("Base", "SupportedModels", new_base_models);
                readFeig.ini.INIDeleteSection(str_section);
            }
        }

        private void addCommandToCommandFile(string keyword)
        {
            Command temp_cmd;
            temp_cmd.icName = keyword;
            temp_cmd.content = "content:"+keyword;
            readFeig.inf.saveCommandExtentToCmdFile(temp_cmd);
        }

        private void removeCommandToCommandFile(string keyword)
        {
            Command temp_cmd;
            temp_cmd.icName = keyword;
            temp_cmd.content = "content:" + keyword;
            readFeig.inf.removeCommandFromCmdFile(temp_cmd);
        }
    }
}
