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
using System.Resources;
using System.Reflection; 

namespace SebastianViscusso
{
    public partial class Form1 : Form
    {

        Document doc;
        ResourceManager rm;
        bool validToExport; // flag used to enable file export

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rm = new ResourceManager("SebastianViscusso.Resource", Assembly.GetExecutingAssembly());
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (validToExport)
                {
                    SaveFileDialog openFileDialog1 = new SaveFileDialog();

                    openFileDialog1.Title = rm.GetString("SelectLocation");
                    openFileDialog1.FileName = doc.Title;
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        bool result = doc.ExportTo_XML(openFileDialog1.FileName, doc.Text);

                        if (result)
                        {
                            MessageBox.Show(rm.GetString("MsjCorrectConversion"));
                        }
                        else
                            MessageBox.Show(rm.GetString("MsjIncorrectConversion"));
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            try
            {
                if (validToExport)
                {
                    SaveFileDialog openFileDialog1 = new SaveFileDialog();

                    openFileDialog1.Title = rm.GetString("SelectLocation");
                    openFileDialog1.FileName = doc.Title;
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        bool result = doc.ExportTo_Json(openFileDialog1.FileName, doc);

                        if (result)
                        {
                            MessageBox.Show(rm.GetString("MsjCorrectConversion"));
                        }
                        else
                            MessageBox.Show(rm.GetString("MsjIncorrectConversion"));
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "XML (*.xml)|*.xml|JSON (*.json)|*.json|HTML (*.html)|*.html|TXT (*.txt)|*.txt";
                openFileDialog1.Title = rm.GetString("SearchFile");

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    doc = new Document(openFileDialog1.FileName, openFileDialog1.SafeFileName);

                    txtNombre.Text = doc.Title;
                    txtText.Text = doc.Text;

                    txtText.Enabled = true;
                    txtNombre.Enabled = true;
                    validToExport = true;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
