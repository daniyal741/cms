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
    public partial class deleteRecord : Form
    {
        public deleteRecord()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {

                con.Open();
                string query = "Delete CUSTOMER where customer_num=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id" , int.Parse(c_id.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Deleted Successfully.");

            }

            catch (Exception ex)
            {

                MessageBox.Show("Change Customer ID or Invalid Input Type.");

            }
            finally
            {

                con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
