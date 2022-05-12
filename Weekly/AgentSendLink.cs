using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Weekly
{
    public partial class AgentSendLink : Form
    {

        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;";
        public AgentSendLink()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           

            string to, from, pass, mail;
            to = (txtCemail.Text).ToString();
            from = (txtAemail.Text).ToString();
            mail = (txtMail.Text).ToString();
            pass = (txtPassword.Text).ToString();
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "Testing Mail";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Link Send successfully", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SendEmal", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ClientEmail", txtCemail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@AgentEmail", txtAemail.Text.Trim());
                  
                    sqlCmd.ExecuteNonQuery();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Agent f6 = new Agent();
            f6.Show();
            this.Hide();
        }

        private void AgentSendLink_Load(object sender, EventArgs e)
        {

        }
        
    }

}
