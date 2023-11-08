using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectConFiltros
{
    internal class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private DateTime hireDate;
        private int jobId;
        private decimal? salary;
        private int? managerId;
        private int? departmentId;

        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public DateTime HireDate { get { return hireDate; } set { hireDate = value; } }
        public int JobId { get { return jobId; } set { jobId = value; } }
        public decimal? Salary { get { return salary; } set { salary = value; } }
        public int? ManagerId { get { return managerId; } set { managerId = value; } }
        public int? DepartmentId { get { return departmentId; } set { departmentId = value; } }

        public Employee() { }

        public Employee(int id, string firstName, string lastName, string email, string phone, DateTime hireDate, 
                        int jobId, decimal salary, int? managerId, int? departmentId)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.hireDate = hireDate;
            this.jobId = jobId;
            this.salary = salary;
            this.managerId = managerId;
            this.departmentId = departmentId;         
        }
        public override string ToString()
        {
            return $"{Id}. " +
                   $"{FirstName} " +
                   $"{LastName}. " +
                   $"{Email}" +
                   $"Salario: {Salary}";
        }
    }
}
