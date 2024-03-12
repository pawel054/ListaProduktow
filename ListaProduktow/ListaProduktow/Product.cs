using System;
using System.Collections.Generic;
using System.Text;

namespace ListaProduktow
{
    public class Product
    {
        public string ID {  get; set; }
        public string Name {  get; set; }
        public decimal Price {  get; set; }
        public int Count { get; set; }

        public Product() { }
        public Product(string Id, string name, decimal price, int count)
        {
            ID = Id;
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
