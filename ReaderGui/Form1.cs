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

        List<string> readerList=new List<string>();
        List<CommandJson> commandListJson = new List<CommandJson>();

        public static string iniPath;
        public static string infPath;
        string outCommand;
        string outName;

        ReadFeig readFeig;

        //json
        ReadFeigJson readFeigJson;


        public Form1()
        {
            
            InitializeComponent();

            readFeigJson = new ReadFeigJson();
        }

        private void button1_Click(object sender, EventArgs e)//save
        {

            //ReadFeigJson testjson = new ReadFeigJson();
            //testjson.readFromFile("feig.json");
            //testjson.writeToFile("feig_out.json");

            saveCommand();

            label5.Text = outName + " saved suceessfully";

            button1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)//confirm
        {

            //ICsList = new string[]{ "NTAG213", "NTAG210", "SIC43NT", "SLIX2" };

            //iniPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.ini");

            if (string.IsNullOrEmpty(infPath))
            {
                infPath = iniPath.Replace(".ini", ".inf");
                label7.Text = "DefaultCommand File: " + infPath;
            }

            readFeig = new ReadFeig(iniPath);

            readFeigJson.readFromFile("feig.json");
            readFeigJson.getICsProtocolsModelList();


            //Feig feig = new Feig("CPR74", "ISO14443A", "NTAG213", "NTAG213:YYYY",null);
            //feigList.Add(feig);
            if (readFeig.feigList.Count == 0)
            {
                MessageBox.Show("please check configuration files!");
            }
            else
            {
                button2.Visible = false;

                //checkedListBox1.Items.AddRange(readFeig.getICsList());
                checkedListBox1.Items.AddRange(readFeigJson.ICsNameList.ToArray());

            }

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
                string[] readerListArray=addReaderList(selectedIC);

                checkedListBox2.Items.AddRange(readerListArray);
            }


        }
        private string[] addReaderList(string selectedIC)
        {
            //string str = selectedIC;////"NTAG213";
            readerList.Clear();
            checkedListBox2.Items.Clear();
            textBox1.Clear();

            //foreach (var feig in readFeig.feigList)
            //{
            //    if (feig.ICs.Contains(str))
            //    {
            //        readerList.Add(feig.model);
            //    }
            //}

            foreach (var feig in readFeigJson.feigJsonList.ReaderConfig)
            {
                if (feig.SupportedICs.Contains(selectedIC))
                {
                    readerList.Add(feig.Model);
                }
            }


            if (readerList.Count<=0)
            {
                MessageBox.Show("reader count less than one");
            }
            string[] str_array = readerList.Select(i => i.ToString()).ToArray();
            return str_array;
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
                string selectedIC = checkedListBox1.SelectedItem.ToString();

                foreach(FeigJson feig in readFeigJson.feigJsonList.ReaderConfig)
                {
                    if(string.Equals(feig.Model,selectedReader))
                        {
                        foreach(CommandJson command in feig.SetupCommands)
                        {
                            if(command.icName.Contains(selectedIC))
                            {
                                outName=selectedReader+"-"+selectedIC+"-SetupCommand.txt";
                                outCommand= Util.StrArrayToStr(command.icCommand, "\r\n");
                                textBox1.Text = outCommand;
                            }
                        }

                        }
                }


            }

        }

        private void addCommandList(string selectedReader)
        {
            //string str = selectedReader;////"CPR40";
            commandListJson.Clear();


            foreach (var feig in readFeigJson.feigJsonList.ReaderConfig)
            {
                if (feig.Model.Contains(selectedReader))
                {
                    foreach (var command in feig.SetupCommands)
                    {
                        CommandJson item;
                        item.icName = command.icName;//command.icName;
                        item.icCommand = command.icCommand;
                        commandListJson.Add(item);

                    }
                }
            }


            if (commandListJson.Count <= 0)
            {
                MessageBox.Show("command count less than one");
            }
            //string[] str_array = commandListJson.Select(i => i.icName.ToString()).ToArray();

        }


        public void saveCommand()
        {
            string txtPath = Path.Combine(Application.StartupPath, outName);
            
            FileStream txtOut;
            StreamWriter txtWrite;

            txtOut = new FileStream(txtPath, FileMode.Create, FileAccess.Write);
            txtWrite = new StreamWriter(txtOut, System.Text.Encoding.Default);
            txtWrite.WriteLine(outCommand);
            txtWrite.Close();
            txtOut.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label4.Text = "Command: ";
                label5.Text = "Status";
                button1.Visible = false;
                label5.Visible= false;
            }
            else
            {
                button1.Visible = true;
                label5.Visible = true;
            }
        }

        private void openReadIniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.Filter = "Reader config Files|*.ini";
            openFileDialog1.Title = "Select a Feig ini File";

            if (openFileDialog1.ShowDialog(this)==DialogResult.OK)
            {
                iniPath = openFileDialog1.FileName;
                label6.Text = "Reader Config File : " + iniPath;
            }
        }

        private void openCommandInfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Command config Files|*.inf";
            openFileDialog1.Title = "Select a Command inf File";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                infPath = openFileDialog1.FileName;
                label7.Text = "Command Config File: " + infPath;
            }
        }

       

        private void label6_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
            clearAllBox();
        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
            clearAllBox();

        }

        private void clearAllBox()
        {
            if(checkedListBox1.Items.Count>0)
            {
                checkedListBox1.Items.Clear();
            }
            if (checkedListBox2.Items.Count > 0)
            {
                checkedListBox2.Items.Clear();
            }

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Clear();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
           
            if (FormWindowState.Minimized == WindowState || this.Visible == false)
                a.StartPosition = FormStartPosition.CenterScreen;
            else
                a.StartPosition = FormStartPosition.CenterParent;
            
            a.ShowDialog();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void readerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            //form2.ShowDialog();
            form2.Show();
        }
    }
}
