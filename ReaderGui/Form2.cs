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
        //ReadFeig readFeig;
        //Feig feig;
        //string iniPath;
        //string infPath;

        string str_conf_model;
        string str_conf_protocols;
        string str_conf_ICs;
        //string str_conf_command;
        string str_icName_1;
        string str_icName_2;
        string str_icName_3;

        string str_command_1;
        string str_command_2;
        string str_command_3;
        //List<string> str_commandContent = new List<string>();
        //List<string> str_commandKeywords = new List<string>();


        //json
        ReadFeigJson readFeigJson;
        FeigJson feigJson;

        public Form2()
        {
            InitializeComponent();
            //if (string.IsNullOrEmpty(Form1.iniPath))
            //{
            //    iniPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_configuration_ver2.ini");
            //    infPath = iniPath.Replace(".ini", ".inf");
            //    //Form1.iniPath = inipath;// @"C:\Users\fywes\git_fywest\smartrac\ReaderGui\bin\Debug\HF_reader_FEIG2_configuration.ini";
            //}
            //else
            //{
            //    iniPath = Form1.iniPath;
            //    infPath = Form1.infPath;
            //}
            //readFeig = new ReadFeig(iniPath,infPath);

            initFeigJson();
        }

        private void initFeigJson()
        {
            readFeigJson = new ReadFeigJson();
            feigJson = new FeigJson();

            
            readFeigJson.readFromFile("feig.json");
            readFeigJson.getICsProtocolsModelList();
            InitlistBoxSelectModel();
        }
        private void buttonModify_Click(object sender, EventArgs e)
        {

            string selectModel = listBoxSelectModel.SelectedItem.ToString();
            
            deleteFeig(selectModel);
            readFeigJson.writeToFile("feig.json");

            initFeigJson();

            CreateFeig(selectModel);

           readFeigJson.writeToFile("feig.json");

            initFeigJson();

            //string temp_section = listBoxSelectModel.GetItemText(listBoxSelectModel.SelectedItem);//"CPR88";
            //addSectionToConfFile(temp_section);
            //List<Command> commandList = new List<Command>();
            //Feig feig = new Feig();
            //commandList = feig.getCommand(str_conf_command);
            //int index = 0;
            //foreach (Command item in commandList)
            //{

            //    if (item.content.Contains("$FILE$"))
            //    {
            //        //MessageBox.Show("hi");
            //        index++;
            //        string keyword = temp_section + "-SetupCommands-" + item.icName;
            //        replaceCommandToCommandFile(keyword, index);

            //    }
            //}


            //initList();
        }

        private void InitlistBoxSelectModel()
        {
            listBoxSelectModel.SelectionMode = SelectionMode.One;
            listBoxSelectModel.BeginUpdate();
            //for (int x = 1; x <= 50; x++)
            //{
            if(listBoxSelectModel.Items.Count>0)
            {
                listBoxSelectModel.Items.Clear();

            }
            //foreach(var item in Util.ListToStrArray(readFeig.ModelList))
            foreach (var item in readFeigJson.ModelList)
                listBoxSelectModel.Items.Add(item);
            //}

            listBoxSelectModel.EndUpdate();
            listBoxSelectModel.SetSelected(0, true);
        }

        private void listBoxSelectModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listBoxSelectModel.SelectedItem.ToString());
            contentClear();
            string selectModel = listBoxSelectModel.SelectedItem.ToString();

            //this.feig=getSelectedReader(selectModel);
            feigJson = getSelectedReaderJson(selectModel);

            //string[] str_lines=readFeig.ini.INIGetAllItems(feig.model+"_class");
            //string str_command= commandToStr(feig.command[0]);
            

            textBoxFeigModel.Text = selectModel;
            str_conf_model = selectModel;

            //textBoxSupportedProtocols.Text = Util.StrArrayToStr(feig.protocols, ",");
            textBoxSupportedProtocols.Text = Util.StrArrayToStr(feigJson.SupportedProtocols,";");
            str_conf_protocols = Util.StrArrayToStr(feigJson.SupportedProtocols, ";");

            //textBoxSupportedICs.Text = Util.StrArrayToStr(feig.ICs, ",");
            textBoxSupportedICs.Text = Util.StrArrayToStr(feigJson.SupportedICs, ";");
            str_conf_ICs = Util.StrArrayToStr(feigJson.SupportedICs, ";");

            //string str_commandList = commandListToStr(feig);
            //textBoxICsCommand3.Text = str_commandList;
            //str_conf_command = str_commandList;


            ShowSetupCommand(feigJson);

           // if (str_commandContent.Count >= 1)
           // {
           //     labelICsName1.Text = str_commandKeywords[0];
           //     textBoxICsCommand1.Text = str_commandContent[0];
           // }
           //if(str_commandContent.Count == 2)
           // {
           //     labelICsName2.Text = str_commandKeywords[1];
           //     textBoxICsCommand2.Text = str_commandContent[1];
           // }



            
        }

        private void ShowSetupCommand(FeigJson feigjson)
        {
            //string[] commandNamesArray = Util.ListToStrArray(read)
            //InitListBox2();
            //int y_posi = 450;// feigjson.SetupCommands.Count;
            int i = 1;
            foreach(CommandJson command in feigjson.SetupCommands)
            {
                // TextBox tb = new TextBox();
                // //tb.Size=new Size(1000,200);
                // //tb.Top = 400 + num * 50;
                // //tb.Left = 20;

                // tb.Location = new System.Drawing.Point(20, y_posi);//x,y
                // tb.Size = new System.Drawing.Size(500, 50);

                // tb.Multiline = true;

                // y_posi+=60;
                //// panel1.Controls.Add(tb);
                // tb.Text = Util.StrArrayToStr(command.icCommand, "\r\n");
                // tb.Visible = true;
                // tb.Show();
                // //panel1.Visible = false;
                if(i==1)
                {
                    textBoxICsName1.Text = Util.StrArrayToStr(command.icName, ";");
                    str_icName_1= Util.StrArrayToStr(command.icName, ";");
                    //int numberOfLines = command.icCommand.Count();
                    //textBoxICsCommand1.Height = (textBoxICsCommand1.Font.Height + 2) * (numberOfLines);
                    textBoxICsCommand1.Text = Util.StrArrayToStr(command.icCommand, "\r\n");
                    str_command_1 = Util.StrArrayToStr(command.icCommand, "\r\n");


                }
                else if(i==2)
                {
                    textBoxICsName2.Text = Util.StrArrayToStr(command.icName, ";");
                    str_icName_2 = Util.StrArrayToStr(command.icName, ";");

                    textBoxICsCommand2.Text = Util.StrArrayToStr(command.icCommand, "\r\n");
                    str_command_2 = Util.StrArrayToStr(command.icCommand, "\r\n");
                }
                else if(i==3)
                {
                    textBoxICsName3.Text = Util.StrArrayToStr(command.icName, ";");
                    str_icName_3 = Util.StrArrayToStr(command.icName, ";");

                    textBoxICsCommand3.Text = Util.StrArrayToStr(command.icCommand, "\r\n");
                    str_command_3 = Util.StrArrayToStr(command.icCommand, "\r\n");
                }

                i++;
            }
        }

        //private void InitlistBoxSetupCommands(string[] commandIcnamesArray)
        //{
        //    listBoxSetupCommands.SelectionMode = SelectionMode.One;
        //    listBoxSetupCommands.BeginUpdate();
        //    //for (int x = 1; x <= 50; x++)
        //    //{
        //    if (listBoxSetupCommands.Items.Count > 0)
        //    {
        //        listBoxSetupCommands.Items.Clear();

        //    }
        //    //foreach(var item in Util.ListToStrArray(readFeig.ModelList))
        //    foreach (var item in commandIcnamesArray)
        //        listBoxSetupCommands.Items.Add(item);
        //    //}

        //    listBoxSetupCommands.EndUpdate();
        //    listBoxSetupCommands.SetSelected(0, true);
        //}

        //private Feig getSelectedReader(string selectedModel)
        //{
        //    Feig feig_temp = new Feig();
        //    foreach(Feig temp in readFeig.feigList)
        //    {
        //        if(string.Compare(temp.model,selectedModel)==0)
        //        {
        //            feig_temp = temp;
        //            return feig_temp;
        //        }
        //    }
        //    return null;
        //}
        private FeigJson getSelectedReaderJson(string selectedModel)
        {
            FeigJson feig_temp = new FeigJson();
            foreach (FeigJson temp in readFeigJson.feigJsonList.ReaderConfig)
            {
                if (string.Equals(temp.Model, selectedModel))
                {
                    feig_temp = temp;
                    return feig_temp;
                }
            }
            return null;
        }

        //private string commandListToStr(Feig feig)
        //{
        //    List<string> str_command=new List<string>();
        //    foreach(Command temp in feig.command)
        //    {
        //        str_command.Add(commandToStr(temp));
        //        if(temp.content.Contains("$FILE$"))
        //        {
                    
        //            string keyword = feig.model+ "-SetupCommands-" + temp.icName;
        //            //string str_content = readFeig.inf.getContent(keyword);
        //            string str_content = readFeig.inf.getContentFromList(keyword);
        //            str_commandContent.Add(str_content);
        //            str_commandKeywords.Add(keyword);
        //        }
        //    }

        //    string str_commandList = string.Join(";", str_command.ToArray());
        //    return str_commandList;
        //}
        private string commandToStr(Command command)
        {
            string[] str = new string[2];
            str[0] = command.icName;
            str[1] = command.content;
            return string.Join(":", str);
        }

        private void contentClear()
        {
            //str_commandContent.Clear();
            //str_commandKeywords.Clear();
            textBoxSupportedProtocols.Clear();
            textBoxSupportedICs.Clear();
            textBoxICsName1.Clear();
            textBoxICsName2.Clear();
            textBoxICsName3.Clear();

            textBoxICsCommand1.Clear();
            textBoxICsCommand2.Clear();
            textBoxICsCommand3.Clear();

            //labelICsName1.Text = "Command Name";
            //labelICsName2.Text = "Command Name";

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            

            
            readFeigJson.feigJsonList.ReaderConfig.Add(CreateFeig(str_conf_model));
            readFeigJson.writeToFile("feig.json");

            initFeigJson();

        }

        private FeigJson CreateFeig(string model)
        {
            List<CommandJson> commandJsonList = new List<CommandJson>();
            CommandJson temp;
            if (!string.IsNullOrEmpty(str_icName_1))
            {
                temp.icName = Util.strTrimToArray(str_icName_1, ';');
                temp.icCommand = Util.strTrimToArray(str_command_1, '\n');
                commandJsonList.Add(temp);
            }
            if (!string.IsNullOrEmpty(str_icName_2))
            {
                temp.icName = Util.strTrimToArray(str_icName_2, ';');
                temp.icCommand = Util.strTrimToArray(str_command_2, '\n');
                commandJsonList.Add(temp);
            }
            if (!string.IsNullOrEmpty(str_icName_3))
            {
                temp.icName = Util.strTrimToArray(str_icName_3, ';');
                temp.icCommand = Util.strTrimToArray(str_command_3, '\n');
                commandJsonList.Add(temp);
            }
            FeigJson feigJsonTemp = new FeigJson(model, str_conf_protocols, str_conf_ICs, commandJsonList);
            return feigJsonTemp;
        }

        private void addSectionToConfFile(string str_section)
        {
            //string str_section = str_conf_section + "88";

            

            //if (string.IsNullOrEmpty(str_conf_protocols))
            //{
            //    MessageBox.Show("some value is empty.Please check");
            //}
            
            //readFeig.ini.INIWriteValue(str_section, "SupportedProtocols", str_conf_protocols);
            //readFeig.ini.INIWriteValue(str_section, "SupportedICs", str_conf_ICs);
            //readFeig.ini.INIWriteValue(str_section, "SetupCommands", str_conf_command);

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {


            string selectModel = listBoxSelectModel.SelectedItem.ToString();

            deleteFeig(selectModel);

            readFeigJson.writeToFile("feig.json");

            initFeigJson();

        }

        private void deleteFeig(string model)
        {
            feigJson = getSelectedReaderJson(model);

            readFeigJson.feigJsonList.ReaderConfig.Remove(feigJson);

        }

        //private void removeSectionFromConfFile(string str_section)
        //{
        //    string str_base_models = readFeig.ini.INIGetStringValue("Base", "SupportedModels");
        //    if (str_base_models.Contains(str_section))
        //    {
        //        List<string> str = Util.strToList(str_base_models);
        //        str.Remove(str_section);
        //        string new_base_models = Util.ListToStr(str,",");

        //        readFeig.ini.INIWriteValue("Base", "SupportedModels", new_base_models);
        //        readFeig.ini.INIDeleteSection(str_section);
        //    }
        //}

        //private void addCommandToCommandFile(string keyword,int index)
        //{
        //    Command temp_cmd;
        //    temp_cmd.icName = keyword;
        //    temp_cmd.content="";
        //    if(index==1)
        //    {
        //        temp_cmd.content = str_command_1.Trim();
        //    }
        //    if(index==2)
        //    {
        //        temp_cmd.content = str_command_2.Trim();
        //    }
            
        //    readFeig.inf.saveCommandExtentToCmdFile(temp_cmd);
        //}

        //private void removeCommandToCommandFile(string keyword)
        //{
        //    Command temp_cmd;
        //    temp_cmd.icName = keyword;
        //    temp_cmd.content = "content:" + keyword;
        //    readFeig.inf.removeCommandFromCmdFile(temp_cmd);
        //}

        //private void replaceCommandToCommandFile(string keyword,int index)
        //{
        //    Command temp_cmd;
        //    temp_cmd.icName = keyword;
        //    temp_cmd.content = "";
        //    if (index == 1)
        //    {
        //        temp_cmd.content = str_command_1.Trim();
        //    }
        //    if (index == 2)
        //    {
        //        temp_cmd.content = str_command_2.Trim();
        //    }

        //    readFeig.inf.removeCommandFromCmdFile(temp_cmd);
        //    readFeig.inf.saveCommandExtentToCmdFile(temp_cmd);
        //}

        //private void initList()
        //{
        //    //readFeig.inf.getCommandList();
        //    //readFeig.getModelList();
        //    //readFeig.getAllFeig();
        //    //InitlistBoxSelectModel();

        //    readFeig = new ReadFeig(iniPath, infPath);


        //    InitlistBoxSelectModel();
        //}

        private void clearText()
        {
            textBoxSupportedProtocols.Clear();
            textBoxSupportedICs.Clear();

            textBoxICsCommand1.Clear();
            textBoxICsCommand2.Clear();
            textBoxICsCommand3.Clear();

            textBoxICsName1.Clear();
            textBoxICsName2.Clear();
            textBoxICsName3.Clear();

        }

        private void textBoxFeigModel_TextChanged(object sender, EventArgs e)
        {
            clearText();
            str_conf_model = textBoxFeigModel.Text.ToString();
 

        }

        private void textBoxSupportedProtocols_TextChanged(object sender, EventArgs e)
        {
            str_conf_protocols = textBoxSupportedProtocols.Text.ToString();
        }

        private void textBoxSupportedICs_TextChanged(object sender, EventArgs e)
        {
            str_conf_ICs = textBoxSupportedICs.Text.ToString();
        }



        private void textBoxICsCommand1_TextChanged(object sender, EventArgs e)
        {
            str_command_1 = textBoxICsCommand1.Text.ToString();
        }

        private void textBoxICsCommand2_TextChanged(object sender, EventArgs e)
        {
            str_command_2 = textBoxICsCommand2.Text.ToString();
        }

        private void textBoxICsCommand3_TextChanged(object sender, EventArgs e)
        {
            str_command_3 = textBoxICsCommand3.Text.ToString();
        }

        private void textBoxICsName1_TextChanged(object sender, EventArgs e)
        {
            str_icName_1 = textBoxICsName1.Text.ToString();
        }

        private void textBoxICsName2_TextChanged(object sender, EventArgs e)
        {
            str_icName_2 = textBoxICsName1.Text.ToString();
        }

        private void textBoxICsName3_TextChanged(object sender, EventArgs e)
        {
            str_icName_3 = textBoxICsName1.Text.ToString();
        }
    }
}
