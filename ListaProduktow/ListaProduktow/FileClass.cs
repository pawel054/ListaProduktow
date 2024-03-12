using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ListaProduktow
{
    public class FileClass
    {
        public static string GetFilePath()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt");
            return filePath;
        }
    }
}
