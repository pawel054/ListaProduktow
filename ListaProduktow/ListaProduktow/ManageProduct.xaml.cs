using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    }
}