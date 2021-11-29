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
    public partial class formDashboard : Form
    {
        private string tableName = "Customer";

        public formDashboard()
        {
            InitializeComponent();
        }
        

        private void btnList_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30"); string query = "SELECT * FROM "+ tableName;
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                panel1.Visible = true;
                dataGridView1.DataSource = dtbl;
                dataGridView1.Visible = true;
                labelTable.Text = tableName + "Table";
            }
            else
            {

                MessageBox.Show("No Records to Show");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertRecord p = new insertRecord();
            p.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void table_SelectedValueChanged(object sender, EventArgs e)
        {
            tableName = table.GetItemText(table.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteRecord p = new deleteRecord();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateRecord p = new updateRecord();
            p.Show();
        }
    }
}
