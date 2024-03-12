using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public MainPage()
        {
            InitializeComponent();
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
    }
}
