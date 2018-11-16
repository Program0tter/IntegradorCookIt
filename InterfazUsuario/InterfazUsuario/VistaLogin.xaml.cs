using InterfazUsuario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazUsuario
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaLogin : ContentPage
	{
        DataService dataservice = new DataService();
		public VistaLogin ()
		{
			InitializeComponent ();
		}

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try {
                await dataservice.GetClienteASync(txtEmail.Text, txtContraseña.Text);
            }catch(Exception ex)
            {
                await DisplayAlert("Error", "Error al loggearse: " + ex.Message, "ok");
            }
        }
    }
}