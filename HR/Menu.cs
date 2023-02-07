using System;


namespace HR
{
    public class Menu
    {
        public static bool RunAgain { get; set; } =true;
        Methods Methods= new Methods();
        
        public void WriteMenu()
        {
            Program.DepartmentList.Clear();
            Methods.Departaments();
            Console.WriteLine("");
            Console.WriteLine("***********************************");
            Console.WriteLine("");
            Console.WriteLine("Choose from this methods");
            Console.WriteLine("");
            Console.WriteLine("1 => Add to program");
            Console.WriteLine("2 => Add all employees from program to file");
            Console.WriteLine("3 => Remove from program");
            Console.WriteLine("4 => Remove from file");
            Console.WriteLine("5 => Show all employees from program");
            Console.WriteLine("6 => Show all employees from file");
            Console.WriteLine("7 => Remove all from program");
            Console.WriteLine("8 => Remove all from file");
            Console.WriteLine("9 => Remove all");
            Console.WriteLine("* => Show employee by department ID");
            Console.WriteLine("# => Find employe by ID");
            Console.WriteLine("0 => Out");
            Console.WriteLine("");
            Console.Write("Your method is =>   ");
        }
        public void Choice()
        {
            Console.WriteLine("Welcome to Hrach's first program");
            while (RunAgain)
            {
                WriteMenu();
                string Method = Console.ReadLine();
                Console.WriteLine("");
                switch (Method)
                {
                    case "1":
                        Methods.AddObjToList();
                        break;
                    case "2":
                        Methods.AddAllEployesFromProgramToFile();
                        break;
                    case "3":
                        Methods.RemoveFromProgramByID();
                        break;
                    case "4":
                        Methods.RemoveFromFileByID();
                        break;
                    case "5":
                        Methods.ShowAllEmployesFromProgram();
                        break;
                    case "6":
                        Methods.ShowAllEmployesFromFile();
                        break;
                    case "7":
                        Methods.RemoveAllFromProgram();
                        break;
                    case "8":
                        Methods.RemoveAllFromFile();
                        break;
                    case "9":
                        Methods.RemoveAll();
                        break;
                    case "0":
                        RunAgain = !RunAgain;
                        break;
                    case "*":
                        Methods.ShowEmployeeByDepID();
                        break;
                    case "#":
                        Methods.FindByIDInAll();
                        break;
                    default:
                        Console.WriteLine("***There is no such method. Select again***");
                        break;
                }

            }
        }

    }
    public enum MenuRow
    {
        Out,
        Add,
        AddToFile,
        ReoveProgram,
        RemoveFromFile,
        ShowAllProgram,
        ShowAllFile,
        RemoveAllProgram,
        RemoveAllFile,
        RemoveAll,
        Find,
        ShowEmployeeByDepID
    }

}
