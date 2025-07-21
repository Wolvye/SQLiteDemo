using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDemo.MVVM.Models;


namespace SQLiteDemo.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }


        public CustomerRepository()
        {
            connection =
                new SQLiteConnection(Constants.DatabasePath,
                Constants.Flags);
            connection.CreateTable<Customer>();
        }
        public void AddOrUpdate(Customer customer)
        {
            int result = 0;
            try
            {
                if (customer.ID != 0)
                {
                    result = connection.Update(customer);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    connection.Insert(customer);
                    StatusMessage = $"{result} row(s) added";
                }

            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Error: {ex.Message}";
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                         $"Error: {ex.Message}";
            }
            return null;
        }

        public List<Customer> GetAll2()
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                         $"Error: {ex.Message}";
            }
            return null;
        }

        public Customer Get(int id)
        {
            try
            {
                return
                    connection.Table<Customer>()
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

    }

}
