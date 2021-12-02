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
    public partial class Payment_Details_Form : Form
    {
        public Payment_Details_Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6S66NPUE;Initial Catalog=oopassignment;Integrated Security=True");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string regno = txtReg.Text;
                string cusName = txtCname.Text;
                string ammount = txtAmount.Text;

                string query_instert = "INSERT INTO Payment_Details_Table VALUES ('"+regno+"','"+cusName+"','"+comPay.SelectedItem+"','"+ammount+"')";
                SqlCommand cmnd = new SqlCommand(query_instert,con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Payment successfully");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpadate_Click(object sender, EventArgs e)
        {
            try
            {
                string update_query = "UPDATE Payment_Details_Table  set CName = '" + txtCname.Text + "', Payment = '" + comPay.SelectedItem + "', Amount = '"+txtAmount.Text+"' WHERE RegNo = '"+txtReg.Text+"'";
                SqlCommand cmnd = new SqlCommand(update_query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
            txtCname.Text = string.Empty;
            comPay.SelectedItem = string.Empty;
            txtAmount.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to delete this record ? ", "Sure ? ", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                string delete_query = "DELETE FROM Payment_Details_Table WHERE RegNo = '" + txtReg.Text + "'";
                SqlCommand cmnd = new SqlCommand(delete_query, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("delete successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
