using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WarehouseForm : Form
    {
        string connectionString = @"Data Source=LAPTOP-MNJ9PDI7\SQLEXPRESS;Initial Catalog=ClothingFashioStore;Integrated Security=True";

        // 🔹 HÀM KHỞI TẠO 1 (0 tham số - Dùng cho Admin)
        public WarehouseForm()
        {
            InitializeComponent();
            LoadWarehouses();
        }

        // 🔹 HÀM KHỞI TẠO 2 (2 tham số - Dùng cho Login) (MỚI)
        public WarehouseForm(string name, string position)
        {
            InitializeComponent();
            LoadWarehouses();
            // Gán text cho label welcome
            lblWelcome.Text = $"Welcome Warehouse Staff {name} - {position}";
        }


        // 🔹 Load
        private void LoadWarehouses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT warehouse_id,
                                    warehouse_code,
                                    warehouse_name,
                                    address,
                                    phone,
                                    manager_id
                             FROM Warehouses";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Warehouses error:\n" + ex.Message);
            }
        }

        // 🔹 Clear
        private void ClearFormFields()
        {
            txtWarehouseId.Text = "";
            txtWarehouseName.Text = "";
            txtLocation.Text = "";
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
                txtWarehouseId.Text = row.Cells["warehouse_id"].Value?.ToString();
                txtWarehouseName.Text = row.Cells["warehouse_name"].Value.ToString();
                txtLocation.Text = row.Cells["location"].Value.ToString();

            }
        }

        // 🔹 Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtWarehouseName.Text == "")
            {
                MessageBox.Show("Please fill Warehouse Name!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Warehouses
                             (warehouse_code, warehouse_name, address, phone, manager_id)
                             VALUES
                             (@code, @name, @address, @phone, @manager)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    cmd.Parameters.AddWithValue("@name", txtWarehouseName.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Warehouse added successfully!");
                    LoadWarehouses();
                    ClearFormFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error:\n" + ex.Message);
            }
        }

        // 🔹 Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtWarehouseId.Text == "")
            {
                MessageBox.Show("Please select a warehouse to edit.", "Warning");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // **SỬA LẠI CÂU SQL VÀ TÊN CỘT**
                    string query = @"UPDATE Warehouses 
                                   SET warehouse_name=@name, 
                                       location=@loc
                                   WHERE warehouse_id=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtWarehouseName.Text);
                    cmd.Parameters.AddWithValue("@loc", txtLocation.Text);
                    cmd.Parameters.AddWithValue("@id", txtWarehouseId.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Warehouse updated successfully!");
                        LoadWarehouses();
                    }
                    else
                    {
                        MessageBox.Show("Warehouse not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating warehouse: " + ex.Message, "Error");
            }
        }

        // 🔹 Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtWarehouseId.Text == "")
            {
                MessageBox.Show("Please select a warehouse to delete.", "Warning");
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
                    string query = "DELETE FROM Warehouses WHERE warehouse_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtWarehouseId.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Warehouse deleted successfully!");
                    LoadWarehouses();
                    ClearFormFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting. Warehouse might be linked to stock.\n" + ex.Message, "Error");
            }
        }

        // 🔹 Find
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtWarehouseId.Text == "")
            {
                MessageBox.Show("Please enter a Warehouse ID to find.", "Warning");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // ✅ ĐÚNG THEO DB CỦA BẠN
                string query = @"SELECT warehouse_id,
                                warehouse_code,
                                warehouse_name,
                                address,
                                phone,
                                manager_id
                         FROM Warehouses
                         WHERE warehouse_id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtWarehouseId.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔴 LOGIC CHECK KHÔNG TÌM THẤY
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Warehouse ID not found!", "Info");
                    return;
                }

                dataGridView1.DataSource = dt;
            }
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {

        }
    }
}