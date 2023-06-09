using TrainStationManagementApp.Models;

namespace TrainStationManagementApp.Menu.Interfaces
{
    public interface ICustomerMenu
    {
        public void FundWalletMenu(string userEmail);
        void RealCustomerMenu(string userEmail);
        void CreateBookingMenu(string userEmail);
        void ViewBookingMenu(string userEmail);
        void ViewAllBookingMenu(string userEmail);
        public void ViewAllRouteMenu(string userEmail);
    }
}