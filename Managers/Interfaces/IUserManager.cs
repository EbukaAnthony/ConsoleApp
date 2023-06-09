using System.Collections.Generic;
using TrainStationManagementApp.Enum;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Interfaces
{
    public interface IUserManager
    {
        public User LoginUser(string email, string password);
        public User RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber, Gender gender, string address,  RoleName role);
        public User GetUser(int id);
        public User GetUser(string email);
        public List<User> GetALLUser();
        public bool FundUserWallet(string email, decimal amount);
        public bool FundUserWallet(int id, decimal amount);
        public User UpdateUser(int id, string firstName, string lastName, string phoneNumber, Gender gender, string address);
        public bool DeleteUser(string email);
    }
}