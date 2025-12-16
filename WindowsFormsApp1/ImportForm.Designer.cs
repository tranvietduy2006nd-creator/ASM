namespace WindowsFormsApp1
{
    partial class ImportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvImports = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMasterEmployeeId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpMasterImportDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddNewImport = new System.Windows.Forms.Button();
            this.btnDeleteImport = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearMaster = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvImportDetails = new System.Windows.Forms.DataGridView();
            this.txtDetailCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDetailQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDetailProductId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetailImportDetailId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnClearDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImports
            // 
            this.dgvImports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImports.Location = new System.Drawing.Point(16, 32);
            this.dgvImports.Name = "dgvImports";
            this.dgvImports.ReadOnly = true;
            this.dgvImports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImports.Size = new System.Drawing.Size(434, 150);
            this.dgvImports.TabIndex = 0;
            this.dgvImports.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImports_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee ID";
            // 
            // txtMasterEmployeeId
            // 
            this.txtMasterEmployeeId.Location = new System.Drawing.Point(533, 32);
            this.txtMasterEmployeeId.Name = "txtMasterEmployeeId";
            this.txtMasterEmployeeId.Size = new System.Drawing.Size(139, 20);
            this.txtMasterEmployeeId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Import Date";
            // 
            // dtpMasterImportDate
            // 
            this.dtpMasterImportDate.Location = new System.Drawing.Point(533, 59);
            this.dtpMasterImportDate.Name = "dtpMasterImportDate";
            this.dtpMasterImportDate.Size = new System.Drawing.Size(139, 20);
            this.dtpMasterImportDate.TabIndex = 4;
            // 
            // btnAddNewImport
            // 
            this.btnAddNewImport.Location = new System.Drawing.Point(463, 94);
            this.btnAddNewImport.Name = "btnAddNewImport";
            this.btnAddNewImport.Size = new System.Drawing.Size(209, 23);
            this.btnAddNewImport.TabIndex = 5;
            this.btnAddNewImport.Text = "Add New Import Record";
            this.btnAddNewImport.UseVisualStyleBackColor = true;
            this.btnAddNewImport.Click += new System.EventHandler(this.btnAddNewImport_Click);
            // 
            // btnDeleteImport
            // 
            this.btnDeleteImport.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteImport.Location = new System.Drawing.Point(463, 159);
            this.btnDeleteImport.Name = "btnDeleteImport";
            this.btnDeleteImport.Size = new System.Drawing.Size(209, 23);
            this.btnDeleteImport.TabIndex = 6;
            this.btnDeleteImport.Text = "Delete Selected Import";
            this.btnDeleteImport.UseVisualStyleBackColor = false;
            this.btnDeleteImport.Click += new System.EventHandler(this.btnDeleteImport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClearMaster);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.dgvImports);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteImport);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddNewImport);
            this.splitContainer1.Panel1.Controls.Add(this.txtMasterEmployeeId);
            this.splitContainer1.Panel1.Controls.Add(this.dtpMasterImportDate);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClearDetails);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveProduct);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdateProduct);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddProduct);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.txtDetailCost);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtDetailQuantity);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtDetailProductId);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtDetailImportDetailId);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.dgvImportDetails);
            this.splitContainer1.Size = new System.Drawing.Size(684, 411);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 7;
            // 
            // btnClearMaster
            // 
            this.btnClearMaster.Location = new System.Drawing.Point(463, 123);
            this.btnClearMaster.Name = "btnClearMaster";
            this.btnClearMaster.Size = new System.Drawing.Size(209, 23);
            this.btnClearMaster.TabIndex = 8;
            this.btnClearMaster.Text = "Clear Fields";
            this.btnClearMaster.UseVisualStyleBackColor = true;
            this.btnClearMaster.Click += new System.EventHandler(this.btnClearMaster_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Step 1: Select/Add Imports";
            // 
            // dgvImportDetails
            // 
            this.dgvImportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportDetails.Location = new System.Drawing.Point(16, 31);
            this.dgvImportDetails.Name = "dgvImportDetails";
            this.dgvImportDetails.ReadOnly = true;
            this.dgvImportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImportDetails.Size = new System.Drawing.Size(434, 168);
            this.dgvImportDetails.TabIndex = 8;
            this.dgvImportDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportDetails_CellClick);
            // 
            // txtDetailCost
            // 
            this.txtDetailCost.Location = new System.Drawing.Point(533, 110);
            this.txtDetailCost.Name = "txtDetailCost";
            this.txtDetailCost.Size = new System.Drawing.Size(139, 20);
            this.txtDetailCost.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Import Cost";
            // 
            // txtDetailQuantity
            // 
            this.txtDetailQuantity.Location = new System.Drawing.Point(533, 84);
            this.txtDetailQuantity.Name = "txtDetailQuantity";
            this.txtDetailQuantity.Size = new System.Drawing.Size(139, 20);
            this.txtDetailQuantity.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Quantity";
            // 
            // txtDetailProductId
            // 
            this.txtDetailProductId.Location = new System.Drawing.Point(533, 58);
            this.txtDetailProductId.Name = "txtDetailProductId";
            this.txtDetailProductId.Size = new System.Drawing.Size(139, 20);
            this.txtDetailProductId.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Product ID";
            // 
            // txtDetailImportDetailId
            // 
            this.txtDetailImportDetailId.Location = new System.Drawing.Point(533, 32);
            this.txtDetailImportDetailId.Name = "txtDetailImportDetailId";
            this.txtDetailImportDetailId.ReadOnly = true;
            this.txtDetailImportDetailId.Size = new System.Drawing.Size(139, 20);
            this.txtDetailImportDetailId.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Detail ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Step 2: Manage Products in Import";
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.MistyRose;
            this.btnRemoveProduct.Location = new System.Drawing.Point(577, 166);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveProduct.TabIndex = 19;
            this.btnRemoveProduct.Text = "Remove";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(463, 166);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(108, 23);
            this.btnUpdateProduct.TabIndex = 18;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(463, 137);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(108, 23);
            this.btnAddProduct.TabIndex = 17;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnClearDetails
            // 
            this.btnClearDetails.Location = new System.Drawing.Point(577, 137);
            this.btnClearDetails.Name = "btnClearDetails";
            this.btnClearDetails.Size = new System.Drawing.Size(95, 23);
            this.btnClearDetails.TabIndex = 20;
            this.btnClearDetails.Text = "Clear Fields";
            this.btnClearDetails.UseVisualStyleBackColor = true;
            this.btnClearDetails.Click += new System.EventHandler(this.btnClearDetails_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImportForm";
            this.Text = "Import Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportDetails)).EndInit();
            this.ResumeLayout(false);

        }

        // Khai báo các control
        private System.Windows.Forms.DataGridView dgvImports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMasterEmployeeId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpMasterImportDate;
        private System.Windows.Forms.Button btnAddNewImport;
        private System.Windows.Forms.Button btnDeleteImport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvImportDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDetailCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDetailQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDetailProductId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetailImportDetailId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnClearMaster;
        private System.Windows.Forms.Button btnClearDetails;
    }
}