using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_Oriented_Programming_Assingnment
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "Admin" && txtPass.Text == "Admin123")
            {
                MessageBox.Show("Valid UserName & Password");
                Form3 form = new Form3();
                form.Show();
                this.Hide();
            }
            else if (txtUser.Text == "User" && txtPass.Text == "User123")
            {
                MessageBox.Show("Valid UserName & Password");
                Form3 form = new Form3();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username & Passward");
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Do you want to Exit?", "Exit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly);
            if (dl.ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
