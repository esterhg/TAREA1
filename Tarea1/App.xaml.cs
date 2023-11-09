namespace Tarea1
{
    public partial class App : Application
    {
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
            }
        }
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaPage());
        }
    }
}