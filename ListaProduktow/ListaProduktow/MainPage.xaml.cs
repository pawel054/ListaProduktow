using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaProduktow
{
    public partial class MainPage : ContentPage
    {
        private Product wybranyProdukt;
        public ObservableCollection<Product> produkty = new ObservableCollection<Product>();
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateList();
        }
        public void UpdateList()
        {
            lista.ItemsSource = null;
            lista.ItemsSource = produkty;
        }
        public MainPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        public void Dodaj_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageProduct(produkty));
        }
        public void Edytuj_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                wybranyProdukt = (Product)lista.SelectedItem;
                Navigation.PushAsync(new ManageProduct(wybranyProdukt));
                wybranyProdukt = null;
            }
            else
            {
                DisplayAlert("Błąd", "Nie wybrano elementu", "OK");
            }
        }

        public void Usun_Clicked(object sender, EventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                wybranyProdukt = (Product)lista.SelectedItem;
                produkty.Remove(wybranyProdukt);
                UpdateList();
                wybranyProdukt = null;
            }
            else
            {
                DisplayAlert("Błąd", "Nie wybrano elementu", "OK");
            }
        }

        public static ObservableCollection<Product> ReadData()
        {
            if (File.Exists(FileClass.GetFilePath()))
            {
                List<string> lines = File.ReadAllLines(FileClass.GetFilePath()).ToList();
                ObservableCollection<Product> products = new ObservableCollection<Product>();

                foreach(var line in lines)
                {
                    string[] entries = line.Split(';');

                    if(entries.Length == 3)
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
    }
}
