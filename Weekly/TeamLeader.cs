using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weekly
{
    public partial class TeamLeader : Form
    {
        public TeamLeader()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TLmessage f3 = new TLmessage();
            f3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TLViewsend f4 = new TLViewsend();
            f4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TLcreateAccount f5 = new TLcreateAccount();
            f5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TLManageAgent f6 = new TLManageAgent();
            f6.Show();
            this.Hide();
        }

        private void TeamLeader_Load(object sender, EventArgs e)
        {
            label2.Text = Login.username;
        }
    }
}
