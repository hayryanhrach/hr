using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace HR
{
    public class Methods
    {
        public StreamWriter streamwriter;
        public StreamReader streamreader;
        StreamWriter WriterInFileContainsFilePath;
        StreamWriter WriterInFileContainsFilePath1;
        StreamReader ReaderFromFileContainsFilePath;
        int QuestionPath = 0;
        public string ReturnFilePath()
        {
            WriterInFileContainsFilePath = new StreamWriter("FilePath.txt", true);
            WriterInFileContainsFilePath.Close();
            ReaderFromFileContainsFilePath = new StreamReader("FilePath.txt");
            string FilePath = null;
            FilePath = ReaderFromFileContainsFilePath.ReadToEnd();
            FilePath = FilePath.Replace('"', ' ');
            FilePath = FilePath.Trim();
            ReaderFromFileContainsFilePath.Close();


            if (FilePath != "")
            {
                QuestionPath++;
                if (QuestionPath == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"Your file path is  {FilePath}");
                    Console.WriteLine();
                    Console.WriteLine(" Change your path ? ");
                    Console.WriteLine();
                    Console.Write("1 - Yes       2 - No(Continue)     0 - Cancel");
                    Console.WriteLine();
                    Console.WriteLine();
                    int Answer = Convert.ToInt32(Console.ReadLine());
                    bool IsPathChange = false;
                    do
                    {
                        IsPathChange = false;
                        if (Answer == 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Please write new path ");
                            Console.WriteLine();
                            FilePath = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine($" Your new path is  {FilePath}");
                            Console.WriteLine();
                            StreamWriter writerinfilecontainsfilepath = new StreamWriter("FilePath.txt", false);
                            writerinfilecontainsfilepath.Write(FilePath);
                            writerinfilecontainsfilepath.Flush();
                            writerinfilecontainsfilepath.Close();
                        }
                        else if (Answer == 2)
                        {
                            IsPathChange = false;
                        }
                        else
                        {
                            Console.WriteLine("Have not like Method.Please Write new");
                            IsPathChange = true;
                        }
                    } while (IsPathChange);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You have not file path, Please Write");
                Console.WriteLine();
                
                FilePath = Console.ReadLine();
                FilePath = FilePath.Replace('"', ' ');
                FilePath = FilePath.Trim();
                Console.WriteLine();
                Console.WriteLine($"Your file path is =>  {FilePath}");
                Console.WriteLine();
                WriterInFileContainsFilePath1 = new StreamWriter("FilePath.txt", false);
                WriterInFileContainsFilePath1.Write(FilePath);
                WriterInFileContainsFilePath1.Flush();
                WriterInFileContainsFilePath1.Close();
            }
            return FilePath;
        }
        public int IsIDNumber()
        {
            bool IsNumber = false;
            int ID = 0;
            do
            {
                IsNumber = false;
                try
                {
                    ID = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    IsNumber = !IsNumber;
                    Console.WriteLine(" Please write only number ");
                }

            } while (IsNumber);
            return ID;
        }
        public Employee CreateEmployeeObj()
        {
            bool IsRepeat = false;
            bool HaveLikeThisCopmany = false;
            int EmployeeID = 0;
            string EmployeeFirstName;
            string EmployeeLastName;
            int DepatmentID = 0;
            Employee EmployeObj;
            do
            {
                int ID = 0;
                IsRepeat = false;
                Console.Write("Enter the employee ID   ");
                ID = IsIDNumber();
                for (int i = 0; i < Program.Employeelist.Count; i++)
                {
                    if (ID == Program.Employeelist[i].EmployeID)
                    {
                        IsRepeat = true;
                        Console.WriteLine("Error.EmployeeID already exists. Write a new one");
                    }
                }

                List<Employee> FileEmplLi = ReadFromFileAddObjToList();
                for (int o = 0; o < FileEmplLi.Count; o++)
                {
                    if (ID == FileEmplLi[o].EmployeID)
                    {
                        IsRepeat = true;
                        Console.WriteLine("Error.EmployeeID already exists. Write a new one");
                    }
                }
                if (IsRepeat == false)
                {
                    EmployeeID = ID;
                }
            }
            while (IsRepeat);
            Console.Write("Enter the employee FirstName   "); EmployeeFirstName = Console.ReadLine();
            Console.Write("Enter the employee LastName   "); EmployeeLastName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("All departments. Please choose ID of department for Employee");
            Console.WriteLine();
            for (int o = 0; o < Program.DepartmentList.Count; o++)
            {
                Console.WriteLine($"DepartamentID = {Program.DepartmentList[o].DepartamentID}   Name = {Program.DepartmentList[o].Name} ");
            }
            Console.WriteLine();
            int DepID = 0;
            do
            {
                Console.Write("Enter the depatment ID   ");
                DepID = IsIDNumber();

                HaveLikeThisCopmany = false;
                for (int m = 0; m < Program.DepartmentList.Count; m++)
                {
                    if (DepID != Program.DepartmentList[m].DepartamentID)
                    {
                        HaveLikeThisCopmany = !HaveLikeThisCopmany;
                    }
                }
                if (HaveLikeThisCopmany == false)
                {
                    DepatmentID = DepID;
                }
                else
                {
                    Console.WriteLine("Error.Company have not like department");
                    Console.WriteLine();
                }
            } while (HaveLikeThisCopmany);


            return EmployeObj = new Employee(EmployeeID, EmployeeFirstName, EmployeeLastName, DepatmentID);

        }
        public void AddObjToList()
        {
            Program.Employeelist.Add(CreateEmployeeObj());
            Menu.RunAgain = true;
        }//1
        public string FormatToFile()
        {
            string RowEmployeeObjecToAddFile = "";
            string AllEmployeObjectToAddFile = "";
            foreach (var item in Program.Employeelist)
            {
                RowEmployeeObjecToAddFile = $"{item.EmployeID}," + $"{item.FirstName}," + $"{item.LastName}," + $"{item.DepartmentID}" + ",  #" + "\n";
                AllEmployeObjectToAddFile += RowEmployeeObjecToAddFile;
            }
            return AllEmployeObjectToAddFile;
        }
        public void AddAllEployesFromProgramToFile()//2
        {
            streamwriter = new StreamWriter(ReturnFilePath(), true);
            if (FormatToFile() != "")
            {
                streamwriter.WriteLine(FormatToFile());
                streamwriter.Flush();
                streamwriter.Close();
                Program.Employeelist.Clear();
            }
            else
            {
                Console.WriteLine("Have not employee in program ");
                streamwriter.Flush();
                streamwriter.Close();
            }

            Menu.RunAgain = true;
        }
        public Employee FindInProgramByID()
        {
            Employee SearchObject = null;
            Console.Write("Enter the EmployeeID   ");
            int ID = IsIDNumber();
            for (int i = 0; i < Program.Employeelist.Count; i++)
            {
                if (Program.Employeelist[i].EmployeID == ID)
                {
                    SearchObject = Program.Employeelist[i];
                    return SearchObject;
                }
            }
            return SearchObject;
        }
        public void RemoveFromProgramByID()//3
        {

            Program.Employeelist.Remove(FindInProgramByID());
            Menu.RunAgain = true;
        }
        public List<Employee> ReadFromFileAddObjToList()
        {
            List<Employee> EmployeeListFromFile = new List<Employee>();
            string FilePath1 = ReturnFilePath();
            FilePath1 = FilePath1.Replace('"', ' ');
            FilePath1 = FilePath1.Trim();
            try
            {
                streamwriter = new StreamWriter(FilePath1, true);
                streamwriter.Close();
            }
            catch 
            {
                Console.WriteLine("File path is empty ");
                Console.WriteLine();
                Program.Main();
            }

            streamwriter.Close();
            streamreader = new StreamReader(FilePath1);
            string[] SplitRow = streamreader.ReadToEnd().Split("#");
            streamreader.Close();
            for (int i = 0; i < SplitRow.Length - 1; i++)

            {
                string[] SplitElement = SplitRow[i].Split(",");
                Employee FileEployeeObjects = new Employee(Convert.ToInt32(SplitElement[0]), SplitElement[1], SplitElement[2], Convert.ToInt32(SplitElement[3]));
                EmployeeListFromFile.Add(FileEployeeObjects);
            }
            return EmployeeListFromFile;
        }
        public Employee FindInFileByID()
        {
            int ID = 0;
            Console.WriteLine();
            Console.Write("Enter the EmployeeID   ");
            ID = IsIDNumber();
            List<Employee> FileEmployeelList = ReadFromFileAddObjToList();
            Employee SearchObject = null;
            for (int i = 0; i < Program.Employeelist.Count; i++)
            {
                if (FileEmployeelList[i].EmployeID == ID)
                {
                    SearchObject = Program.Employeelist[i];
                    return SearchObject;
                }
            }
            return SearchObject;
        }
        public void RemoveFromFileByID()//4
        {
            List<Employee> FinalEmployeesFile = ReadFromFileAddObjToList();
            Employee SearchEmployee = FindInFileByID();
            FinalEmployeesFile.Remove(SearchEmployee);
            streamwriter = new StreamWriter(ReturnFilePath(), false);
            foreach (var item in FinalEmployeesFile)
            {
                streamwriter.WriteLine($"{item.EmployeID}," + $"{item.FirstName}," + $"{item.LastName}," + $"{item.DepartmentID}" + ",  #" + "\n");
            }
            Menu.RunAgain = true;
        }
        public void ShowAllEmployesFromProgram()//5
        {
            for (int i = 0; i < Program.Employeelist.Count; i++)
            {
                Console.Write($"EmployeeID = {Program.Employeelist[i].EmployeID.ToString()}   ");
                Console.Write($"FirstName = {Program.Employeelist[i].FirstName}   ");
                Console.Write($"LastName = {Program.Employeelist[i].LastName}   ");
                Console.Write($"DepartmentID = {Program.Employeelist[i].DepartmentID.ToString()}   ");
                Console.WriteLine();
            }
            Menu.RunAgain = true;
        }
        public void ShowAllEmployesFromFile()//6
        {
            List<Employee> AllEmpoyeeFromProgram = ReadFromFileAddObjToList();
            foreach (var item in AllEmpoyeeFromProgram)
            {
                Console.Write($"EmployeeID = {item.EmployeID.ToString()}   ");
                Console.Write($"FirstName = {item.FirstName}   ");
                Console.Write($"LastName = {item.LastName}   ");
                Console.Write($"DepartmentID = {item.DepartmentID.ToString()}   ");
                Console.WriteLine();
            }
            Menu.RunAgain = true;
        }
        public void RemoveAllFromProgram()//7
        {
            Program.Employeelist.Clear();
            Menu.RunAgain = true;
        }
        public void RemoveAllFromFile()//8
        {
            streamwriter = new StreamWriter(ReturnFilePath(), false);
            streamwriter.Close();
            Menu.RunAgain = true;
        }
        public void RemoveAll()//9
        {
            Program.MyDelegate del1 = new Program.MyDelegate(RemoveAllFromProgram);
            del1 += RemoveAllFromFile;
            del1();
            Menu.RunAgain = true;
        }
        public void FindByIDInAll()//#
        {
            Console.Write("Enter the EmployeeID   ");
            int ID = IsIDNumber();
            for (int i = 0; i < Program.Employeelist.Count; i++)
            {
                if (Program.Employeelist[i].EmployeID == ID)
                {
                    Console.Write($"EmployeeID = {Program.Employeelist[i].EmployeID.ToString()}   ");
                    Console.Write($"FirstName = {Program.Employeelist[i].FirstName}   ");
                    Console.Write($"LastName = {Program.Employeelist[i].LastName}   ");
                    Console.Write($"DepartmentID = {Program.Employeelist[i].DepartmentID.ToString()}   ");
                    Console.WriteLine();
                }
            }

            List<Employee> FileEmployeelList = ReadFromFileAddObjToList();
            for (int i = 0; i < FileEmployeelList.Count; i++)
            {
                if (FileEmployeelList[i].EmployeID == ID)
                {
                    Console.Write($"EmployeeID = {FileEmployeelList[i].EmployeID.ToString()}   ");
                    Console.Write($"FirstName = {FileEmployeelList[i].FirstName}   ");
                    Console.Write($"LastName = {FileEmployeelList[i].LastName}   ");
                    Console.Write($"DepartmentID = {FileEmployeelList[i].DepartmentID.ToString()}   ");
                    Console.WriteLine();
                }
            }
        }
        public void ShowEmployeeByDepID()//*
        {
            bool IsFind = true;
            Console.WriteLine("All Depatments");
            Console.WriteLine();
            for (int o = 0; o < Program.DepartmentList.Count; o++)
            {
                Console.WriteLine($"DepartmentID = {Program.DepartmentList[o].DepartamentID}   Name = {Program.DepartmentList[o].Name} ");
            }
            Console.WriteLine();
            Console.Write("Enter the DepatmentID   " + "\n");
            Console.WriteLine();
            int ID = IsIDNumber();

            List<Employee> EmplLIst = ReadFromFileAddObjToList();
            do
            {
                for (int i = 0; i < Program.Employeelist.Count; i++)
                {
                    if (Program.Employeelist[i].DepartmentID == ID)
                    {
                        Console.WriteLine();
                        Console.Write($"EmployeeID = {Program.Employeelist[i].EmployeID.ToString()}   ");
                        Console.Write($"FirstName = {Program.Employeelist[i].FirstName}   ");
                        Console.Write($"LastName = {Program.Employeelist[i].LastName}   ");
                        Console.Write($"DepartmentID = {Program.Employeelist[i].DepartmentID.ToString()}   ");
                        Console.WriteLine();
                        IsFind = false;
                    }
                }
                for (int h = 0; h < EmplLIst.Count; h++)
                {
                    if (EmplLIst[h].DepartmentID == ID)
                    {
                        Console.WriteLine();
                        Console.Write($"EmployeeID = {EmplLIst[h].EmployeID.ToString()}   ");
                        Console.Write($"FirstName = {EmplLIst[h].FirstName}   ");
                        Console.Write($"LastName = {EmplLIst[h].LastName}   ");
                        Console.Write($"DepartmentID = {EmplLIst[h].DepartmentID.ToString()}   ");
                        Console.WriteLine();
                        IsFind = false;
                    }

                }
            } while (IsFind);
        }
        public void Departaments()
        {
            Department acc = new Department(1, "Accountant");
            Program.DepartmentList.Add(acc);
            Department mark = new Department(2, "Marketing");
            Program.DepartmentList.Add(mark);
            Department sec = new Department(3, "Security");
            Program.DepartmentList.Add(sec);
        }

    }
}
