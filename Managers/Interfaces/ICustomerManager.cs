using System.Collections.Generic;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Interfaces
{
    public interface ICustomerManager
    {
       public Customer GetCustomer (int id); 
       public Customer GetCustomer (string email);
       public List<Customer> GetAllCustomer (); 
    }
}