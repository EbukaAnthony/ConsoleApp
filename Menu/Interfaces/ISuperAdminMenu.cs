namespace TrainStationManagementApp.Menu.Interfaces
{
    public interface ISuperAdminMenu
    {
        public void RealSuperAdminMenu(string email);
        public void CreateManagerMenu();
        public void CreateRouteMenu();
        public void VieweAllUserMenu();
        public void ViewAllRouteMenu();
        public void DeleteManagerMenu();
        public void UpdateManagerMenu();
    }
}