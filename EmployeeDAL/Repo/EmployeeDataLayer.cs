using EmployeeDAL.Models;
using EmployeeDAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using System.Data.SqlClient;

namespace EmployeeDAL
{
    public class EmployeeDataLayer : IEmployeeDAL
    {
        public bool AddEmployee(Employee objEmployee)
        {
            using (AngularCRUDEntities objEntity = new AngularCRUDEntities())
            {
                objEntity.Employees.Add(objEmployee);
                objEntity.Entry(objEmployee).State = EntityState.Added;
                objEntity.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int objEmployeeId)
        {
            using (AngularCRUDEntities objEntity = new AngularCRUDEntities())
            {
                Employee objEmployee = objEntity.Employees.Where(emp => emp.EmployeeID == objEmployeeId).SingleOrDefault();
                objEntity.Employees.Remove(objEmployee);
                objEntity.Entry(objEmployee).State = EntityState.Deleted;
                objEntity.SaveChanges();
                return true;
            }
        }

        public bool EditEmployee(Employee objEmployee)
        {
            using (AngularCRUDEntities objEntity = new AngularCRUDEntities())
            {
                Employee objOriginalEmployee = objEntity.Employees.Where(emp => emp.EmployeeID == objEmployee.EmployeeID).SingleOrDefault();
                objOriginalEmployee.FirstName = objEmployee.FirstName;
                objOriginalEmployee.LastName = objEmployee.LastName;
                objOriginalEmployee.EmpCode = objEmployee.EmpCode;
                objOriginalEmployee.Position = objEmployee.Position;
                objOriginalEmployee.Office = objEmployee.Office;
                objEntity.Entry(objEmployee).State = EntityState.Deleted;
                objEntity.Entry(objOriginalEmployee).State = EntityState.Modified;
                objEntity.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (AngularCRUDEntities objEntity = new AngularCRUDEntities())
            {
                var result = objEntity.Employees.ToList();
                return result;
            }
        }

        public Employee GetEmployee(int id)
        {
            Employee objEmployee;
            using (AngularCRUDEntities objEntity = new AngularCRUDEntities())
            {
                if (id <=0)
                {
                    throw new Exception("Id cannot be less than zero");
                }
                objEmployee = objEntity.Employees.Where(emp => emp.EmployeeID == id).FirstOrDefault();
                if (objEmployee == null)
                {
                    throw new TargetParameterCountException("Employee Does not Exist");
                }
            }
            return objEmployee;

        }
    }
}
