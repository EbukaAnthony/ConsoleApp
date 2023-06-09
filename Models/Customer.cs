using System;

namespace TrainStationManagementApp.Models
{
    public class Customer : BaseEntity
    {
       public int UserId { get; set; } 


       public Customer(int userId, int id, bool isDeleted, DateTime dateCreated, DateTime dateUpdated) : base (id, isDeleted, dateCreated, dateUpdated)
       {
           UserId = userId;
       }
    }
}