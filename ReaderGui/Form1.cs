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

        List<string> readerList = new List<string>();
        List<CommandJson> commandListJson = new List<CommandJson>();

        public static string jsonPath;
        string outCommand;
        string outName;

        ReadFeigJson readFeigJson;


        public Form1()
        {

            InitializeComponent();

        }

        private void buttonCommand_Click(object sender, EventArgs e)//save
        {

            saveCommand();
            labelStatus.Text = outName + " saved suceessfully";
            buttonSave.Visible = false;

        }

        private void checkedListBoxSelectIC_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (e.NewValue == CheckState.Checked)
            {
                foreach (int i in checkedListBoxSelectIC.CheckedIndices)
                {
                    checkedListBoxSelectIC.SetItemCheckState(i, CheckState.Unchecked);
                }

                string selectedIC = checkedListBoxSelectIC.SelectedItem.ToString();
                string[] readerListArray = addReaderList(selectedIC);
                checkedListBoxSelectReader.Items.AddRange(readerListArray);
            }


        }
        private string[] addReaderList(string selectedIC)
        {

            readerList.Clear();
            checkedListBoxSelectReader.Items.Clear();
            textBoxCommand.Clear();



            foreach (var feig in readFeigJson.feigJsonList.ReaderConfig)
            {
                if (feig.SupportedICs.Contains(selectedIC))
                {
                    readerList.Add(feig.Model);
                }
            }


            if (readerList.Count <= 0)
            {
                MessageBox.Show("reader count less than one");
            }
            string[] str_array = readerList.Select(i => i.ToString()).ToArray();
            return str_array;
        }

        private void checkedListBoxSelectReader_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (e.NewValue == CheckState.Checked)
            {
                foreach (int i in checkedListBoxSelectReader.CheckedIndices)
                {
                    checkedListBoxSelectReader.SetItemCheckState(i, CheckState.Unchecked);
                }

                string selectedReader = checkedListBoxSelectReader.SelectedItem.ToString();
                string selectedIC = checkedListBoxSelectIC.SelectedItem.ToString();

                foreach (FeigJson feig in readFeigJson.feigJsonList.ReaderConfig)
                {
                    if (string.Equals(feig.Model, selectedReader))
                    {
                        foreach (CommandJson command in feig.SetupCommands)
                        {
                            if (command.icName.Contains(selectedIC))
                            {
                                outName = selectedReader + "-" + selectedIC + "-SetupCommand.txt";
                                outCommand = Util.StrArrayToStr(command.icCommand, "\r\n");
                                textBoxCommand.Text = outCommand;
                            }
                        }
                    }
                }
            }
        }

        private void addCommandList(string selectedReader)
        {

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

        private void textBoxCommand_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCommand.Text))
            {
                labelCommand.Text = "Command: ";
                labelStatus.Text = "Status";
                buttonSave.Visible = false;
                labelStatus.Visible = false;
            }
            else
            {
                buttonSave.Visible = true;
                labelStatus.Visible = true;
            }
        }




        private void label6_TextChanged(object sender, EventArgs e)
        {
            //button2.Visible = true;
            clearAllBox();
        }


        private void clearAllBox()
        {
            if (checkedListBoxSelectIC.Items.Count > 0)
            {
                checkedListBoxSelectIC.Items.Clear();
            }
            if (checkedListBoxSelectReader.Items.Count > 0)
            {
                checkedListBoxSelectReader.Items.Clear();
            }

            if (!string.IsNullOrEmpty(textBoxCommand.Text))
            {
                textBoxCommand.Clear();
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
            if (string.IsNullOrEmpty(Form1.jsonPath))
            {
                MessageBox.Show("Please open config file");

            }
            else
            {
                Form2 form2 = new Form2(this);
                form2.Show();
                
            }

        }

        private void openReadJsonFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Reader config Files|*.json";
            openFileDialog1.Title = "Select a Feig json File";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                jsonPath = openFileDialog1.FileName;
                labelReadConfigFile.Text = "Reader Config File : " + jsonPath;
            }


            InitData();
        }

        public void InitData()
        {
            readFeigJson = new ReadFeigJson();
            readFeigJson.readFromFile(jsonPath);//("feig.json");
            readFeigJson.getICsProtocolsModelList();

            if (checkedListBoxSelectIC.Items.Count > 0)
            {

                checkedListBoxSelectIC.Items.Clear();
                
            }
            if (checkedListBoxSelectReader.Items.Count > 0)
            {
                checkedListBoxSelectReader.Items.Clear();

            }
            if(!string.IsNullOrEmpty(textBoxCommand.Text))
            {
                textBoxCommand.Clear();
            }
            //MessageBox.Show("form1 here");
            bool isEmpty = !readFeigJson.feigJsonList.ReaderConfig.Any();
            if (isEmpty)
            {
                MessageBox.Show("please check configuration files!");
            }
            else
            {
                labelReadConfigFile.Visible = true;
                checkedListBoxSelectIC.Items.AddRange(readFeigJson.ICsNameList.ToArray());

            }
        }

    }
}
