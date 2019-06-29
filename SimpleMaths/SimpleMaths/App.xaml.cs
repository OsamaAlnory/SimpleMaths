using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SimpleMaths
{
    public partial class App : Application
    {
        public static readonly string PATH = "SimpleMaths.Images.";

        public App()
        {
            InitializeComponent();
            MainPage = new Pages.MainMenu();
        }

        public static ImageSource GetSource(string name)
        {
            return ImageSource.FromResource(PATH + name, Assembly.GetExecutingAssembly());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
