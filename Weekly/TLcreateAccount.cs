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

namespace Weekly
{
    public partial class TLcreateAccount : Form
    {
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;";
        public TLcreateAccount()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                    MessageBox.Show("Please Fill Mandatory Fields!");
                else if (txtPassword.Text != txtconfrim.Text)
                    MessageBox.Show("Password do not match!");
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("TL", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", txtLastname.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Account Create Successfully!");


                        Clear();
                    }
                }
            }
            void Clear()
            {
                txtFirstname.Text = txtLastname.Text  = txtUsername.Text = txtPassword.Text = txtconfrim.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamLeader f3 = new TeamLeader();
            f3.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtconfrim_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
