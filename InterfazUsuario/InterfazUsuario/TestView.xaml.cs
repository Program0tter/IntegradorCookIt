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
	public partial class TestView : ContentView
	{
		public TestView ()
		{
			InitializeComponent ();
		}

        private void Button_Click(object sender, EventArgs e)
        {

        }
	}
}