using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    internal class PageData
    {
        static public double quantityRowsSelected { get; set; }

       static public double quantity;

        static public int SetPageQuantityUsers()
        {
            quantity = User.CountQuantityUsers();
            return CalculateNumberOfPage();
        }  
        
        
        static public int SetPageQuantityServices(int userId = 0)
        {
            quantity = PaefiService.CountQuantityServices(userId);
            return CalculateNumberOfPage();
        } 
        
        static public int SetPageQuantityUsersByName(string name)
        {
            quantity = User.CountQuantityUsersByName(name);
            return CalculateNumberOfPage();
        } 
        
        //static public int SetPageQuantityServices(int personId)
        //{
        //    quantity = Service.CountQuantityServices(personId);
        //    return CalculacalculateNumberOfPage();
        //}
        
        static private int CalculateNumberOfPage()
        {
            double result = quantity / quantityRowsSelected;
            return (int)Math.Ceiling(result);
        }
    }
}
