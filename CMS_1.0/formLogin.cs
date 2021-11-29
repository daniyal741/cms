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

namespace CMS_1._0
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Static Values Must be Dynamic for each Computer
            string path = System.IO.Directory.GetCurrentDirectory();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM USERS where username = '"+username.Text.Trim()+"'and password = '"+password.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {

                formDashboard d = new formDashboard();
                this.Hide();
                d.Show();
            }
            else {

                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new formRegister();
            f.Show();
            this.Hide();
            this.Dispose();
        }
    }
}
