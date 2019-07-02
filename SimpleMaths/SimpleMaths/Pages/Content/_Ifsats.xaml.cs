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
    public partial class _Ifsats : StackLayout
    {
        private bool RESET = false;
        private bool WAITING = false;
        private double VAL = 0;
        public _Ifsats()
        {
            InitializeComponent();
            display.Text = entry.Text + "";
            resultstak.IsVisible = false;
        }

        private void Check_Clicked(object sender, EventArgs e)
        {
            if (!RESET && WAITING)
            {
                return;
            }
            if (RESET)
            {
                button.BackgroundColor = (Color)Application.Current.Resources["BtnColor"];
                button.Text = "Check";
            }
            else
            {
                try
                {
                    VAL = int.Parse(entry.Text);
                }
                catch (Exception ex)
                {

                    App.SendError("The Value must be a valid number.");
                    return;
                }
                WAITING = true;
                display.Text = VAL + "";
                resultstak.IsVisible = true;
                button.BackgroundColor = Color.DarkRed;
                button.Text = "Reset";
                Run();
                 
            }
            RESET = !RESET;
        }

        private void Run()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () => {
                if (VAL == 10)
                {
                     
                    Output.Text = "Output:\nThe value of X equals to 10";
                    Output.TextColor = Color.Green;
                }
                else
                {
                     
                    Output.Text = "Output:\nValue of X is not equal to 10";
                    Output.TextColor = Color.DarkRed;
                }
                if (!RESET)
                {
                    WAITING = false;
                    resultstak.IsVisible = false;
                }
                return RESET;
            });
        }
    }
}