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

        string str_conf_model;
        string str_conf_protocols;
        string str_conf_ICs;
        
        string str_icName_1;
        string str_icName_2;
        string str_icName_3;

        string str_command_1;
        string str_command_2;
        string str_command_3;

        ReadFeigJson readFeigJson;
        FeigJson feigJson;

        public Form2()
        {
            InitializeComponent();
            initFeigJson();
        }

        private void initFeigJson()
        {
            readFeigJson = new ReadFeigJson();
            feigJson = new FeigJson();


            readFeigJson.readFromFile(Form1.jsonPath);
            readFeigJson.getICsProtocolsModelList();
            InitlistBoxSelectModel();
            

        }
        private void buttonModify_Click(object sender, EventArgs e)
        {

            string selectModel = listBoxSelectModel.SelectedItem.ToString();
            
            deleteFeig(selectModel);

            CreateFeig(selectModel);
            readFeigJson.feigJsonList.ReaderConfig.Add(CreateFeig(str_conf_model));
            readFeigJson.writeToFile(Form1.jsonPath);

            initFeigJson();

        }

        private void InitlistBoxSelectModel()
        {
            listBoxSelectModel.SelectionMode = SelectionMode.One;
            listBoxSelectModel.BeginUpdate();

            if(listBoxSelectModel.Items.Count>0)
            {
                listBoxSelectModel.Items.Clear();

            }

            foreach (var item in readFeigJson.ModelList)
                listBoxSelectModel.Items.Add(item);


            listBoxSelectModel.EndUpdate();
            listBoxSelectModel.SetSelected(0, true);
        }

        private void listBoxSelectModel_SelectedIndexChanged(object sender, EventArgs e)
        {

            contentClear();
            string selectModel = listBoxSelectModel.SelectedItem.ToString();
            feigJson = getSelectedReaderJson(selectModel);
         
            textBoxFeigModel.Text = selectModel;
            str_conf_model = selectModel;

            textBoxSupportedProtocols.Text = Util.StrArrayToStr(feigJson.SupportedProtocols,";");
            str_conf_protocols = Util.StrArrayToStr(feigJson.SupportedProtocols, ";");

            textBoxSupportedICs.Text = Util.StrArrayToStr(feigJson.SupportedICs, ";");
            str_conf_ICs = Util.StrArrayToStr(feigJson.SupportedICs, ";");

            ShowSetupCommand(feigJson);
       
        }

        private void ShowSetupCommand(FeigJson feigjson)
        {

            int i = 1;
            foreach(CommandJson command in feigjson.SetupCommands)
            {

                if(i==1)
                {
                    textBoxICsName1.Text = Util.StrArrayToStr(command.icName, ";");
                    str_icName_1= Util.StrArrayToStr(command.icName, ";");

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

        private string commandToStr(Command command)
        {
            string[] str = new string[2];
            str[0] = command.icName;
            str[1] = command.content;
            return string.Join(":", str);
        }

        private void contentClear()
        {

            textBoxSupportedProtocols.Clear();
            textBoxSupportedICs.Clear();
            textBoxICsName1.Clear();
            textBoxICsName2.Clear();
            textBoxICsName3.Clear();

            textBoxICsCommand1.Clear();
            textBoxICsCommand2.Clear();
            textBoxICsCommand3.Clear();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            

            
            readFeigJson.feigJsonList.ReaderConfig.Add(CreateFeig(str_conf_model));
            readFeigJson.writeToFile(Form1.jsonPath);

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

            readFeigJson.writeToFile(Form1.jsonPath);

            initFeigJson();

        }

        private void deleteFeig(string model)
        {
            feigJson = getSelectedReaderJson(model);

            readFeigJson.feigJsonList.ReaderConfig.Remove(feigJson);

        }

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
            str_icName_2 = textBoxICsName2.Text.ToString();
        }

        private void textBoxICsName3_TextChanged(object sender, EventArgs e)
        {
            str_icName_3 = textBoxICsName3.Text.ToString();
        }
    }
}
