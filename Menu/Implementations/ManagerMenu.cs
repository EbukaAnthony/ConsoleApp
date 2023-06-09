using System;
using System.Collections.Generic;
using TrainStationManagementApp.Enum;
using TrainStationManagementApp.Managers.Implementations;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Menu.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Menu.Implementations
{
    public class ManagerMenu : IManagerMenu
    {
        IRouteManager routeManager = new RouteManager();
        IUserManager userManager = new UserManager();
        
        public void RealManagerMenu(string email)
        {
            MainMenu mainMenu = new MainMenu();
            Console.WriteLine("");
            Console.WriteLine("Manager Dashboard");
            Console.WriteLine("Enter 1 to Create Route \nEnter 2 to View Route \nEnter 3 to View all Route \nEnter 4 to Delete Route \nEnter 5 to Update Route \nEnter 6 to View Customer \nEnter 7 to View all Customer \nEnter 8 to Update Customer \nEnter 9 to View Profile \nEnter 0 to Go Back");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                mainMenu.RealMainMenu();
                break;
                case 1:
                CreateRouteMenu();
                break;
                case 2:
                ViewRouteMenu();
                break;
                case 3:
                ViewAllRouteMenu();
                break;
                case 4:
                DeleteRouteMenu();
                break;
                case 5:
                UpdateRouteMenu();
                break;
                case 6:
                ViewCustomerMenu();
                break;
                case 7:
                ViewAllCustomerMenu();
                break;
                case 8:
                ViewAllCustomerMenu();
                break;
                case 9:
                ViewProfileMenu(email);
                break;
                default:
                Console.WriteLine("Invalid input");
                break;
            }
            RealManagerMenu(email);
        }


        

        public void ViewProfileMenu(string userEmail)
        {
            Console.WriteLine();
            Console.WriteLine("Manager Profile Menu");
            var user = userManager.GetUser(userEmail);
            if (user == null)
            {
                Console.WriteLine("Manager not found");
            }
            else{
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"FirstName: {user.FirstName}");
                Console.WriteLine($"LastName: {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Wallet: {user.Wallet}");
            }
        }

        public void CreateRouteMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Create Route");
            Console.Write("Enter route name: ");
            string routeName = Console.ReadLine();

            Console.Write("Enter take off point: ");
            string takeOffPoint = Console.ReadLine();

            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter take off time: ");
            DateTime takeOffTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter landing time: ");
            DateTime landingTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter capacity: ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            var route = routeManager.CreateRoute(routeName, takeOffPoint, destination, DateTime.Now, DateTime.Now, price, capacity);
            if (route == null)
            {
                Console.WriteLine("Unable to create the route!");
            }
            else{
                Console.WriteLine("route created!");
            }
        }

        public void DeleteRouteMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Delete Route");
            Console.Write("Enter route name: ");
            string routeName = Console.ReadLine();
            var route = routeManager.GetRoute(routeName);
            if (route != null)
            {
                var deleteRoute = routeManager.DeleteRoute(route.Id); 
                if (deleteRoute == true)
                {
                    Console.WriteLine("Deleted successfully");
                }
                else
                {
                    Console.WriteLine("Unable to delete");
                }
            }
            else
            {
                Console.WriteLine("Route not found");
            }
        }

        

        public void UpdateCustomerMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Update Customer");

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your gender(1 for male and 2 for female): ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();

            var user = userManager.GetUser(email);
            if (user == null)
            {
                Console.WriteLine("Customer not exist");
            }
            else
            {
                var useUpdate = userManager.UpdateUser(user.Id, firstName, lastName, phoneNumber, gender, address);
                var messager = useUpdate == null ? "Customer not updated!" : "updated successful";
                Console.WriteLine(messager);
            }
            
        }

        public void UpdateRouteMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Update Route");

            Console.Write("Enter route name: ");
            string routeName = Console.ReadLine(); ;

            Console.Write("Enter take off point: ");
            string takeOffPoint = Console.ReadLine();

            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter take off time: ");
            DateTime takeOffTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter landing time: ");
            DateTime landingTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter capacity: ");
            int capacity = Convert.ToInt32(Console.ReadLine());
            
            var route = routeManager.GetRoute(routeName);
            if (route == null)
            {
                Console.WriteLine("Route not exist");
            }
            else
            {
                var routeUpdate = routeManager.UpdateRoute(routeName, takeOffPoint, destination, takeOffTime, landingTime, price, capacity);
                var messager = routeUpdate == null ? "Route not updated!" : "Route successful";
                Console.WriteLine(messager);
            }
        }

        public void ViewCustomerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("View Customer Menu");
            Console.Write("Enter Customer Email: ");
            string email = Console.ReadLine();
            var customer = userManager.GetUser(email);
            if (customer != null)
            {
                Console.WriteLine($"Id \tFirstName \tLastName \tEmail \tWallet");   
                Console.WriteLine($"{customer.Id} \t{customer.FirstName} \t{customer.LastName} \t{customer.Email} \t{customer.Wallet} ");   
            }
            else
            {
                Console.Write("Customer not found");
            }
        }

        public void ViewRouteMenu()
        { 
            Console.WriteLine();
            Console.WriteLine("View a Route Menu");
            Console.Write("Enter Route Name: ");
            string name = Console.ReadLine();
            var route = routeManager.GetRoute(name);
            if (route != null)
            {  
                Console.WriteLine($"Id \tName \tDestination \tTakeOffPoint \tTakeOffTime \tLandingTime \tPrice \tCapacity \tAvailableSpace");   
                Console.WriteLine($"{route.Id} \t{route.Name} \t{route.Destination} \t{route.TakeOffPoint} \t{route.TakeOffTime} \t{route.LandingTime} \t{route.Price} \t{route.Capacity} \t{route.AvailableSpace}");   
            }
            else
            {
                Console.Write("Route not found");
            }
        }

        public void ViewAllRouteMenu()
        {
            Console.WriteLine();
            Console.WriteLine("View all Route Menu");
            var routes = GetRouteByDeleteStatatu(false);
            if (routes.Count > 0)
            {  
        
                Console.WriteLine($"Id \tName \tDestination \tTakeOffPoint \tTakeOffTime \tLandingTime \tPrice \tCapacity \t AvailableSpace");   
                foreach (var route in routes)
                {
                    Console.WriteLine($"{route.Id} \t{route.Name} \t{route.Destination} \t{route.TakeOffPoint} \t{route.TakeOffTime} \t{route.LandingTime} \t{route.Price} \t{route.Capacity} \t{route.AvailableSpace}");
                }   
            }
            else
            {
                Console.Write("Route not found");
            }
        }

        public void ViewAllCustomerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("View All Customer Menu");
            var users = userManager.GetALLUser();
            if (users.Count > 0)
            {    
                var customerList = new List<User>();   
                foreach (var user in users)
                {
                    if (user.Role == RoleName.Customer)
                    {   
                        customerList.Add(user);
                    }
                } 

                if (customerList.Count > 0)
                {
                    Console.WriteLine($"Id \tFirstName \tLastName \tEmail \tWallet");
                    foreach (var customer in customerList)
                    {
                        Console.WriteLine($"{customer.Id} \t{customer.FirstName} \t{customer.LastName} \t{customer.Email} \t{customer.Wallet}");
                    } 
                }
                else
                {
                    Console.WriteLine("Customer not found");
                }

            }
            else
            {
                Console.Write("Customer not found");
            }
        }


        private List<Route> GetRouteByDeleteStatatu(bool isDeleted)
        {
            var routes = routeManager.GetAllRoute();
            var newList = new List<Route>();
            foreach (var route in routes)
            {
                if (route.IsDeleted == isDeleted)
                {
                    newList.Add(route);
                }
            } 

            return newList;
        }
    }
}