using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
        public AdminForm(string name, string position)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome Admin {name} - {position}";
        }

        // 🔹 HÀM MỚI: Dùng để mở Form con và ẩn Form cha
        private void OpenChildForm(Form childForm)
        {
            // Đăng ký một sự kiện: Khi form con bị đóng, hãy gọi hàm để hiện lại AdminForm
            childForm.FormClosed += ChildForm_Closed;

            // Hiển thị form con
            childForm.Show();

            // Ẩn form cha (AdminForm)
            this.Hide();
        }

        // 🔹 HÀM MỚI: Được gọi khi form con bị đóng
        private void ChildForm_Closed(object sender, FormClosedEventArgs e)
        {
            // Hiện lại AdminForm
            this.Show();
        }


        // 🔹 Cập nhật lại tất cả các hàm Click
        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeForm());
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomerForm());
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductForm());
        }

        private void btnManageWarehouse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new WarehouseForm());
        }

        private void btnManageImports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ImportForm());
        }
    }
}