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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            Login_Form fr = new Login_Form();
            fr.Show();
            this.Hide();
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
    }
}
