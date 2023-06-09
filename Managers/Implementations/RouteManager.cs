using System;
using System.Collections.Generic;
using TrainStationManagementApp.Managers.Interfaces;
using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Managers.Implementations
{
    public class RouteManager : IRouteManager
    {
        public static List<Route> routeDatabase = new List<Route>()
        {
            new Route(1, "AbeokutaToLagos", "Obantoko", "Lagos", DateTime.Parse("3/21/2023 6:00:00"), DateTime.Parse("3/21/2023 7:00:00"), 5000, 25, 25, DateTime.Now, DateTime.Now, false),
            new Route(2, "LagosToIbadan", "Lagos", "Ibadan", DateTime.Now, DateTime.Now, 5000, 25, 25, DateTime.Now, DateTime.Now, false)
        };
        public Route CreateRoute(string name, string takeOffPoint, string destination, DateTime takeOffTime, DateTime landingTime, decimal price, int capacity)
        {
            var route = TryGet(name);
            if (route == null)
            {
                int id = routeDatabase.Count + 1;
                var newRoute = new Route(id, name, takeOffPoint, destination, takeOffTime, landingTime, price, capacity, capacity, DateTime.Now, DateTime.Now, false);
                routeDatabase.Add(newRoute);
                return newRoute;
            }
           return null;
        }

        public bool DeleteRoute(int id)
        {
           var route = TryGet(id);
           if (route == null)
           {
              return false;
           } 
           route.IsDeleted = true;
           return true;
        }

        public List<Route> GetAllRoute()
        {
            return routeDatabase;
        }

        public Route GetRoute(int id)
        {
            foreach (var route in routeDatabase)
            {
                if (route.Id == id && route.IsDeleted == false)
                {
                    return route;
                }
            }
            return null;
        }

        public Route GetRoute(string name)
        {
            foreach (var route in routeDatabase)
            {
                if (route.Name == name && route.IsDeleted == false)
                {
                    return route;
                }
            }
            return null;
        }

        public Route UpdateRoute(string name, string takeOffPoint, string destination, DateTime takeOffTime, DateTime landingTime, decimal price, int capacity)
        {
            var routeExist = TryGet(name);
            if (routeExist == null)
            {
                return null;
            }
           routeExist.Name = name;
           routeExist.TakeOffPoint = takeOffPoint;
           routeExist.Destination = destination;
           routeExist.TakeOffTime = takeOffTime;
           routeExist.LandingTime = landingTime;
           routeExist.Price = price;
           routeExist.Capacity = capacity; 
           routeExist.AvailableSpace = capacity; 
           return routeExist;
        }


       
        private Route TryGet(int id)
        {
            foreach (var route in routeDatabase)
            {
                if (route.Id == id && route.IsDeleted == false)
                {
                   return route; 
                }
            }
            return null;
        }
        private Route TryGet(string name)
        {
            foreach (var route in routeDatabase)
            {
                if (route.Name == name && route.IsDeleted == false)
                {
                   return route; 
                }
            }
            return null;
        }

    
        public string RouteToOption()
        {
            var routes = GetRouteByDeleteStatatu(false);
            string text = "";

            if (routes.Count > 0)
            {
                // foreach (var route in routes)
                // {
                //     text +=$"Enter {route.Id} for {route.Name}, ";
                // }

                for (int i = 0; i < routes.Count; i++)
                {
                    if (i == routes.Count - 1)
                    {
                        text +=$"Enter {routes[i].Id} for {routes[i].Name}";
                    }
                    else
                    {
                        text +=$"Enter {routes[i].Id} for {routes[i].Name}, ";
                    }
                }
                return text;
            }
            else
            {
                return "Route not found";
            }
        }


        


        public List<Route> GetRouteByDeleteStatatu(bool isDeleted)
        {
            var routes = GetAllRoute();
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