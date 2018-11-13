using InterfazUsuario.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows;

namespace InterfazUsuario
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ClickBotonLogin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new VistaLogin()));
        }
    }
}
