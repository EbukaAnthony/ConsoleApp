using System;
using System.Collections.Generic;
using TrainStationManagementApp.Enum;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        public static List<User> userDatabase = new List<User>()
        {
            new User(1, "Michael", "ALpha", "ma@gmail.com", "1020", "08161778965", Gender.Male, "Abk", 0.0m, RoleName.SuperAdmin, false, DateTime.Now, DateTime.Now),
            new User(2, "Kim", "Jojo", "kj@gmail.com", "1221", "09048448280", Gender.Female, "Ibd", 0.0m, RoleName.Manager, false, DateTime.Now, DateTime.Now),
            new User(3, "Jerry", "White", "jw@gmail.com", "1320", "08053370430", Gender.Male, "Abj", 50000.0m, RoleName.Customer, false, DateTime.Now, DateTime.Now),
            
        };
        public bool DeleteUser(string email)
        {
           var user = TryGet(email);
           if (user == null)
           {
               return false;
           }
           user.IsDeleted = true;
           return true;
        }

        public bool FundUserWallet(string email, decimal amount)
        {
            var user = TryGet(email);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }
            user.Wallet = user.Wallet + amount;
            Console.WriteLine($"Wallet fund successfully");
            return true;
        }
        

        public bool FundUserWallet(int id, decimal amount)
        {
            var user = GetUser(id);
            if (user != null)
            {
                user.Wallet += amount;
                return true;
            }
            return false;
        }

        public List<User> GetALLUser()
        {
            return userDatabase;
        }

        public User GetUser(int id)
        {
            foreach (var user in userDatabase)
            {
                if (user.Id == id)
                {
                   return user; 
                }
            }
            return null;
        }

        public User GetUser(string email)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
           return null; 
        }

        public User LoginUser(string email, string password)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email && user.Password == password && user.IsDeleted == false)
                {
                    return user;
                }
            }
            return null;
        }

        public User RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber, Gender gender, string address, RoleName role)
        {
            var user = TryGet(email);
            if (user == null)
            {
               int id = userDatabase.Count + 1;
               var newUser = new User(id, firstName, lastName, email, password, phoneNumber, gender, address, 0.0m,  role, false, DateTime.Now, DateTime.Now); 
               userDatabase.Add(newUser);
               return newUser;
            }
            return null;
        }

        public User UpdateUser(int id, string firstName, string lastName, string phoneNumber, Gender gender, string address)
        {
            var userExist = TryGet(id);
            if (userExist == null)
            {
                return null;
            }
                userExist.FirstName = firstName;
                userExist.LastName = lastName;
                userExist.PhoneNumber = phoneNumber;
                userExist.Gender = gender;
                userExist.Address = address;
                return userExist;
        }

        private User TryGet(int id)
        {
            foreach (var user in userDatabase)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
        private User TryGet(string email)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }


    }
}