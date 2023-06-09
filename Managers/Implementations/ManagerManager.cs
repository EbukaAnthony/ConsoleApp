using System;
using System.Collections.Generic;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Implementations
{
    public class ManagerManager : IManagerManager
    {
        public static List<Manager> managerDatabase = new List<Manager>()
        {
            new Manager(1, 2, "STF/00001",  false, DateTime.Now, DateTime.Now)
        };
        public Manager CreateManager(int userId)
        {
            var manager = TryGet(userId);
            if (manager == null)
            {
                var id = managerDatabase.Count + 1;
                string staffNumber = GenerateStaffNumber();
                var newManager = new Manager(id, userId, staffNumber, false, DateTime.Now, DateTime.Now);
                managerDatabase.Add(newManager);
                return newManager;
            }
            return null;
        }
       

        public bool DeleteManager(int id)
        {
            var manager = TryGet(id);
            if (manager == null)
            {
                return false;
            }
            manager.IsDeleted = true;
            return true;
        }
        

        public List<Manager> GetAllManager()
        {
            return managerDatabase;
        }

        public Manager GetManager(int id)
        {
           return TryGet(id);
        }

        public Manager GetManager(string staffNumber)
        {
            foreach (var manager in managerDatabase)
            {
                if (manager.StaffNumber == staffNumber && manager.IsDeleted == false)
                {
                    return manager;
                }
            }
            return null;
        }
        private string GenerateStaffNumber()
        {
           return $"STF/000{managerDatabase.Count + 1}";
        }

        private Manager TryGet(int id)
        {
            foreach (var manager in managerDatabase)
            {
                if (manager.Id == id && manager.IsDeleted == false)
                {
                    return manager;
                }
            }
            return null;
        }
    }
}