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

        public _Ifsats()
        {
            InitializeComponent();
            resultstak.IsVisible = false;
        }

        private void Check_Clicked(object sender, EventArgs e)
        {
            int VAL = 0;
                try
                {
                    VAL = int.Parse(entry.Text);
                }
                catch (Exception ex)
                {

                    App.SendError("The value must be a valid number.");
                    return;
                }
            if (VAL == 10)
            {

                Output.Text = "Output:\nThe value of X equals to 10";
                Output.TextColor = Color.Green;
            }
            else
            {

                Output.Text = "Output:\nValue of X is not equal 10";
                Output.TextColor = Color.DarkRed;
            }
            resultstak.IsVisible = true;
        }

    }
}