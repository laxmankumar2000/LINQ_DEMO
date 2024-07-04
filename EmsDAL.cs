using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS1.DAL
{
    public class EmsDAL
    {
        static List<Employees> empList = new List<Employees>
        {
            new Employees
            {
                Id = 1,
                Name = "Laxman",
                Email = "abc@gmail.com",
                DateOfBirth = new DateOnly(2000,2,3),
                DepartmentId = 1
            },

            new Employees
            {
                Id = 2,
                Name = "lax",
                Email = "lax@gmail.com",
                DateOfBirth = new DateOnly(2000,3,4),
                DepartmentId = 2
            },

            new Employees
            {
                Id = 3,
                Name = "love",
                Email = "love@gmail.com",
                DateOfBirth = new DateOnly(2000,5,6),
                DepartmentId = 3
            },

            new Employees
            {
                Id = 4,
                Name = "lew",
                Email = "lew@gmail.com",
                DateOfBirth = new DateOnly(2000,7,8),
                DepartmentId = 4
            }

        };

        static List<Department> deptList = new List<Department>
        {
            new Department{ Id =1,Name = "Hr"},

            new Department{ Id = 2, Name = "IT"}

        };


        //Get the employees details -- For access to List of employee
        public static List<Employees> GetEmployees()
        {
            return empList;

        }

        // if the id is present in list then return employee, if not return null;
        public static Employees GetEmployee(int id)
        {
            //1
            return empList.FirstOrDefault(e => e.Id == id);

            //2
            /*
            return (from e in empList
                    where e.Id == id
                    select e).FirstOrDefault();

            //3
            return empList.Find(e => e.Id == id);
            */
        }


        //return true and false to Update employee 
        public static bool UpdateEmployee(Employees emp)
        {
            Employees existingEmployee = GetEmployee(emp.Id);
            existingEmployee = emp;
            return true;
        }

        //Varification in to Adding Employee
        public static bool AddEmployee(Employees emp)
        {
            var query = from e in empList
                        where e.Id == emp.Id && e.DateOfBirth == emp.DateOfBirth
                        select e;

            if (query.Any()) {
                return true;
            }
            else
            {
               
              int mexId =  empList.Max(emp => emp.Id) +1;
                emp.Id = mexId;
                empList.Add(emp);
                return false;
            }

        }






        //Return Department details into MAin id to access
        public static List<Department> GetDepartment()
        {
            return deptList;
        }

        
    }
}
