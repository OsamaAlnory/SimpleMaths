using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMaths.UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImagedButton : Frame
	{
        public string Text { get; set; }
        public event EventHandler Clicked;
        public string Source { get; set; }
        public Style ButtonStyle { get; set; }


		public ImagedButton ()
		{
            InitializeComponent ();
            BindingContext = this;
        }

        public void load()
        {
            img.Source = App.GetSource(Source);
            button.Text = Text;
            button.Clicked += Clicked;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Clicked;
            img.GestureRecognizers.Add(tap);
            button.Style = ButtonStyle;
        }

        public static void LoadAll(params ImagedButton[] buttons)
        {
            foreach(ImagedButton btn in buttons)
            {
                btn.load();
            }
        }

        public static void LoadAny(View view)
        {
            if(view is ImagedButton)
            {
                ((ImagedButton)view).load();
            } else if(view is Layout<View>)
            {
                var _x = view as Layout<View>;
                foreach(View v in _x.Children)
                {
                    LoadAny(v);
                }
            } else if(view is ContentView)
            {
                LoadAny(((ContentView)view).Content);
            } else if(view is ScrollView)
            {
                LoadAny(((ScrollView)view).Content);
            }
        }

	}
}