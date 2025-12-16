namespace WindowsFormsApp1
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;

        // KHAI BÁO CÁC NÚT MỚI
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnManageWarehouse;
        private System.Windows.Forms.Button btnManageImports;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnManageWarehouse = new System.Windows.Forms.Button();
            this.btnManageImports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(10, 8);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(87, 21);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome!";
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmployees.Location = new System.Drawing.Point(34, 52);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(205, 35);
            this.btnManageEmployees.TabIndex = 1;
            this.btnManageEmployees.Text = "Manage Employees";
            this.btnManageEmployees.UseVisualStyleBackColor = true;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnManageCustomers.Location = new System.Drawing.Point(34, 95);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(205, 35);
            this.btnManageCustomers.TabIndex = 2;
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = true;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnManageProducts.Location = new System.Drawing.Point(34, 139);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(205, 35);
            this.btnManageProducts.TabIndex = 3;
            this.btnManageProducts.Text = "Manage Products";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            // 
            // btnManageWarehouse
            // 
            this.btnManageWarehouse.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnManageWarehouse.Location = new System.Drawing.Point(34, 182);
            this.btnManageWarehouse.Name = "btnManageWarehouse";
            this.btnManageWarehouse.Size = new System.Drawing.Size(205, 35);
            this.btnManageWarehouse.TabIndex = 4;
            this.btnManageWarehouse.Text = "Manage Warehouse";
            this.btnManageWarehouse.UseVisualStyleBackColor = true;
            this.btnManageWarehouse.Click += new System.EventHandler(this.btnManageWarehouse_Click);
            // 
            // btnManageImports
            // 
            this.btnManageImports.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnManageImports.Location = new System.Drawing.Point(34, 225);
            this.btnManageImports.Name = "btnManageImports";
            this.btnManageImports.Size = new System.Drawing.Size(205, 35);
            this.btnManageImports.TabIndex = 5;
            this.btnManageImports.Text = "Manage Imports";
            this.btnManageImports.UseVisualStyleBackColor = true;
            this.btnManageImports.Click += new System.EventHandler(this.btnManageImports_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 520);
            this.Controls.Add(this.btnManageImports);
            this.Controls.Add(this.btnManageWarehouse);
            this.Controls.Add(this.btnManageProducts);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.lblWelcome);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}