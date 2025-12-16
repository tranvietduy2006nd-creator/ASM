using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class ProductForm : Form
    {
        DataTable productTable;

        public ProductForm()
        {
            InitializeComponent();
            InitializeProductData();
        }

        private void InitializeProductData()
        {
            // Create a DataTable to simulate a product database
            productTable = new DataTable();
            productTable.Columns.Add("Product ID");
            productTable.Columns.Add("Name");
            productTable.Columns.Add("Quantity", typeof(int));
            productTable.Columns.Add("Price", typeof(decimal));

            // Sample data
            productTable.Rows.Add("P001", "Laptop", 10, 1200.00m);
            productTable.Rows.Add("P002", "Mouse", 25, 20.50m);
            productTable.Rows.Add("P003", "Keyboard", 15, 45.99m);
            productTable.Rows.Add("P004", "Monitor", 8, 300.00m);

            dgvProducts.DataSource = productTable;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvProducts.DataSource = productTable;
                return;
            }

            var filtered = productTable.AsEnumerable()
                .Where(row => row["Name"].ToString().ToLower().Contains(keyword))
                .CopyToDataTable();

            dgvProducts.DataSource = filtered;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvProducts.Rows[e.RowIndex].Cells["Product ID"].Value.ToString();
                txtName.Text = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtQuantity.Text = dgvProducts.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            var row = productTable.AsEnumerable().FirstOrDefault(r => r["Product ID"].ToString() == id);
            if (row == null)
            {
                MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            row["Name"] = txtName.Text;
            row["Quantity"] = int.TryParse(txtQuantity.Text, out int q) ? q : 0;
            row["Price"] = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0m;

            dgvProducts.Refresh();
            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            var row = productTable.AsEnumerable().FirstOrDefault(r => r["Product ID"].ToString() == id);
            if (row == null)
            {
                MessageBox.Show("Select a product to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            productTable.Rows.Remove(row);
            dgvProducts.DataSource = productTable;
            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
