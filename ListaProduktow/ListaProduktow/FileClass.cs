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
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data6.txt");
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

                    if (entries.Length == 4)
                    {
                        Product product = new Product();
                        product.ID = entries[0];
                        product.Name = entries[1];
                        product.Price = decimal.Parse(entries[2]);
                        product.Count = int.Parse(entries[3]);

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

        private static void WriteToFile(Product produkt)
        {
            string line = $"{produkt.ID};{produkt.Name};{produkt.Price};{produkt.Count}";
            using (StreamWriter writer = new StreamWriter(FileClass.GetFilePath(), true))
            {
                writer.WriteLine(line);
            }
        }

        public static void DeleteFromFile(Product product)
        {
            if (File.Exists(FileClass.GetFilePath()))
            {
                List<string> lines = File.ReadAllLines(FileClass.GetFilePath()).ToList();
                File.WriteAllText(FileClass.GetFilePath(), string.Empty);

                foreach (var line in lines)
                {
                    if (!line.StartsWith(product.ID))
                    {
                        Product products = new Product();
                        string[] entries = line.Split(';');
                        products.ID = entries[0];
                        products.Name = entries[1];
                        products.Price = decimal.Parse(entries[2]);
                        products.Count = int.Parse(entries[3]);
                        WriteToFile(products);
                    }
                }

            }
        }
    }
}
