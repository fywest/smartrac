using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderGui
{
    public partial class Form1 : Form
    {
        //string[] ICsList;

        List<string> readerList=new List<string>();
        List<Command> commandList = new List<Command>();

        string path;

        ReadFeig readFeig;

        public Form1()
        {
            
            InitializeComponent();
            //ICsList = new string[]{ "NTAG213", "NTAG210", "SIC43NT", "SLIX2" };

            path = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.ini");
            readFeig = new ReadFeig(path);

            //Feig feig = new Feig("CPR74", "ISO14443A", "NTAG213", "NTAG213:YYYY",null);
            //feigList.Add(feig);

            checkedListBox1.Items.AddRange(readFeig.getICsList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //read inf file
            Inf inf = new Inf();
            string inf_temp=inf.getContent("CPR74_class-SetupCommands1-SLIX2");
            MessageBox.Show(inf_temp);
            //read ini file
            string path= Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.ini");

            ReadFeig readFeig = new ReadFeig(path);

            Ini ini = new Ini(path);

            string[] allSectionNames = ini.INIGetAllSectionNames();
         
            MessageBox.Show(string.Join("\n", allSectionNames));

            string[] allItems_cpr40 = ini.INIGetAllItems("CPR40_class");
            MessageBox.Show(string.Join("\n", allItems_cpr40));

            string[] allItemkeys_cpr74 = ini.INIGetAllItemKeys("CPR74_class");
            MessageBox.Show(string.Join("\n", allItemkeys_cpr74));

            string[] allItems_cpr74=ini.INIGetAllItems("CPR74_class");
            MessageBox.Show(string.Join("\n",allItems_cpr74));


            string protocols=ini.INIGetStringValue("CPR40_class", "SupportedProtocols", null);
            string ICs= ini.INIGetStringValue("CPR40_class", "SupportedICs", null);
            string Commands= ini.INIGetStringValue("CPR40_class", "SetupCommands", null);



            List<string> protocols_List=strToList(protocols);
            List<string> ICs_List = strToList(ICs);

            foreach (var item in readerList)
            {
                MessageBox.Show(item);
            }
            
        }

        private List<string> strToList(string protocols)
        {
            string protocols_new = protocols.Replace("\"", "");
            List<string> protocols_List = new List<string>();
            protocols_List = protocols_new.Split(',', ';').ToList();
            string str_in_data = string.Join("\n", protocols_List.ToArray());
            //MessageBox.Show(str_in_data);
            return protocols_List;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //MessageBox.Show("hi");
            if (e.NewValue == CheckState.Checked)
            {
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                
                string selectedIC = checkedListBox1.SelectedItem.ToString();
                //MessageBox.Show(selectedIC);
                addReaderList(selectedIC);
                

            }


        }
        private void addReaderList(string selectedIC)
        {
            string str = selectedIC;////"NTAG213";
            readerList.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            textBox1.Clear();

            foreach (var feig in readFeig.feigList)
            {
                if (feig.ICs.Contains(str))
                {
                    readerList.Add(feig.model);
                }
            }

            if (readerList.Count>0)
            {
                string[] str_array = readerList.Select(i => i.ToString()).ToArray();
                checkedListBox2.Items.AddRange(str_array);
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
    
            if (e.NewValue == CheckState.Checked)
            {
                foreach (int i in checkedListBox2.CheckedIndices)
                {
                    checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
                }

                string selectedReader = checkedListBox2.SelectedItem.ToString();
                //MessageBox.Show(selectedReader);
                addCommandList(selectedReader);
                


            }

        }

        private void addCommandList(string selectedReader)
        {
            string str = selectedReader;////"CPR40";
            commandList.Clear();
            checkedListBox3.Items.Clear();

            foreach (var feig in readFeig.feigList)
            {
                if (feig.model.Contains(str))
                {
                    foreach(var command in feig.command)
                    {
                        Command item;
                        item.icName = command.icName;
                        item.content = command.content;
                        commandList.Add(item);

                    }
                }
            }
            if (commandList.Count > 0)
            {
                string[] str_array = commandList.Select(i => i.icName.ToString()).ToArray();
                checkedListBox3.Items.AddRange(str_array);
                //int index = 0;
                //foreach(var item in checkedListBox3.Items)
                //{
                //    if(item.ToString()==checkedListBox1.SelectedItem.ToString())
                //    {
                        
                //        string commandIC = item.ToString();
                //        addCommandContent(commandIC);

                //    }
                //    index++;
                //}
            }
        }

        private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                foreach (int i in checkedListBox3.CheckedIndices)
                {
                    checkedListBox3.SetItemCheckState(i, CheckState.Unchecked);
                }

                string commandIC = checkedListBox3.SelectedItem.ToString();
                //MessageBox.Show(CommandIC);
                addCommandContent(commandIC);
                



            }

        }

        private void addCommandContent(string commandIC)
        {
            string str = commandIC;
            foreach(var item in commandList)
            {
                if(item.icName==str)
                {
                    //MessageBox.Show(item.content);
                    string content="";
                    if(item.content.Contains("$FILE$"))
                    {
                        Inf inf = new Inf();
                        string keyword = checkedListBox2.SelectedItem.ToString()+ "-SetupCommands-" + checkedListBox3.SelectedItem.ToString();
                        content = inf.getContent(keyword);// ("CPR74_class-SetupCommands1-SLIX2");
                    }
                    else
                    {
                        content = item.content;
                    }
                    textBox1.Text = content;
                }
            }
        }
    }
}
