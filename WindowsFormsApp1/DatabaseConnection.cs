using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DatabaseConnection
    {
        private string connectionString = "Data Source=DESKTOP-OHNECE1;Initial Catalog=Milkproduct_mng;Integrated Security=True;";
        public SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
            return connection;
        }
    }
}
