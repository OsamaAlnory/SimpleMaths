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
	public partial class Page1 : StackLayout
	{
		public Page1 ()
		{
			InitializeComponent ();
            lbl.Text = "SimpleMaths is a simple tool which helps you to understand some mathematical concepts. "
            + "Using algorithms has made is easier to understand both mathematics and physics. "
            + "Imagine how difficult the life and the whole world would be without algorithms!";
        }

        public void Stop()
        {
            animation.Pause();
        }

	}
}