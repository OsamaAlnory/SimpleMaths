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
			InitializeComponent ();
            bkg.Source = App.GetSource("background.png");
            UI.ImagedButton.LoadAny(layout);
            about.Text = "This app was created by Smart_Soft\n\n"+
                "Copyright c all rights reserved.";
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                new Popup(new StartupPopup(), this) { Closeable = false}.Show();
                return false;
            });
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
    }
}