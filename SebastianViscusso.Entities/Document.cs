using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using SebastianViscusso.Entities;

namespace SebastianViscusso.Clases
{
    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public Document(string fileName, string safeFileName)
        {
            //
            // constructor to set file name and its contents
            //

            this.Title = fileName;
            this.Text = safeFileName;
        }

        public string ExtractTitleWithoutExtension(string fileName)
        {
            //
            // returns the name of the file without the extension
            //

            string rtaName;
            string extractFile = Path.GetExtension(fileName);
            rtaName = fileName.Replace(extractFile, "");

            return rtaName;
        }

        public string ExtractText(string filePath)
        {
            //
            // returns a string with the contents of the file
            //

            string rtaText = "";
            StreamReader sr = new StreamReader(filePath);
            string line;
            List<string> vLines = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                rtaText += line + "\r\n";
            }
            sr.Close();

            return rtaText;
        }

        public bool ExportTo_XML(string fileName, string docText)
        {
            //
            // export the file to XML document
            //

            try
            {
                XmlTextWriter writer = new XmlTextWriter(fileName + ".xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = System.Xml.Formatting.Indented;

                writer.WriteStartElement(docText);

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExportTo_Json(string fileName, Document doc)
        {
            //
            // export the file to JSON document
            //

            try
            {
                var serializedDoc = JsonConvert.SerializeObject(doc);

                var targetStream = File.Open(fileName + ".json", FileMode.Create, FileAccess.Write);
                var sw = new StreamWriter(targetStream);
                sw.Write(serializedDoc);
                sw.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
