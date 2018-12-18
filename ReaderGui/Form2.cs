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
    public partial class Form2 : Form
    {
        ReadFeig readFeig;
        Feig feig;
        public Form2()
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Form1.iniPath))
            {
                Form1.iniPath = @"C:\Users\fywes\git_fywest\smartrac\ReaderGui\bin\Debug\HF_reader_FEIG2_configuration.ini";
            }
            readFeig = new ReadFeig(Form1.iniPath);
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
            string selectModel = listBox1.SelectedItem.ToString();

            this.feig=getSelectedReader(selectModel);
            
            //string[] str_lines=readFeig.ini.INIGetAllItems(feig.model+"_class");
           
                textBox1.Text = "";

            
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
    }
}
