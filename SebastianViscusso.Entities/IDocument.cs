using SebastianViscusso.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SebastianViscusso.Entities
{
    public interface IDocument
    {

        string ExtractTitleWithoutExtension(string fileName);

        string ExtractText(string filePath);

        bool ExportTo_XML(string fileName, string docText);

        bool ExportTo_Json(string fileName, Document doc);

    }
}
