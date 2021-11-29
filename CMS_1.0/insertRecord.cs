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
    public partial class insertRecord : Form
    {
        public insertRecord()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {

                con.Open();
                string query = "INSERT INTO CUSTOMER VALUES('" + int.Parse(c_id.Text) + "', '" + c_name.Text + "', '" + c_street.Text + "' , '" + c_city.Text + "', '" + c_state.Text + "' , '" + c_postal.Text + "', '" + double.Parse(c_balance.Text) + "' , '" + double.Parse(c_credit.Text) + "', '" + int.Parse(c_rep.Text) + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Records Inserted Successfully.");

            }

            catch (Exception ex)
            {

                MessageBox.Show("Change Customer ID or Invalid Input Type.");

            }
            finally {

                con.Close();
            }





            

        }
    }
}
