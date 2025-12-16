using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserForm : Form
    {
        public UserForm(string name, string position)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome {name} - {position}";
        }
    }
}
