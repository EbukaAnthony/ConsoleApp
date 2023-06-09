using System;

namespace TrainStationManagementApp.Models
{
    public class Route : BaseEntity
    {
     
       public string Name { get; set; } 
       public string TakeOffPoint { get; set; } 
       public string Destination { get; set; } 
       public DateTime TakeOffTime { get; set; }
       public DateTime LandingTime { get; set; } 
       public decimal Price { get; set; } 
       public int Capacity { get; set; } 
       public int AvailableSpace { get; set; } 

       
       public Route(int id, string name, string takeOffPoint, string destination, DateTime takeOffTime, DateTime landingTime, decimal price, int capacity, int availableSpace, DateTime dateCreated, DateTime dateUpdated, bool isDeleted) : base (id, isDeleted, dateCreated, dateUpdated)
       {
           Name = name;
           TakeOffPoint = takeOffPoint;
           Destination = destination;
           TakeOffTime = takeOffTime; 
           LandingTime = landingTime;
           Price = price;
           Capacity = capacity;
           AvailableSpace = availableSpace;
       }

    }
}