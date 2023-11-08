using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectConFiltros.Modelos
{
    public class ConexionBD
    {
        static string ConnectionString = @"Data source = 79.143.90.12,54321;
                                        Initial Catalog = GermanEmployees;
                                        Persist Security Info = true;
                                        User Id = sa;
                                        Password = 123456789";

        private SqlConnection connection = new SqlConnection();
        public SqlConnection Connection { get { return connection; } set { connection = value; } }

        public void AbrirConexion()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }
        public void CerrarConexion()
        {
            connection.Close();
        }

    }
}
