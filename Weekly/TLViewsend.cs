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
    
    public partial class TLViewsend : Form
    {
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fritz\source\repos\Weekly\Weekly\Database1.mdf;Integrated Security=True;";
        public TLViewsend()
        {
            InitializeComponent();
        }

        private void TLViewsend_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) 
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Emailsend", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("AgentEmail like '%" + txtSearch.Text + "%'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamLeader f3 = new TeamLeader();
            f3.Show();
            this.Hide();
        }
    }
}
