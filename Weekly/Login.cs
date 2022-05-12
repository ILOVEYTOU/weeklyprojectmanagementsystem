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
    public partial class Login : Form
    {
        public static string username;
        public Login()
        {
            InitializeComponent();
        }
        
               SqlConnection conn = new SqlConnection( @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;");
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String Username, Password;
            Username = txtUsername.Text;
            Password = txtPassword.Text;

            username = txtUsername.Text;

            try 
            {
                String querry = "SELECT * FROM Signup1 WHERE Username ='"+txtUsername.Text+"' AND Password = '"+txtPassword.Text+"' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                String qwerty = "SELECT * FROM TLaccount WHERE Username ='" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "' ";
                SqlDataAdapter nba = new SqlDataAdapter(qwerty, conn);

                DataTable dtable1 = new DataTable();
                sda.Fill(dtable1);
                DataTable dtable2 = new DataTable();
                nba.Fill(dtable2);

                if (dtable1.Rows.Count > 0)
                {
                    Username = txtUsername.Text;
                    Password = txtPassword.Text;

                    Agent f2 = new Agent();
                    f2.Show();
                    this.Hide();

                }
                else if (dtable2.Rows.Count > 0)
                {
                    Username = txtUsername.Text;
                    Password = txtPassword.Text;

                    TeamLeader f3 = new TeamLeader();
                    f3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            txtUsername.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup f5 = new Signup();
            f5.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
