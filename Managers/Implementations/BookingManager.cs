using System;
using System.Collections.Generic;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Implementations
{
    public class BookingManager : IBookingManager
    {
        public static List<Booking> bookingDatabase = new List<Booking>();
        ICustomerManager customerManager = new CustomerManager();
        IRouteManager routeManager = new RouteManager();
        IUserManager userManager = new UserManager();
        
        public Booking CreateBooking1(string customerEmail, int routeId)
        {
            
            var customer = customerManager.GetCustomer(customerEmail);
            var route = routeManager.GetRoute(routeId);
            if(route != null)
            {
                //if(route.TakeOffTime < DateTime.UtcNow)
                if(customer != null)
                {
                    var user = userManager.GetUser(customerEmail);
                    if(route.Price < user.Wallet)
                    {
                        Booking booking = new Booking(bookingDatabase.Count+1,customerEmail,routeId,"clh/",7);
                        bookingDatabase.Add(booking);
                        return booking;
                    }
                    else{
                         System.Console.WriteLine("insufficient fund");
                         userManager.FundUserWallet(customerEmail, route.Price);
                    }
                   
                }
                System.Console.WriteLine("wrong email");
                return null;
            }
            System.Console.WriteLine("route not available");
            return  null;
        }


        public Booking CreateBooking(string customerEmail, int routeId)
        {
            
            var route = routeManager.GetRoute(routeId);
            if (route == null)
            {
                Console.WriteLine("Route not found");
                return null;
            }
            else if (route.AvailableSpace < 1)
            {
                Console.WriteLine("No Available space.");
                return null;
            }
            else
            {
                var user = userManager.GetUser(customerEmail);
                decimal bookingPrice = route.Price;
                if (user.Wallet < bookingPrice)
                {
                    System.Console.WriteLine("insufficient fund");
                    return null;
                }

                user.Wallet -= bookingPrice;
                userManager.FundUserWallet(2, bookingPrice);
                

                int seatNumber = (route.Capacity - route.AvailableSpace) + 1;
                var booking = new Booking( bookingDatabase.Count + 1, customerEmail, routeId, GenerateReferenceNumber(), seatNumber);
               
                route.AvailableSpace -= 1;
                bookingDatabase.Add(booking);
                return booking;
            }


        }

        public void DeleteBooking(int id)
        {
            var booking = TryGet(id);
            if (booking == null)
            {
                Console.WriteLine("Booking does not exist");
            }
            bookingDatabase.Remove(booking);
            Console.WriteLine("Deleted Successfully");
        }

        public List<Booking> GetALLBooking()
        {
            return bookingDatabase;
        }

        public Booking GetBooking(int id)
        {
            foreach (var booking in bookingDatabase)
            {
                if (booking.Id == id)
                {
                    return booking;
                }
            }
            return null;
        }

        public Booking GetBooking(string referenceNumber)
        {
            foreach (var booking in bookingDatabase)
            {
                if (booking.ReferenceNumber == referenceNumber)
                {
                    return booking;
                }
            }
            return null;
        }

        private Booking TryGet(int id)
        {
            foreach (var booking in bookingDatabase)
            {
                if (booking.Id == id)
                {
                    return booking;
                }
            }
            return null;
        }

        private string GenerateReferenceNumber()
        {
            return $"TSM/{DateTime.Now.Month}/{DateTime.Now.Day}/{bookingDatabase.Count + 1}";
        }
    }
}