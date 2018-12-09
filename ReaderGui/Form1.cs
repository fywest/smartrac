using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaderGui
{
    public partial class Form1 : Form
    {
        string[] ICsList;

        List<string> readerList=new List<string>();
        List<Command> commandList = new List<Command>();
        List<Feig> feigList = new List<Feig>();
        
        public Form1()
        {
            
            InitializeComponent();
            ICsList = new string[]{ "NTAG213", "NTAG210", "SIC43NT", "SLIX2" };

            Feig feig = new Feig("CPR74", "ISO14443A", "NTAG213", "NTAG213", "YYYY");
            Feig feig1 = new Feig("CPR40", "ISO14443B", "NTAG210", "NTAG210", "XXXX");
            Feig feig2 = new Feig("CPR99", "ISO14443B", "NTAG213", "NTAG210", "XXXX");

            string temp = "\"NTAG213\",\"NTAG210\",\"SIC43NT\",\"SLIX2\"";
            Feig feig3 = new Feig("CPR99",temp, "NTAG213", "NTAG210", "ZZZZ");
            feigList.Add(feig);
            feigList.Add(feig1);
            feigList.Add(feig2);
            feigList.Add(feig3);
        
            checkedListBox1.Items.AddRange(ICsList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (var item in feigList)
            //{
            //    MessageBox.Show(item.showinfo());
            //}

            //read file
            ReadFeig ini = new ReadFeig();

            string[] allKeys=ini.ReadIniAllKeys("CPR40 class");
            MessageBox.Show(string.Join("\n",allKeys));

            string protocols=ini.ReadValue("CPR40 class", "Supported protocols");
            string ICs= ini.ReadValue("CPR40 class", "Supported ICs");
            string Commands= ini.ReadValue("CPR40 class", "Setup commands");



            List<string> protocols_List=strToList(protocols);
            List<string> ICs_List = strToList(ICs);

            MessageBox.Show("h");


            //byte[] byte_protocols=ini.IniReadValues("CPR40 class", "Supported protocols");
            //var str = System.Text.Encoding.Default.GetString(byte_protocols);
            //MessageBox.Show(str);

            // Display in a message box all the items that are checked.

            // First show the index and check state of all selected items.
            //foreach (int indexChecked in checkedListBox1.CheckedIndices)
            //{
            //    // The indexChecked variable contains the index of the item.
            //    MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
            //                    checkedListBox1.GetItemCheckState(indexChecked).ToString() + ".");
            //}

            // Next show the object title and check state for each item selected.
            //foreach (object itemChecked in checkedListBox1.CheckedItems)
            //{

            //    // Use the IndexOf method to get the index of an item.
            //    MessageBox.Show("Item with title: \"" + itemChecked.ToString() +
            //                    "\", is checked. Checked state is: " +
            //                    checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");
            //}

            //foreach (object itemChecked in checkedListBox1.CheckedItems)
            //{
            //    ReaderList.Add(itemChecked.ToString());
            //}
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
            MessageBox.Show(str_in_data);
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
            foreach(var reader in feigList)
            {
                if(reader.ICs==str)
                {
                    readerList.Add(reader.model);
                }
            }
            if(readerList.Count>0)
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
            string str = selectedReader;////"NTAG213";
            commandList.Clear();
            checkedListBox3.Items.Clear();
            foreach (var reader in feigList)
            {
                if (reader.model == str)
                {
                    Command item;
                    item.icName = reader.command.icName;
                    item.content = reader.command.content;
                    commandList.Add(item);
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

        }

        private void addCommandContent(string commandIC)
        {
            string str = commandIC;
            foreach(var item in commandList)
            {
                if(item.icName==str)
                {
                    //MessageBox.Show(item.content);
                    textBox1.Text = item.content;
                }
            }
        }
    }
}
