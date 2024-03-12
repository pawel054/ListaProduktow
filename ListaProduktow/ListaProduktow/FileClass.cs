using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

        public static ObservableCollection<Product> ReadData()
        {
            if (File.Exists(FileClass.GetFilePath()))
            {
                List<string> lines = File.ReadAllLines(FileClass.GetFilePath()).ToList();
                ObservableCollection<Product> products = new ObservableCollection<Product>();

                foreach (var line in lines)
                {
                    string[] entries = line.Split(';');

                    if (entries.Length == 3)
                    {
                        Product product = new Product();
                        product.Name = entries[0];
                        product.Price = decimal.Parse(entries[1]);
                        product.Count = int.Parse(entries[2]);

                        products.Add(product);

                    }
                }
                return products;
            }
            else
            {
                return null;
            }
        }

        public static void DeleteFromFile(Product product)
        {
            if (File.Exists(FileClass.GetFilePath()))
            {
                List<string> lines = File.ReadAllLines(FileClass.GetFilePath()).ToList();
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                string updatedLine = "";

                foreach (var line in lines)
                {
                    if (line.StartsWith(product.ID)) { }
                    else
                    {
                        updatedLine += line + Environment.NewLine;
                    }
                }

                File.WriteAllText(FileClass.GetFilePath(), updatedLine);
            }
        }
    }
}
