using SimpleMaths.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMaths.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenu : ContentPage
	{
        bool ROTATED = false;
        bool WAITING = false;
         
       

		public MainMenu ()
		{
           var y = DateTime.Now.Year.ToString();
            InitializeComponent ();
            bkg.Source = App.GetSource("background.png");
            UI.ImagedButton.LoadAny(layout);
            about.Text = "This app was created by Smart_Soft.\n\n"+
                "Copyright © "+y+" all rights reserved.\n\n"+
                "Contact us at: developing@programmer.net";
            var _first = !App.Current.Properties.ContainsKey("opened");
            if (_first)
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                    new Popup(new StartupPopup(), this) { Closeable = false }.Show();
                    return false;
                });
            }
        }

        private void evt(object e, EventArgs args)
        {
            var x = new Content._GoldenRatio();
            Navigation.PushAsync(new Base("Phi", getChildren(x)));
        }

        private View[] getChildren(StackLayout layout)
        {
            var VIEWS = new View[layout.Children.Count];
            for(int x = 0; x < layout.Children.Count; x++)
            {
                VIEWS[x] = layout.Children[x];
            }
            return VIEWS;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (WAITING)
            {
                return;
            }
            ROTATED = !ROTATED;
            WAITING = true;
            if (ROTATED)
            {
                await stk1.RotateYTo(180, 300, Easing.SinIn);
                stk1.IsVisible = false;
                stk2.RotationY = 0;
                stk2.IsVisible = true;
            } else
            {
                await stk2.RotateYTo(180, 300, Easing.SinIn);
                stk2.IsVisible = false;
                stk1.RotationY = 0;
                stk1.IsVisible = true;
            }
            WAITING = false;
        }

        private void Ifsats_Clicked(object e, EventArgs args)
        {
            var x = new Content._Ifsats();
            Navigation.PushAsync(new Base("If statement", getChildren(x)));
        }
    }
}