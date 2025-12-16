using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class CustomerForm : Form
    {
        // THAY ĐỔI chuỗi kết nối của bạn tại đây
        string connectionString = @"Data Source=LAPTOP-MNJ9PDI7\SQLEXPRESS;Initial Catalog=ClothingFashioStore;Integrated Security=True";


        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        // 🔹 Load
        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // **SỬA LẠI CÂU SQL NÀY**
                string query = "SELECT customer_id, customer_name, phone, email, address FROM Customer";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // 🔹 Clear
        private void ClearFormFields()
        {
            txtCustomerId.Text = "";
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        // 🔹 Cell Click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // **SỬA LẠI CÁC TÊN CỘT/INDEX CHO KHỚP**
                txtCustomerId.Text = row.Cells["customer_id"].Value.ToString();
                txtFullName.Text = row.Cells["customer_name"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtAddress.Text = row.Cells["address"].Value.ToString();
            }
        }

        // 🔹 Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text != "")
            {
                MessageBox.Show("Please clear the form before adding.", "Warning");
                return;
            }
            if (txtFullName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill at least Full Name and Phone!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // **SỬA LẠI CÂU SQL VÀ TÊN CỘT**
                    string query = "INSERT INTO Customers (full_name, phone, email, address) VALUES(@fname, @phone, @email, @address)";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully!");
                    LoadCustomers();
                    ClearFormFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error");
            }
        }

        // 🔹 Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text == "")
            {
                MessageBox.Show("Please select a customer to edit.", "Warning");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // **SỬA LẠI CÂU SQL VÀ TÊN CỘT**
                    string query = @"UPDATE Customers 
                                   SET full_name=@fname, 
                                       phone=@phone, 
                                       email=@email, 
                                       address=@address 
                                   WHERE customer_id=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@id", txtCustomerId.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Customer updated successfully!");
                        LoadCustomers();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error");
            }
        }

        // 🔹 Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text == "")
            {
                MessageBox.Show("Please select a customer to delete.", "Warning");
                return;
            }
            if (MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // **SỬA LẠI TÊN BẢNG**
                    string query = "DELETE FROM Customers WHERE customer_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtCustomerId.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer deleted successfully!");
                    LoadCustomers();
                    ClearFormFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting. Customer might be linked to Orders.\n" + ex.Message, "Error");
            }
        }

        // 🔹 Find
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text == "")
            {
                MessageBox.Show("Please enter a Customer ID to find.", "Warning");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // **SỬA LẠI CÂU SQL VÀ TÊN CỘT**
                string query = "SELECT customer_id, full_name, phone, email, address FROM Customers WHERE customer_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtCustomerId.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}