using Bogus;
using PropertyChanged;
using SQLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLiteDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public Customer CurrentCustomer { get; set; }

        public ICommand AddOrUpdateCommend {  get; set; }

        public ICommand DeleteCommand { get; set; }

        public MainPageViewModel() 
        {
            Refresh();
            GenerateNewCustomer();

            AddOrUpdateCommend = new Command(async () =>
            {
                App.CustomerRepo.AddOrUpdate(CurrentCustomer);

                Console.WriteLine(App.CustomerRepo.StatusMessage);

                GenerateNewCustomer();
                Refresh();
            });
            DeleteCommand = new Command(() =>
            {
                App.CustomerRepo.Delete(CurrentCustomer.ID);
                Refresh();
            });
        }

        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();
                
        }
        private void Refresh()
        {
            Customers = new ObservableCollection<Customer>(App.CustomerRepo.GetAll() ?? new List<Customer>());

            //Customers = App.CustomerRepo.GetAll(x => x.Name.StartsWith("A")); kleiner Filter


        }
    }
}
