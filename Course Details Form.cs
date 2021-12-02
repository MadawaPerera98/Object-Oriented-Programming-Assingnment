using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_Oriented_Programming_Assingnment
{
    public partial class Course_Details_Form : Form
    {
        public Course_Details_Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6S66NPUE;Initial Catalog=oopassignment;Integrated Security=True");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string couseId = txtcusId.Text;
                string csName = txtcName.Text;
                string dev = txtDiv.Text;
                string cdu = txtCdu.Text;
                string fee = txtFee.Text;

                //sql query
                string query_insert = "insert into Course_Details_Table Values('"+couseId+ "','" +csName+ "','"+dev+ "','"+cdu+ "','"+fee+"')";
                //sql command 
                SqlCommand cmnd = new SqlCommand(query_insert,con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Add successfully !");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error"+ex);  
            }
            finally
            {
                //closing connection 
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string update_query = "UPDATE Course_Details_Table SET CName = '" + txtcName.Text + "', Division = '" + txtDiv.Text + "', CDuration = '" + txtCdu.Text + "',CFee = '" + txtFee.Text + "' WHERE COID = '"+txtcusId+"'";
                //sql command 
                SqlCommand cmnd = new SqlCommand(update_query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("update successfully !");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                //closing connection 
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to delete this record ? ", "Sure ? ", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                string delete_query = "DELETE FROM Course_Details_Table WHERE COID ='" + txtcusId.Text + "'";
                MessageBox.Show("delete successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closing connection 
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment_Details_Form pform = new Payment_Details_Form();
            this.Hide();
            pform.Show();
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

            txtcusId.Text = string.Empty;
            txtcName.Text = string.Empty;
            txtDiv.Text = string.Empty;
            txtCdu.Text = string.Empty;
            txtFee.Text = string.Empty;
        }
    }
}
