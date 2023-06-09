using System;

namespace TrainStationManagementApp.Models
{
    public class Manager : BaseEntity
    {
        public int UserId { get; set; }
        public string StaffNumber { get; set; }


        public Manager(int id, int userId, string staffNumber, bool isDeleted, DateTime dateCreated, DateTime dateUpdated) : base (id, isDeleted, dateCreated, dateUpdated)
        {
            UserId = userId;
            StaffNumber = staffNumber;
        }     
        
    }
}