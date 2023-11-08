using SelectConFiltros.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectConFiltros.DAL
{
    internal class EmployeeDAL
    {
        ConexionBD conexion = new ConexionBD();
        public List<Employee> SelectEmployee()
        {
            List<Employee> employeeList = new List<Employee>();
            conexion.AbrirConexion();
            string query = "SELECT * FROM employees";
            SqlCommand command = new SqlCommand(query, conexion.Connection) ;

            SqlDataReader reader = command.ExecuteReader();
            //lectura de la base de datos y creación de la lista con los empleados
            while (reader.Read())
            {
                int id = (int)reader["employee_id"];
                string lastName = (string)reader["last_name"];
                string email = (string)reader["email"];
                DateTime hireDate = (DateTime)reader["hire_date"];
                int jobId = (int)reader["job_id"];
                decimal salary = (decimal)reader["salary"];
                string firstName;
                if (reader["first_name"] == DBNull.Value)
                    firstName = null;
                else
                    firstName = (string)reader["first_name"];

                string phone;
                if (reader["phone_number"] == DBNull.Value)
                    phone = null; 
                else
                    phone = (string)reader["phone_number"];

                int? managerId;
                if (reader["manager_id"] == DBNull.Value)
                    managerId = null;
                else
                    managerId = (int)reader["manager_id"];

                int? departmentId;
                if (reader["department_id"] == DBNull.Value)
                    departmentId = null;
                else
                    departmentId = (int)reader["department_id"];

                Employee employee = new Employee(id, firstName, lastName, email, phone, hireDate, jobId, salary, managerId, departmentId);

                employeeList.Add(employee);
            }
            conexion.CerrarConexion();
            return employeeList;
        }
        public List<Employee> SelectEmployeeFiltros(string filtroNombre, int filtroSalario, string filtroCiudad)
        {
            List<Employee> employeeList = new List<Employee>();
            conexion.AbrirConexion();
            //query con la conexión de datos y todos los filtros aplicados
            string query;
            if (filtroCiudad != string.Empty)
            {
                query = $@"SELECT * FROM employees e 
                INNER JOIN departments d ON d.department_id = e.department_id 
                INNER JOIN locations l ON d.location_id = l.location_id 
                WHERE first_name LIKE '{filtroNombre}%' 
                AND salary >= {filtroSalario} 
                AND city = '{filtroCiudad}'";
            }
            else
            {
                query = $@"SELECT * FROM employees e 
                INNER JOIN departments d ON d.department_id = e.department_id 
                INNER JOIN locations l ON d.location_id = l.location_id 
                WHERE first_name LIKE '{filtroNombre}%' 
                AND salary >= {filtroSalario}";
            }

            SqlCommand command = new SqlCommand(query, conexion.Connection);
            
            SqlDataReader reader = command.ExecuteReader();
            //lectura de la base de datos y creación de la lista con los empleados
            while (reader.Read())
            {
                int id = (int)reader["employee_id"];
                string lastName = (string)reader["last_name"];
                string email = (string)reader["email"];
                DateTime hireDate = (DateTime)reader["hire_date"];
                int jobId = (int)reader["job_id"];
                decimal salary = (decimal)reader["salary"];
                string firstName;
                if (reader["first_name"] == DBNull.Value)
                    firstName = null;
                else
                    firstName = (string)reader["first_name"];

                string phone;
                if (reader["phone_number"] == DBNull.Value)
                    phone = null;
                else
                    phone = (string)reader["phone_number"];

                int? managerId;
                if (reader["manager_id"] == DBNull.Value)
                    managerId = null;
                else
                    managerId = (int)reader["manager_id"];

                int? departmentId;
                if (reader["department_id"] == DBNull.Value)
                    departmentId = null;
                else
                    departmentId = (int)reader["department_id"];

                Employee employee = new Employee(id, firstName, lastName, email, phone, hireDate, jobId, salary, managerId, departmentId);

                employeeList.Add(employee);
            }
            conexion.CerrarConexion();
            return employeeList;
        }

    }
}
