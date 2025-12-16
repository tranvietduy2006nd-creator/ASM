using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source=LAPTOP-MNJ9PDI7\SQLEXPRESS;Initial Catalog=ClothingFashioStore;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields (username, password, and role).", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT employees_name, position, authority_level FROM Employees " +
                                   "WHERE username = @username AND password = @password AND authority_level = @role";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@role", role);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string empName = reader["employees_name"].ToString();
                            string position = reader["position"].ToString();
                            string authority = reader["authority_level"].ToString();

                            MessageBox.Show($"Welcome, {empName}!\nRole: {authority}",
                                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect to the correct dashboard
                            switch (authority)
                            {
                                case "Admin":
                                    new AdminForm(empName, position).Show();
                                    break;
                                case "Sales":
                                    new SalesForm(empName, position).Show();
                                    break;
                                case "Warehouse":
                                    new WarehouseForm(empName, position).Show();
                                    break;
                                default:
                                    new UserForm(empName, position).Show();
                                    break;
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials or role.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
