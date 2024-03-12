using System;
using System.Collections.Generic;
using System.Text;

namespace ListaProduktow
{
    public class Product
    {
        public string Name {  get; set; }
        public decimal Price {  get; set; }
        public int Count { get; set; }

        public Product() { }
        public Product(string name, decimal price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
