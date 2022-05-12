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

    public partial class TLManageAgent : Form
    {
        SqlConnection con = new SqlConnection (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;");
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;";


        public TLManageAgent()
        {
            InitializeComponent();
        }

        private void TLManageAgent_Load(object sender, EventArgs e)
        {
            disp_data();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Signup1", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;
            }
        }

      
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Signup1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Signup1 where FirstName = '" + txtSearch.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Acount removed succesfully"); 
            
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("FirstName like '%" + txtSearch.Text + "%'");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TeamLeader f3 = new TeamLeader();
            f3.Show();
            this.Hide();
        }
    }
}
