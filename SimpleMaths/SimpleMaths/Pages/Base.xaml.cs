using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMaths.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Base : ContentPage
	{
		public Base (string title, params View[] views)
		{
			InitializeComponent ();
            Title = title;
            bkg.Source = App.GetSource("background1.png");
            List<Framed> sc = new List<Framed>();
            foreach(View stk in views)
            {
                sc.Add(new Framed(stk));
            }
            carousel.ItemsSource = sc;
        }

    }
}