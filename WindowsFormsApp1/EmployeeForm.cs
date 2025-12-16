using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    // Kế thừa từ Form
    public partial class EmployeeForm : Form
    {
        // **THAY ĐỔI** chuỗi kết nối của bạn tại đây
        string connectionString = @"Data Source=LAPTOP-MNJ9PDI7\SQLEXPRESS;Initial Catalog=ClothingFashioStore;Integrated Security=True";

        public EmployeeForm()
        {
            InitializeComponent();
            LoadEmployees();
        }

        // 🔹 Load toàn bộ danh sách nhân viên
        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // **LƯU Ý:** Không bao giờ SELECT password!
                string query = "SELECT employee_id, employees_name, position, username FROM Employees";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // 🔹 Xóa trắng các ô nhập liệu
        private void ClearFormFields()
        {
            txtEmployeeId.Text = "";
            txtFullName.Text = "";
            txtPosition.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        // 🔹 Nút Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        // 🔹 Click vào 1 hàng để điền dữ liệu
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtEmployeeId.Text = row.Cells["employee_id"].Value.ToString();
                txtFullName.Text = row.Cells["full_name"].Value.ToString();
                txtPosition.Text = row.Cells["position"].Value.ToString();
                txtUsername.Text = row.Cells["username"].Value.ToString();

                // Để trống ô mật khẩu để bảo mật
                txtPassword.Text = "";
            }
        }

        // 🔹 Thêm nhân viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text != "")
            {
                MessageBox.Show("Please clear the form before adding.", "Warning");
                return;
            }

            if (txtFullName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPosition.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Employees (full_name, position, username, password) VALUES(@fname, @pos, @uname, @pass)";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@pos", txtPosition.Text);
                    cmd.Parameters.AddWithValue("@uname", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text); // Bạn nên mã hóa mật khẩu ở đây

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee added successfully!");
                    LoadEmployees();
                    ClearFormFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message, "Error");
            }
        }

        // 🔹 Sửa thông tin nhân viên
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "")
            {
                MessageBox.Show("Please select an employee to edit.", "Warning");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu query cơ bản
                    string query = @"UPDATE Employees 
                                   SET full_name=@fname, 
                                       position=@pos, 
                                       username=@uname 
                                   WHERE employee_id=@id";

                    // **QUAN TRỌNG:** Chỉ cập nhật mật khẩu NẾU người dùng nhập mật khẩu mới
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        query = @"UPDATE Employees 
                                SET full_name=@fname, 
                                    position=@pos, 
                                    username=@uname, 
                                    password=@pass 
                                WHERE employee_id=@id";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@pos", txtPosition.Text);
                    cmd.Parameters.AddWithValue("@uname", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@id", txtEmployeeId.Text);

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text); // Thêm nếu có pass mới
                    }

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Employee updated successfully!");
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message, "Error");
            }
        }

        // 🔹 Xóa nhân viên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "")
            {
                MessageBox.Show("Please select an employee to delete.", "Warning");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lưu ý: Cần xử lý ràng buộc khóa ngoại (FK) nếu nhân viên này
                    // đã tạo đơn hàng (Orders)
                    string query = "DELETE FROM Employees WHERE employee_id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtEmployeeId.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully!");
                    LoadEmployees();
                    ClearFormFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee. They might be linked to other records (e.g., Orders). \n" + ex.Message, "Error");
            }
        }

        // 🔹 Tìm nhân viên (theo ID)
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "")
            {
                MessageBox.Show("Please enter an Employee ID to find.", "Warning");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT employee_id, full_name, position, username FROM Employees WHERE employee_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtEmployeeId.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}