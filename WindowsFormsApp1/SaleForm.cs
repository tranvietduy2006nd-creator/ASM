using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class SalesForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-OHNECE1;Initial Catalog=ClothingFashioStore;Integrated Security=True";

        public SalesForm(string name, string position)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome Sales Staff {name} - {position}";
            LoadOrders();
        }

        // 🔹 Load toàn bộ danh sách đơn hàng
        private void LoadOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // 🔹 Xóa trắng các ô nhập liệu
        private void ClearFormFields()
        {
            txtOrderId.Text = "";
            txtCustomerId.Text = "";
            txtEmployeeId.Text = "";
            txtStatus.Text = "";
            txtTotalAmount.Text = "";
            dtpOrderDate.Value = DateTime.Now;
        }

        // 🔹 SỰ KIỆN CHO NÚT CLEAR
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }


        // 🔹 Tự động điền thông tin khi click vào một hàng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào một hàng hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // THỨ TỰ CỘT DỰA TRÊN HÌNH ẢNH CỦA BẠN
                // [0]: order_id
                // [1]: order_date
                // [2]: employee_id
                // [3]: customer_id
                // [4]: total_amount
                // [5]: status (Giả định 'status' là cột 5)

                txtOrderId.Text = row.Cells[0].Value.ToString();

                if (row.Cells[1].Value != DBNull.Value)
                {
                    dtpOrderDate.Value = Convert.ToDateTime(row.Cells[1].Value);
                }

                txtEmployeeId.Text = row.Cells[2].Value.ToString();
                txtCustomerId.Text = row.Cells[3].Value.ToString();
                txtTotalAmount.Text = row.Cells[4].Value.ToString();

                // Kiểm tra xem cột 'status' có tồn tại không
                if (dataGridView1.Columns.Contains("status") && row.Cells["status"].Value != DBNull.Value)
                {
                    txtStatus.Text = row.Cells["status"].Value.ToString();
                }
                // Nếu cột status ở vị trí cố định (ví dụ: 5)
                // else if (row.Cells.Count > 5 && row.Cells[5].Value != DBNull.Value)
                // {
                //    txtStatus.Text = row.Cells[5].Value.ToString();
                // }
                else
                {
                    txtStatus.Text = ""; // Xóa status cũ nếu không có
                }
            }
        }


        // 🔹 Tìm đơn hàng theo ID
        private void FindOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text == "")
            {
                MessageBox.Show("Please enter Order ID to search!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders WHERE order_id=@orderid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderid", txtOrderId.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // 🔹 THÊM MỘT ĐƠN HÀNG MỚI
        private void AddOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text != "")
            {
                MessageBox.Show("Please clear the form before adding a new order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCustomerId.Text == "" || txtEmployeeId.Text == "" || txtTotalAmount.Text == "" || txtStatus.Text == "")
            {
                MessageBox.Show("Please enter all fields: Customer ID, Employee ID, Total Amount, and Status!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu query (Giả sử cột trong DB tên là employee_id, total_amount, status)
                    string query = "INSERT INTO Orders (customer_id, order_date, employee_id, total_amount, status)VALUES(@customer, @date, @employeeid, @totalamount, @status)";


                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Lấy giá trị từ Controls, KHÔNG phải biến
                    cmd.Parameters.AddWithValue("@customer", txtCustomerId.Text);
                    cmd.Parameters.AddWithValue("@date", dtpOrderDate.Value);
                    cmd.Parameters.AddWithValue("@employeeid", txtEmployeeId.Text);
                    cmd.Parameters.AddWithValue("@totalamount", Convert.ToDecimal(txtTotalAmount.Text));
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Order added successfully!");
                    LoadOrders();
                    ClearFormFields();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Total Amount. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 🔹 Xóa đơn hàng
        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text == "")
            {
                MessageBox.Show("Please select an order from the list (or find by ID) to delete!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdDetail = new SqlCommand("DELETE FROM OrderDetail WHERE order_id=@id", conn);
                cmdDetail.Parameters.AddWithValue("@id", txtOrderId.Text);
                cmdDetail.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE order_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtOrderId.Text);
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Order deleted successfully!");
                LoadOrders();
                ClearFormFields();
            }
        }

        // 🔹 Sửa thông tin đơn hàng
        private void EditOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text == "")
            {
                MessageBox.Show("Please select an order from the list (or find by ID) to edit!");
                return;
            }

            if (txtCustomerId.Text == "" || txtEmployeeId.Text == "" || txtTotalAmount.Text == "" || txtStatus.Text == "")
            {
                MessageBox.Show("Please enter all fields: Customer ID, Employee ID, Total Amount, and Status!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Orders 
                                   SET customer_id=@customer, 
                                       order_date=@date, 
                                       employee_id=@employeeid, 
                                       total_amount=@totalamount, 
                                       status=@status 
                                   WHERE order_id=@orderid";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Lấy giá trị từ Controls, KHÔNG phải biến
                    cmd.Parameters.AddWithValue("@customer", txtCustomerId.Text);
                    cmd.Parameters.AddWithValue("@date", dtpOrderDate.Value);
                    cmd.Parameters.AddWithValue("@employeeid", txtEmployeeId.Text);
                    cmd.Parameters.AddWithValue("@totalamount", Convert.ToDecimal(txtTotalAmount.Text));
                    cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@orderid", txtOrderId.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Order updated successfully!");
                        LoadOrders();
                    }
                    else
                    {
                        MessageBox.Show("No order found with that ID!");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Total Amount. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}