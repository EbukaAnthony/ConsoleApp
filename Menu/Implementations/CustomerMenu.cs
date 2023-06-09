using System;
using System.Collections.Generic;
using TrainStationManagementApp.Managers.Implementations;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Menu.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Menu.Implementations
{
    public class CustomerMenu : ICustomerMenu
    {
        
        IBookingManager bookingManager = new BookingManager();
        IRouteManager routeManager = new RouteManager();
        IUserManager userManager = new UserManager();

        public void CreateBookingMenu(string userEmail)
        {
            IRouteManager routeManager = new RouteManager();
            Console.WriteLine();
            Console.WriteLine("Create Booking Menu");
            Console.Write($"Enter Route Name ({routeManager.RouteToOption()}): ");
            int routeId = int.Parse(Console.ReadLine());
            var booking = bookingManager.CreateBooking(userEmail, routeId);
            if(booking != null)
            {
                Console.WriteLine("Booking Succesful");
                Console.WriteLine();
                Console.WriteLine("Booking Details");
                Console.WriteLine($"Booking Id: {booking.Id}");
                Console.WriteLine($"ReferenceNumber: {booking.ReferenceNumber}");
                Console.WriteLine($"CustomerEmail: {booking.CustomerEmail}");
                Console.WriteLine($"SeatNumber: {booking.SeatNumber}");
            }
        }
        public void FundWalletMenu(string userEmail)
        {
            Console.WriteLine();
            Console.WriteLine("Fund Wallet Menu");
            Console.Write($"Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            var fundWallet = userManager.FundUserWallet(userEmail, amount);
        }

        public void RealCustomerMenu(string userEmail)
        {
            MainMenu mainMenu = new MainMenu();
            Console.WriteLine("");
            Console.WriteLine("Customer Dashboard");
            Console.WriteLine("Enter 1 to View Profile \nEnter 2 to Fund Wallet \nEnter 3 to View all Route \nEnter 4 to Create Booking \nEnter 5 to View Booking  \nEnter 6 to View All Booking \nEnter 0 to Go Back");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 0:
                mainMenu.RealMainMenu();
                break;
                case 1:
                ViewProfileMenu(userEmail);
                break;
                case 2:
                FundWalletMenu(userEmail);
                break;
                case 3:
                ViewAllRouteMenu(userEmail);
                break;
                case 4:
                CreateBookingMenu(userEmail);
                break;
                case 5:
                ViewBookingMenu(userEmail);
                break;
                case 6:
                ViewAllBookingMenu(userEmail);
                break;
                default:
                Console.WriteLine("Invalid input");
                break;
            }
            RealCustomerMenu(userEmail);
        }

        public void ViewProfileMenu(string userEmail)
        {
            Console.WriteLine();
            Console.WriteLine("Customer Profile Menu");
            var user = userManager.GetUser(userEmail);
            if (user == null)
            {
                Console.WriteLine("customer not found");
            }
            else{
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"FirstName: {user.FirstName}");
                Console.WriteLine($"LastName: {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Wallet: {user.Wallet}");
            }
        }

        public void ViewAllBookingMenu(string userEmail)
        {
            Console.WriteLine();
            Console.WriteLine("View All Booking Menu");
            var bookings = bookingManager.GetALLBooking();
            if (bookings.Count > 0)
            {
                var bookLists = new List<Booking>();
                foreach (var booking in bookings)
                {
                    if ( booking.CustomerEmail == userEmail)
                    {
                        bookLists.Add(booking);
                    }
                }

                if (bookLists.Count > 0)
                {
                    Console.WriteLine($"Id \tReferenceNumber \tName \tSeatNumber \tCustomerEmail");
                    foreach (var bookList in bookLists)
                    {
                        var route = routeManager.GetRoute(bookList.RouteId);
                        Console.WriteLine($"{bookList.Id}\t{bookList.ReferenceNumber}\t{route.Name}\t{bookList.SeatNumber}\t{bookList.CustomerEmail}");
            
                    }
                }
                else
                {
                    Console.WriteLine("Booking not found");
                }
            }
            else{
                
                System.Console.WriteLine("No Booking found!");
            }
        }

        public void ViewBookingMenu(string userEmail)
        {
            Console.WriteLine();
            Console.WriteLine("View Booking Menu");
            Console.Write($"Enter Reference Number: ");
            string referenceNumber = Console.ReadLine();
            var booking = bookingManager.GetBooking(referenceNumber);
            if (booking == null)
            {
                Console.WriteLine("Booking not found");
            }
            else{
                var route = routeManager.GetRoute(booking.RouteId);
                Console.WriteLine($"Id \tReferenceNumber \tName \tSeatNumber \tCustomerEmail");
                Console.WriteLine($"{booking.Id}\t{booking.ReferenceNumber}\t{route.Name}\t{booking.SeatNumber}\t{booking.CustomerEmail}");
            }
        }
    
        
        public void ViewAllRouteMenu(string userEmail)
        {
            Console.WriteLine();
            Console.WriteLine("View all Route Menu");
            var routes = routeManager.GetRouteByDeleteStatatu(false);
            if (routes.Count > 0 )
            {  
                Console.WriteLine($"Id \tName \tDestination \tTakeOffPoint \tTakeOffTime \tLandingTime \tPrice \tCapacity \t AvailableSpace");   
                foreach (var route in routes)
                {
                    if (DateTime.Now >= route.TakeOffTime)
                    {
                        Console.WriteLine($"{route.Id} \t{route.Name} \t{route.Destination} \t{route.TakeOffPoint} \t{route.TakeOffTime} \t{route.LandingTime} \t{route.Price} \t{route.Capacity} \t{route.AvailableSpace}");
                    }
                    
                }   
            }
            else
            {
                Console.Write("Route not found");
            }
        }
    
    }
}