using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMaths.Layout.Startup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : StackLayout
	{
		public Page2 ()
		{
			InitializeComponent ();
            lbl.Text = "This app is still in its first stages and new versions will be coming to bring more features and stuff!";
        }

        public void Stop()
        {
            animation.Pause();
        }

    }
}