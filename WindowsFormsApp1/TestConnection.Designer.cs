namespace WindowsFormsApp1
{
    partial class TestConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Connection
            // 
            this.Connection.Location = new System.Drawing.Point(276, 172);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(123, 77);
            this.Connection.TabIndex = 0;
            this.Connection.Text = "Connection";
            this.Connection.UseVisualStyleBackColor = true;
            this.Connection.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 445);
            this.Controls.Add(this.Connection);
            this.Name = "TestConnection";
            this.Text = "TestConnection";
            this.Load += new System.EventHandler(this.TestConnection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Connection;
    }
}