using System.Collections.Generic;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Interfaces
{
    public interface IBookingManager
    {
       public Booking CreateBooking(string customerEmail, int routeId);
       public Booking GetBooking(int id);
       Booking GetBooking(string referenceNumber);
       public List<Booking> GetALLBooking(); 
       public void DeleteBooking(int id);  
    }
}