using SimpleMaths.Layout;
using SimpleMaths.Tools;
using SimpleMaths.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SimpleMaths
{
    public partial class App : Application
    {
        public static readonly string NAME = "Simple Algorithms";
        public static readonly string PATH = "SimpleMaths";
        public static Language lang = Language.EN;
        public static Dictionary<string, string> STRINGS = new Dictionary<string, string>();
        public static Encoding en = Encoding.GetEncoding(28591);
        public static Page CurrentPage;

        public App()
        {
            InitializeComponent();
            LoadStrings();
            MainPage = new NavigationPage(new Pages.MainMenu());
        }

        public static void SendError(string msg)
        {
            new Popup(new ErrorMessage(msg), CurrentPage).Show();
        }

        public static string getString(string key)
        {
            return STRINGS.ContainsKey(key) ? STRINGS[key] : "null";
        }

        public static void SetLanguage(Language l)
        {
            lang = l;
            STRINGS.Clear();
            LoadStrings();
        }

        public static void RefreshTranslatables(View container)
        {
            if (container is Translatable)
            {
                ((Translatable)container).OnRefresh();
            }
            else if (container is Layout<View>)
            {
                var _x = container as Layout<View>;
                foreach (View v in _x.Children)
                {
                    RefreshTranslatables(v);
                }
            }
            else if (container is ContentView)
            {
                RefreshTranslatables(((ContentView)container).Content);
            }
            else if (container is ScrollView)
            {
                RefreshTranslatables(((ScrollView)container).Content);
            }
        }

        public static void LoadStrings()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream(PATH+".Data."+lang.getFileName());
            using (var reader = new System.IO.StreamReader(stream, en))
            {
                string line = "";
                string _KEY = null;
                bool started = false;
                bool br = false;
                string value = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (!started)
                    {
                        var KEY = line.Split(':');
                        if(KEY.Length == 2)
                        {
                            _KEY = KEY[0];
                            started = true;
                        }
                    } else
                    {
                        if(line == "<end>")
                        {
                            if(_KEY != null)
                            {
                                STRINGS.Add(_KEY, value);
                                started = false;
                                br = false;
                                _KEY = null;
                                value = "";
                            }
                        } else
                        {
                            if (br)
                            {
                                if (!line.StartsWith("<nobr>"))
                                {
                                    value += "\n";
                                    br = false;
                                }
                                else
                                {
                                    line = line.Substring(6);
                                }
                            }
                            br = true;
                            line = line.Replace("%name%", NAME);
                            value += line;
                        }
                    }
                }
            }
        }

        public static ImageSource GetSource(string name)
        {
            return ImageSource.FromResource(PATH + ".Images." + name, Assembly.GetExecutingAssembly());
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
