using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMaths.Pages.Content
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _GoldenRatio : StackLayout
	{
        private bool RESET = false;
        private bool WAITING = false;
        private double VAL = 0;

		public _GoldenRatio ()
		{
			InitializeComponent ();
            display.Text = entry.Text + "";
		}

        private void button_Clicked(object sender, EventArgs e)
        {
            if (!RESET && WAITING)
            {
                return;
            }
            if (RESET)
            {
                button.BackgroundColor = (Color)Application.Current.Resources["BtnColor"];
                button.Text = "Start";
            } else
            {
                try
                {
                    VAL = double.Parse(entry.Text);
                }
                catch (Exception ex)
                {
                    App.SendError("The input must be a valid number.");
                    return;
                }
                WAITING = true;
                display.Text = VAL + "";
                button.BackgroundColor = Color.DarkRed;
                button.Text = "Reset";
                Run();
            }
            RESET = !RESET;
        }

        private void Run()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () => {
                VAL = 1 + (1 / VAL);
                display.Text = VAL + "";
                if (!RESET)
                {
                    WAITING = false;
                }
                return RESET;
            });
        }

    }
}