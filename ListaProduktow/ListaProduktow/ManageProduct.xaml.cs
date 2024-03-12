using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaProduktow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageProduct : ContentPage
    {
        private Product wybranyProdukt;
        private ObservableCollection<Product> produkty = new ObservableCollection<Product>();
        public ManageProduct(ObservableCollection<Product> produkty)
        {
            InitializeComponent();
            this.produkty = produkty;
        }

        public ManageProduct(Product wybranyProdukt)
        {
            InitializeComponent();
            this.wybranyProdukt = wybranyProdukt;
            labelTytul.Text = "Edytuj produkt";
            entryNazwa.Text = wybranyProdukt.Name;
            entryCena.Text = wybranyProdukt.Price.ToString();
            entryIlosc.Text = wybranyProdukt.Count.ToString();
            btnDodaj.IsVisible = false;
            btnEdytuj.IsVisible = true;
        }

        private void BtnDodajClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryNazwa.Text) && !string.IsNullOrEmpty(entryCena.Text) && !string.IsNullOrEmpty(entryIlosc.Text))
            {
                if (int.TryParse(entryIlosc.Text, out int _) && decimal.TryParse(entryCena.Text, out decimal _))
                {
                    var produkt = new Product(Guid.NewGuid().ToString() ,entryNazwa.Text, decimal.Parse(entryCena.Text), int.Parse(entryIlosc.Text));
                    WriteToFile(produkt);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Niepoprawne dane", "Pola cena i ilość muszą być liczbami", "OK");
                }
            }
            else
            {
                DisplayAlert("Niepoprawne dane", "Pola nie mogą byc puste", "OK");
            }
        }

        private void BtnEdytujClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryNazwa.Text) && !string.IsNullOrEmpty(entryCena.Text) && !string.IsNullOrEmpty(entryIlosc.Text))
            {
                if (int.TryParse(entryIlosc.Text, out int _) && decimal.TryParse(entryCena.Text, out decimal _))
                {
                    wybranyProdukt.Name = entryNazwa.Text;
                    wybranyProdukt.Price = decimal.Parse(entryCena.Text);
                    wybranyProdukt.Count = int.Parse(entryIlosc.Text);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Niepoprawne dane", "Pola cena i ilość muszą być liczbami", "OK");
                }
            }
            else
            {
                DisplayAlert("Niepoprawne dane", "Pola nie mogą byc puste", "OK");
            }
        }

        private static void WriteToFile(Product produkt)
        {
            List<string> outputFile = new List<string>();
            string line = $"{produkt.ID};{produkt.Name};{produkt.Price};{produkt.Count}";
            outputFile.Add(line);
            File.WriteAllLines(FileClass.GetFilePath(), outputFile);
        }
    }
}