using SQLiteDemo.Repositories;
using SQLiteDemo.MVVM.Views;

namespace SQLiteDemo
{
    public partial class App : Application
    {
        public static CustomerRepository CustomerRepo { get; private set; }

        public App(CustomerRepository repo, MainPage mainPage)
        {
            InitializeComponent();

            CustomerRepo = repo;
            MainPage = mainPage;
        }
    }
}
