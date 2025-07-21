using SQLiteDemo.Repositories;
using SQLiteDemo.MVVM.Views;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo
{
    public partial class App : Application
    {
        //public static CustomerRepository CustomerRepo { get;  set; }
        public static BaseRepository<Customer> CustomerRepo { get; set; }
        public static BaseRepository<Order> OrdersRepo { get; set; }
        public App(BaseRepository<Customer> repo, MainPage mainPage, BaseRepository<Order> ordersRepo)
        {
            InitializeComponent();

            CustomerRepo = repo;
            OrdersRepo = ordersRepo;
            MainPage = mainPage;
        }
    }
}
