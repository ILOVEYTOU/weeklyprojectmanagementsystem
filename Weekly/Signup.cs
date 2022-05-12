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
    public partial class Signup : Form
    {
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;";
        public Signup()
        {
            InitializeComponent();
        }

      
        
        private void button1_Click_1(object sender, EventArgs e)
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
                    SqlCommand sqlCmd = new SqlCommand("UsersAdd" , sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Employee_ID", txtEmployee.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Signup Successfully!");
                    

                    Clear();
                }
            }
        }
        void Clear()
        {
            txtFirstname.Text = txtLastname.Text = txtEmployee.Text = txtUsername.Text = txtPassword.Text = txtconfrim.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f1 = new Login();
            f1.Show();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }
    }
}
