using EmployeeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repo
{
    public interface IEmployeeDAL
    {
        bool AddEmployee(Employee objEmployee);
        bool EditEmployee(Employee objEmployee);
        bool DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
    }
}
