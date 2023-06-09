using System.Collections.Generic;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        IUserManager userManager = new UserManager();
        public static List<Customer> customerDatabase = new List<Customer>();
        public List<Customer> GetAllCustomer()
        {
            return customerDatabase;
        }

        public Customer GetCustomer(int id)
        {
            foreach (var customer in customerDatabase)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer GetCustomer(string email)
        {
           return TryGet(email);
        }

        private Customer TryGet(string email)
        {
            var user = userManager.GetUser(email);
            if (user != null)
            {
                return TryGet(user.Id);
            }
            return null;
        }

        private Customer TryGet(int id)
        {
            foreach (var customer in customerDatabase)
            {
                if (customer.Id == id && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}