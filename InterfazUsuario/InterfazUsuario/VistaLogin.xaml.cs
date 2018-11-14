
using InterfazUsuario.Modelo;
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
		public VistaLogin ()
		{
			InitializeComponent ();
		}

        private void btnLogin_Clicked(object sender, EventArgs e)
        {

            Cliente cli = new Cliente();
            try {
                cli = (Cliente) cli.Login(txtEmail.Text, txtContraseña.Text);
            }catch(Exception ex)
            {
                DisplayAlert("Error", "Error al loggearse: " + ex.Message, "ok");
            }
        }
    }
}