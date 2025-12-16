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

namespace WindowsFormsApp1
{
    public partial class TestConnection: Form
    {
        public TestConnection()
        {
            InitializeComponent();
        }

        private void TestConnection_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                DatabaseConnection dbConn = new DatabaseConnection();
                SqlConnection conn = dbConn.GetConnection();

                try
                {
                    conn.Open();
                    MessageBox.Show("✅ Database connection successful!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Connection failed: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
