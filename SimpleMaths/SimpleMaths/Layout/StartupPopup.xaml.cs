using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMaths.Layout
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartupPopup : StackLayout, PopupComponent
	{
        private Startup.Page1 pg1;
        private Startup.Page2 pg2;
        private Startup.Page3 pg3;

        public StartupPopup ()
		{
			InitializeComponent ();
            pg1 = new Startup.Page1();
            pg2 = new Startup.Page2();
            pg3 = new Startup.Page3(this);
            carousel.ItemsSource = new ObservableCollection<ScrollView> {
                create(pg1),create(pg2),create(pg3)
            };
		}

        private ScrollView create(View view)
        {
            return new ScrollView { Content = view,Margin=new Thickness(0,0,0,0)};
        }

        public PopupType GetPopupType()
        {
            return PopupType.INPUT;
        }

        public void OnClosed()
        {
            pg1.Stop();
            pg2.Stop();
            pg3.Stop();
        }

    }
}