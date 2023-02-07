using System;
namespace HR
{

    public class Employee
    {
        public int EmployeID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int DepartmentID { get; }
       
        public Employee(int EmployeID, string FirstName, string LastName, int DepartmentID)
        {
            this.EmployeID = EmployeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DepartmentID = DepartmentID;
        }
        
    }
}
