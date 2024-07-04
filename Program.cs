
using EMS1.DAL;
using System.Text.RegularExpressions;

namespace EMS.PL
{
    public  class Program
    {
        static void Main(string[] args)
        {
            int chocie = 0;

            while(true)
            {
                Console.WriteLine(" 1. List Employee \n 2. Add Employee \n 3. Update employee \n 4. Delete Employee \n 5. List Department \n" +
                    " 6. Add Department\n 7. Update Department \n 8. Delete Department \n 9. Exit " );

                Console.WriteLine("Enter the choice");
                string input = Console.ReadLine();
                if ((int.TryParse(input, out int choice)))
                {
                    switch(choice)
                    {
                        case 1:
                            ListEmployee();
                            break;
                        case 2:
                            AddEmployee();
                            break;
                        case 3:
                            UpdateEmployee();
                            break;
                        case 5:
                            hiiLove();
                            break;
                    }

                }
                else
                    Console.WriteLine("after loop");
            }
            

           
        }

        //1. List of the Employee
        static void ListEmployee()
        {

            foreach (Employees item in EmsDAL.GetEmployees())
            {
                //Console.WriteLine(item.Id + item.Name);
                Console.WriteLine(item.ToString());
            }
        }

        // 2. Add employees into List

        private static void AddEmployee()
        {
            Employees emp = new Employees();
            EmployeeDeatils(emp,OperationType.Add);

        }

        //Method to  employees Details  add and update 
        private static void EmployeeDeatils(Employees emp, OperationType opType)
        {
            Console.WriteLine("Enter the name of the Employee");
            string name = Console.ReadLine();
            if (!(String.IsNullOrEmpty(name)))
            {
                Console.WriteLine("Enter the email");
                string email = Console.ReadLine();
                if (IsEmailValid(email))
                {
                    Console.WriteLine("Enter the DOB ");
                    if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dob))
                    {

                        emp.Name = name;
                        emp.Email = email;
                        emp.DateOfBirth = dob;

                        ListDepartments();

                        Console.WriteLine("Enter the department ID");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int deptId))
                        {
                            emp.DepartmentId = deptId;

                            if(opType == OperationType.Add)
                            {
                                if ((EmsDAL.AddEmployee(emp)))
                                   // Console.WriteLine("Employee is allready present");
                                Console.WriteLine("Employee  Added successfully present");
                                else
                                {
                                    //Console.WriteLine("Emolyee added");
                                    Console.WriteLine("Emolyee Unsuccessfully");
                                }
                            }
                            else
                            {
                                if ((EmsDAL.UpdateEmployee(emp)))
                                    Console.WriteLine("update successfullly");
                                else
                                {
                                    Console.WriteLine("updated unsuccessfully");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid Department Id");
                        }
                                            
                    }
                    else
                    {
                        Console.WriteLine("Invalid DOB");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Email");
                }
                emp.Name = name;
            }
            else
                Console.WriteLine("Name is invalid");
        }

        // 3. update the Employee data
        private static void UpdateEmployee()
        {
            Console.WriteLine("Enter the Id that u want to Update");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int deptId))
            {
                Employees emp = EmsDAL.GetEmployee(deptId);
                if (emp == null)
                {
                    Console.WriteLine("Invalid Department id ");
                }
                else
                {
                    EmployeeDeatils(emp, OperationType.Update);

                }
            }
        }


        // 5  List of the department
        private static void ListDepartments()
        {
            foreach (Department item in EmsDAL.GetDepartment())
            {
                Console.WriteLine(item.ToString());
            }
        }


        // Is valid email id or not
        private static bool IsEmailValid(string email)
        {
            string pattern = @"[a-z]*[A-Z]*[0-9]*\@[gmail.com]";
            Regex rx = new Regex(pattern);

            if (rx.IsMatch(email))
            {
                return true;
            }
            else
                return false;
        
        }
    }
}

/*
 * I/0
 * validation -- input all the alid or not
 * varification -- check we can duplicate value or not   IN BL.
 * process
 * o/p

*/
