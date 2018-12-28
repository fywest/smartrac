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

        public static string iniPath;
        public static string infPath;
        string outCommand;
        string outName;

        ReadFeig readFeig;


        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ReadFeigJson testjson = new ReadFeigJson();
            //testjson.readFromFile("feig.json");
            //testjson.writeToFile("feig_out.json");

            saveCommand();

            label5.Text = outName + " saved suceessfully";

            button1.Visible = false;

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

                int index = 0;
                foreach (var item in checkedListBox3.Items)
                {
                    if (item.ToString().Contains(checkedListBox1.SelectedItem.ToString()))
                    {

                        //checkedListBox3.Update();
                        checkedListBox3.SetSelected(index, true);
                        checkedListBox3.SetItemCheckState(index, CheckState.Checked);
                        break;
                    }
                    index++;
                }


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
            else if(e.NewValue == CheckState.Unchecked)
            {
                textBox1.Clear();
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
                    string keyword = checkedListBox2.SelectedItem.ToString() + "-SetupCommands-" + checkedListBox3.SelectedItem.ToString();
                    outName = keyword + ".txt";
                    string content="";
                    if(item.content.Contains("$FILE$"))
                    {
                        Inf inf = new Inf(infPath);
                        
                        content = inf.getContent(keyword);// ("CPR74_class-SetupCommands1-SLIX2");
                        outCommand=inf.output_command;

                    }
                    else
                    {
                        content = item.content;
                        outCommand = content;
                    }
                    //textBox1.Font=new Font(textBox1.Font.Name,6,textBox1.Font.Style);
                    label4.Text = "Command: "+keyword;
                    textBox1.Text = content;
 

                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {

            //ICsList = new string[]{ "NTAG213", "NTAG210", "SIC43NT", "SLIX2" };

            //iniPath = Path.Combine(Application.StartupPath, "HF_reader_FEIG2_new.ini");
            if(string.IsNullOrEmpty(infPath))
            {
                infPath = iniPath.Replace(".ini", ".inf");
                label7.Text = "DefaultCommand File: " + infPath;
            }

            readFeig = new ReadFeig(iniPath);

            //Feig feig = new Feig("CPR74", "ISO14443A", "NTAG213", "NTAG213:YYYY",null);
            //feigList.Add(feig);
            if(readFeig.feigList.Count==0)
            {
                MessageBox.Show("please check configuration files!");
            }
            else
            {
                button2.Visible = false;
                
                checkedListBox1.Items.AddRange(readFeig.getICsList());
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
            if (checkedListBox3.Items.Count > 0)
            {
                checkedListBox3.Items.Clear();
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
