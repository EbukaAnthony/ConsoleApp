using System;
using System.Collections.Generic;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Interfaces
{
    public interface IRouteManager
    {
       public Route CreateRoute(string name, string takeOffPoint, string destination, DateTime takeOffTime, DateTime landingTime, decimal price, int capacity);
       public Route GetRoute(int id);
       public Route GetRoute(string name);
       public List<Route> GetAllRoute();
       public Route UpdateRoute(string name, string takeOffPoint, string destination, DateTime takeOffTime, DateTime landingTime, decimal price, int capacity);
       public bool DeleteRoute(int id);
       public string RouteToOption();
       public List<Route> GetRouteByDeleteStatatu(bool isDeleted);
    }
}