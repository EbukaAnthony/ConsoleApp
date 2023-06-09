using System;
using TrainStationManagementApp.Enum;

namespace TrainStationManagementApp.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public decimal Wallet  { get; set; }
        public RoleName Role { get; set; }


        public User(int id, string firstName, string lastName, string email, string password, string phoneNumber, Gender gender, string address, decimal wallet, RoleName role, bool isDeleted, DateTime dateCreated, DateTime dateUpdated) : base (id, isDeleted, dateCreated, dateUpdated)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email; 
            Password = password;
            PhoneNumber = phoneNumber;
            Gender = gender; 
            Address = address; 
            Wallet = wallet;
            Role = role;
        }
    }
}