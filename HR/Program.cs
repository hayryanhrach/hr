using System;
using System.Collections.Generic;

namespace HR
{
    public static class Program
    {

        public static List<Employee> Employeelist = new List<Employee>();
        public static List<Department> DepartmentList = new List<Department>();
        
        public delegate void MyDelegate();

        public static void Main()
        {
            Menu menu = new Menu();
            menu.Choice();
        }


    }
}
