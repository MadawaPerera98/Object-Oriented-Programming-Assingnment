using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Object_Oriented_Programming_Assingnment
{
    public partial class Student_Form : Form
    {
        public Student_Form()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6S66NPUE;Initial Catalog=oopassignment;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //taking value from GUI
                string regNo = txtReg.Text;
                string fname = txtFname.Text;
                string lname = txtLname.Text;
                string address = txtAddress.Text;
                DateTime dob = dtpDob.Value;
                string contact = txtCont.Text;
                string age = txtAge.Text;

                //sql query
                string qurey_insert = "insert into Student_Details_Table values('"+regNo+"','"+fname+"','"+lname+"','"+address+"','"+dob+"','"+contact+"','"+age+"')";
                SqlCommand cmnd = new SqlCommand(qurey_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Student Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dob = dtpDob.Value;
                string update_query = "UPDATE Student_Details_Table SET FName = '"+txtFname.Text+"', LName = '"+txtLname.Text+"', Address = '"+txtAddress.Text+"',DOB = '"+dob+"', Age = '"+txtAge.Text+"' WHERE RegNo = '"+txtReg.Text+"'";
                SqlCommand cmnd = new SqlCommand(update_query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReg.Text = string.Empty;
            txtFname.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtAge.Text = string.Empty;
            dtpDob.ResetText();
            txtCont.Text = string.Empty;
            txtAge.Text = string.Empty;
            MessageBox.Show("All fields cleared");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Are you sure, you want to delete this record ? ", "Sure ? ", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                string deletesql = "delete from Student_Details_Table where FName =  '"+txtFname+"'";
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Student delete Successfully");
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Course_Details_Form cform = new Course_Details_Form();
            this.Hide();
            cform.Show();
        }
    }
}
