using System;


namespace HR
{
    public   class Department
    {
        public  int DepartamentID { get; set; }
        public string Name { get; set; }

        public Department(int DID, string N)
        {
            DepartamentID= DID;
            Name= N; 
        }
    }
}
