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
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
            //aaa.ItemsSource = new ObservableCollection<int> { 1, 2, 3, 4, 5 };
            //aaa.ItemsSource = new ObservableCollection<StackLayout> {
            //    new StackLayout{Children={new Button { Text="5ra"} }},
            //    new StackLayout{Children={new Button { Text="5ra"} }},
            //                    new StackLayout{Children={new Button { Text="5ra"} }}
            //};
        }
	}
}