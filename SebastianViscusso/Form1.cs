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
using SebastianViscusso.Clases;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;


namespace SebastianViscusso
{
    public partial class Form1 : Form
    {

        Document doc = new Document();
        bool validToExport;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML (*.xml)|*.xml|JSON (*.json)|*.json|HTML (*.html)|*.html|TXT (*.txt)|*.txt";
            openFileDialog1.Title = "Search file";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    doc.Title = doc.ExtractTitleWithoutExtension(openFileDialog1.SafeFileName);
                    txtNombre.Text = doc.Title;

                    doc.Text = doc.ExtractText(openFileDialog1.FileName);
                    txtText.Text = doc.Text;

                    txtText.Enabled = true;
                    txtNombre.Enabled = true;
                    validToExport = true;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            if (validToExport)
            {
                SaveFileDialog openFileDialog1 = new SaveFileDialog();

                openFileDialog1.Title = "Select location";
                openFileDialog1.FileName = doc.Title;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    bool result = doc.ExportTo_XML(openFileDialog1.FileName, doc.Text);

                    if (result)
                    {
                        MessageBox.Show("The file was converted correctly");
                        InitializeTextBox();
                    }
                    else
                        MessageBox.Show("An error has occurred");
                }
            }
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            if (validToExport)
            {
                SaveFileDialog openFileDialog1 = new SaveFileDialog();

                openFileDialog1.Title = "Select location";
                openFileDialog1.FileName = doc.Title;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    bool result = doc.ExportTo_Json(openFileDialog1.FileName, doc);

                    if (result)
                    {
                        MessageBox.Show("The file was converted correctly");
                        InitializeTextBox();
                    }
                    else
                        MessageBox.Show("An error has occurred");
                }
            }
        }

        private void btnCloud_Click(object sender, EventArgs e)
        {
            Cloud newFileCloud = new Cloud();
            if (newFileCloud.OpenFile())
            {
                //
                //
                //
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            InitializeTextBox();
        }

        public void InitializeTextBox()
        {
            txtText.Text = "Text within the file";
            txtText.Enabled = false;
            txtNombre.Text = "File name";
            txtNombre.Enabled = false;
            validToExport = false;
        }
    }
}
