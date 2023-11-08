using SelectConFiltros.DAL;
using SelectConFiltros.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectConFiltros
{
    public partial class Form1 : Form
    {
        ConexionBD conexion = new ConexionBD();
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public int filtroSalario;

        public Form1()
        {
            InitializeComponent();
            MostrarLista(employeeDAL.SelectEmployee());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MostrarLista(employeeDAL.SelectEmployeeFiltros(textBox1.Text, filtroSalario, comboBox1.Text));
            textBox1.Clear();
            comboBox1.Text = string.Empty;
            textBox3.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool success = int.TryParse(textBox3.Text, out number);
            if (success)
                filtroSalario = number;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dTLocations.locations' Puede moverla o quitarla según sea necesario.
            this.locationsTableAdapter.Fill(this.dTLocations.locations);

        }
        private void MostrarLista(List<Employee> list)
        {
            listBox1.Items.Clear();
            try
            {
                conexion.AbrirConexion();
                foreach (Employee employee in list)
                {
                    listBox1.Items.Add(employee);
                }
                conexion.CerrarConexion();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
