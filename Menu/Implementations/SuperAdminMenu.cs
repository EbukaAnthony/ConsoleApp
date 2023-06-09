using System;
using TrainStationManagementApp.Enum;
using TrainStationManagementApp.Managers.Implementations;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Menu.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Menu.Implementations
{
    public class SuperAdminMenu : ISuperAdminMenu
    {
        IUserManager userManager = new UserManager();
        IManagerManager managerManager = new ManagerManager();

        public void CreateManagerMenu()
        {
            
            Console.WriteLine();

            Console.WriteLine("Create Manager");

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your gender(1 for male and 2 for female): ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();

            RoleName role = RoleName.Manager;
            var user = userManager.RegisterUser(firstName, lastName, email, password, phoneNumber, gender, address, role);
            if (user == null)
            {
                Console.WriteLine("User already exist!");
            }
            else
            {
                var manager = managerManager.CreateManager(user.Id);
                var messager = manager == null ? "Manager already exist!" : "Register successful";
                Console.WriteLine(messager);
            }
        }

        public void CreateRouteMenu()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteManagerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Delete Manager");

            Console.Write("Enter manager email: ");
            string email = Console.ReadLine();
            var user = userManager.GetUser(email);
            if (user != null && user.Role == RoleName.Manager)
            {
                var deleteUser = userManager.DeleteUser(email);
                if (deleteUser == true)
                {
                    // var manager = managerManager.GetManager(user.Id);
                    // Console.WriteLine($"{manager.Id} {manager.UserId}");
                    Console.WriteLine($"{user.Id} {user.Role}");
                    // var delete = managerManager.DeleteManager(manager.Id);
                    // var messager = delete == false ? "Manager not deleted!" : "Deleted successful";
                    // Console.WriteLine(messager);
                }
            }
            else
            {
                Console.WriteLine("Manager not found!");
            }
             
        }

        public void RealSuperAdminMenu(string email)
        {
            Console.WriteLine();
            Console.WriteLine("Super Admin Dashboard");
            Console.WriteLine("Enter 1 to Create Manager \nEnter 2 to Delete Manager \nEnter 3 to Update Manager \nEnter 4 to Create Route \nEnter 5 to View All Route \nEnter 6 to Viewe All User \nEnter 0 to Go Back");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                break;
                case 1:
                CreateManagerMenu();
                RealSuperAdminMenu(email);
                break;
                case 2:
                DeleteManagerMenu();
                RealSuperAdminMenu(email);
                break;
                case 3:
                UpdateManagerMenu();
                RealSuperAdminMenu(email);
                break;
                case 4:
                DeleteManagerMenu();
                RealSuperAdminMenu(email);
                break;
                case 5:
                DeleteManagerMenu();
                RealSuperAdminMenu(email);
                break;
                case 6:
                VieweAllUserMenu();
                RealSuperAdminMenu(email);
                break;
                default:
                Console.WriteLine("Invalid input");
                break;
            }
        }

        public void UpdateManagerMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Update Manager");

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
                Console.WriteLine("User already exist!");
            }
            else
            {
                var updateUser = userManager.UpdateUser(user.Id, firstName, lastName, phoneNumber, gender, address);
                var messager = updateUser == null ? "Manager not updated!" : "updated successful";
                Console.WriteLine(messager);
            }
        }

        public void ViewAllRouteMenu()
        {
            throw new System.NotImplementedException();
        }

        public void VieweAllUserMenu()
        {
            Console.WriteLine();
            Console.WriteLine("View All User");
            var users = userManager.GetALLUser();
            Console.WriteLine("Id\t FirstName\t LastName\t Email");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}\t {user.FirstName}\t {user.LastName}\t {user.Email}");
            }
        }
    }
}