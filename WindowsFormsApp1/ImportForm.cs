using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ImportForm : Form
    {
        string connectionString = @"Data Source=LAPTOP-MNJ9PDI7\SQLEXPRESS;Initial Catalog=ClothingFashioStore;Integrated Security=True";

        // Biến để lưu ID của lô hàng (master) đang được chọn
        private int selectedImportId = 0;

        public ImportForm()
        {
            InitializeComponent();
            LoadMasterImports();
        }

        // ----------------------------------------------------------------------
        // PHẦN MASTER (BẢNG IMPORTS - PHÍA TRÊN)
        // ----------------------------------------------------------------------

        // 🔹 1. Tải danh sách các Lô hàng (Bảng Imports)
        private void LoadMasterImports()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // **SỬA LẠI TÊN CỘT import_data NẾU CẦN**
                string query = "SELECT import_id, employee_id, import_data FROM Imports";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvImports.DataSource = dt;
            }
        }

        // 🔹 2. Khi click vào 1 lô hàng (dgvImports)...
        private void dgvImports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvImports.Rows[e.RowIndex];

                // Lấy ID của lô hàng
                selectedImportId = Convert.ToInt32(row.Cells["import_id"].Value);

                // Hiển thị thông tin master
                txtMasterEmployeeId.Text = row.Cells["employee_id"].Value.ToString();
                dtpMasterImportDate.Value = Convert.ToDateTime(row.Cells["import_data"].Value);

                // Tải chi tiết của lô hàng này
                LoadImportDetails(selectedImportId);
            }
        }

        // 🔹 3. Thêm một Lô hàng MỚI (chưa có sản phẩm)
        private void btnAddNewImport_Click(object sender, EventArgs e)
        {
            if (txtMasterEmployeeId.Text == "")
            {
                MessageBox.Show("Please enter an Employee ID.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // **SỬA LẠI TÊN CỘT import_data NẾU CẦN**
                    string query = "INSERT INTO Imports (employee_id, import_data) VALUES (@empId, @date)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@empId", txtMasterEmployeeId.Text);
                    cmd.Parameters.AddWithValue("@date", dtpMasterImportDate.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New import record created. You can now add products to it.");
                    LoadMasterImports(); // Tải lại danh sách
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating import record: " + ex.Message);
            }
        }

        // 🔹 4. Xóa một Lô hàng (và tất cả sản phẩm bên trong)
        private void btnDeleteImport_Click(object sender, EventArgs e)
        {
            if (selectedImportId == 0)
            {
                MessageBox.Show("Please select an import record from the top list to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this ENTIRE import and all its products?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // BƯỚC 1: Xóa Chi tiết (Con) trước
                    SqlCommand cmdDetail = new SqlCommand("DELETE FROM Importdetail WHERE import_id = @id", conn);
                    cmdDetail.Parameters.AddWithValue("@id", selectedImportId);
                    cmdDetail.ExecuteNonQuery();

                    // BƯỚC 2: Xóa Master (Cha)
                    SqlCommand cmdMaster = new SqlCommand("DELETE FROM Imports WHERE import_id = @id", conn);
                    cmdMaster.Parameters.AddWithValue("@id", selectedImportId);
                    cmdMaster.ExecuteNonQuery();

                    MessageBox.Show("Import record deleted successfully.");
                    LoadMasterImports(); // Tải lại
                    dgvImportDetails.DataSource = null; // Xóa lưới chi tiết
                    ClearMasterFields();
                    ClearDetailFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting import record: " + ex.Message);
            }
        }


        // ----------------------------------------------------------------------
        // PHẦN DETAIL (BẢNG IMPORTDETAIL - PHÍA DƯỚI)
        // ----------------------------------------------------------------------

        // 🔹 5. Tải Chi tiết Lô hàng
        private void LoadImportDetails(int importId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // **SỬA LẠI TÊN BẢNG VÀ CỘT NẾU CẦN**
                string query = "SELECT importdetail_id, product_id, quantity, import_cost FROM Importdetail WHERE import_id = @id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", importId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvImportDetails.DataSource = dt;
            }
        }

        // 🔹 6. Khi click vào 1 sản phẩm chi tiết...
        private void dgvImportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvImportDetails.Rows[e.RowIndex];

                // Hiển thị thông tin chi tiết
                txtDetailImportDetailId.Text = row.Cells["importdetail_id"].Value.ToString();
                txtDetailProductId.Text = row.Cells["product_id"].Value.ToString();
                txtDetailQuantity.Text = row.Cells["quantity"].Value.ToString();
                txtDetailCost.Text = row.Cells["import_cost"].Value.ToString();
            }
        }

        // 🔹 7. Thêm 1 sản phẩm VÀO Lô hàng (đang chọn)
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (selectedImportId == 0)
            {
                MessageBox.Show("Please select an import record from the top list first.");
                return;
            }
            if (txtDetailProductId.Text == "" || txtDetailQuantity.Text == "" || txtDetailCost.Text == "")
            {
                MessageBox.Show("Please fill all product fields: ID, Quantity, and Cost.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Importdetail (import_id, product_id, quantity, import_cost) VALUES(@importId, @pid, @qty, @cost)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@importId", selectedImportId);
                    cmd.Parameters.AddWithValue("@pid", txtDetailProductId.Text);
                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(txtDetailQuantity.Text));
                    cmd.Parameters.AddWithValue("@cost", Convert.ToDecimal(txtDetailCost.Text));

                    cmd.ExecuteNonQuery();
                    LoadImportDetails(selectedImportId); // Tải lại lưới chi tiết
                    ClearDetailFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        // 🔹 8. Cập nhật 1 sản phẩm (trong lô hàng)
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (txtDetailImportDetailId.Text == "")
            {
                MessageBox.Show("Please select a product from the bottom list to update.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Importdetail 
                                   SET product_id = @pid, 
                                       quantity = @qty, 
                                       import_cost = @cost 
                                   WHERE importdetail_id = @detailId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@pid", txtDetailProductId.Text);
                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(txtDetailQuantity.Text));
                    cmd.Parameters.AddWithValue("@cost", Convert.ToDecimal(txtDetailCost.Text));
                    cmd.Parameters.AddWithValue("@detailId", txtDetailImportDetailId.Text);

                    cmd.ExecuteNonQuery();
                    LoadImportDetails(selectedImportId); // Tải lại lưới chi tiết
                    ClearDetailFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        // 🔹 9. Xóa 1 sản phẩm (khỏi lô hàng)
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (txtDetailImportDetailId.Text == "")
            {
                MessageBox.Show("Please select a product from the bottom list to remove.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Importdetail WHERE importdetail_id = @detailId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@detailId", txtDetailImportDetailId.Text);

                    cmd.ExecuteNonQuery();
                    LoadImportDetails(selectedImportId); // Tải lại lưới chi tiết
                    ClearDetailFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing product: " + ex.Message);
            }
        }


        // ----------------------------------------------------------------------
        // HÀM HỖ TRỢ (Xóa trắng)
        // ----------------------------------------------------------------------
        private void ClearMasterFields()
        {
            selectedImportId = 0;
            txtMasterEmployeeId.Text = "";
            dtpMasterImportDate.Value = DateTime.Now;
        }

        private void ClearDetailFields()
        {
            txtDetailImportDetailId.Text = "";
            txtDetailProductId.Text = "";
            txtDetailQuantity.Text = "";
            txtDetailCost.Text = "";
        }

        private void btnClearMaster_Click(object sender, EventArgs e)
        {
            ClearMasterFields();
        }

        private void btnClearDetails_Click(object sender, EventArgs e)
        {
            ClearDetailFields();
        }
    }
}