using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using DAL;


namespace Bussiness
{
    public class MenuBussiness
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        MenuDAL MenuDAL = new MenuDAL();

        public List<Menu> GetMenus()
        {
            return MenuDAL.GetMenus(connectionString);
        }

        public void CrearMenu(Menu Menu)
        {
            MenuDAL.CrearMenu(connectionString, Menu);
        }

        public Menu GetMenuData(int MenuId)
        {
            return MenuDAL.GetMenuData(connectionString, MenuId); 
        }
        public Menu GetMenuDataTipo(string menuTipo)
        {
            return MenuDAL.GetMenuDataTipo(connectionString, menuTipo); 
        }
        public void EditarMenu(Menu Menu)
        {
            MenuDAL.EditarMenu(connectionString, Menu);
        }
        public void EliminarMenu(int MenuId)
        {
            MenuDAL.EliminarMenu(connectionString, MenuId);
        }
        public List<Menu> FiltrarMenu( string nombreMenu, string tipo)
        {
            return MenuDAL.FiltrarMenu(connectionString, nombreMenu, tipo);
        }
    }
}
