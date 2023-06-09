using System.Collections.Generic;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Interfaces
{
    public interface IManagerManager
    {
       public Manager CreateManager(int userId);
       public Manager GetManager(int id);
       public Manager GetManager(string staffNumber);
       public List<Manager> GetAllManager();
       public bool DeleteManager(int id);
       

    }
}