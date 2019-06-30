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
	public partial class Framed : AbsoluteLayout
	{
		public Framed (View content)
		{
			InitializeComponent ();
            scroll.Content = content;
		}
	}
}