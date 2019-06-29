using Rg.Plugins.Popup.Extensions;
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
	public partial class Page3 : StackLayout
	{
        private PopupComponent pop;

		public Page3 (PopupComponent pop)
		{
            this.pop = pop;
			InitializeComponent ();
            lbl.Text = "If you have any idea that you want to share with us, don't hesitate "
                +"to post it and make us know about it.";
		}

        public void Stop()
        {
            animation.Pause();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            pop.OnClosed();
            await Navigation.PopPopupAsync();
        }
    }
}