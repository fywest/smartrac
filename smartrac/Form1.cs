using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace smartrac
{
    public partial class Form1 : Form
    {
        HF_FEIG hf_feig1;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "read info";
            string msg="";
            //HF_Reader hf_reader1=new HF_Reader("Smartrac","NTAG213",12.5);
            hf_feig1 = new HF_FEIG("Smartrac", "NTAG213", 12.5);
            //MessageBox.Show(hf_feig1.WriteBlock());

            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Configuration Files|*.cfg";
            openFileDialog1.Title = "Select a config File";
            string filename="";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .cfg file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            string FileName = filename.Substring(filename.LastIndexOf('\\')+1);
            if(FileName.Length>=4)
            {

                button1.Text = FileName.Remove(FileName.Length - 4);
                hf_feig1.ReadCFGFile(filename);

            }



            for (int i = 0; i < hf_feig1.test_commands.Count; i++)
            {
                int index = i + 1;
                string command = hf_feig1.test_commands[i].Commands;

                msg += index + "\t" + command + "\n";
            }

            //MessageBox.Show(msg);
            ShowList();


        }

        public void ShowList()
        {
            // Create an instance of the ListBox.

            listBox1.SelectionMode = SelectionMode.One;

            // Shutdown the painting of the ListBox as items are added.
            listBox1.BeginUpdate();

            foreach(Test_Command command in hf_feig1.test_commands)
            {
                listBox1.Items.Add(command.Manufacture+"\t"+command.Type);
            }
            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();

            // Select three items from the ListBox.
            listBox1.SetSelected(0, true);
  

            label1.Text = hf_feig1.test_commands[0].Commands;
            // throw new System.NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = hf_feig1.test_commands[listBox1.SelectedIndex].Commands;

        }
    }
}
