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
    public partial class updateRecord : Form
    {
        public updateRecord()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void c_id_TextChanged(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30"); con.Open();
            if (c_id.Text != "") {

                string query = "SELECT * FROM CUSTOMER where customer_num = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", int.Parse(c_id.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c_name.Text = dr.GetValue(1).ToString();
                    c_street.Text = dr.GetValue(2).ToString();
                    c_city.Text = dr.GetValue(3).ToString();
                    c_state.Text = dr.GetValue(4).ToString();
                    c_postal.Text = dr.GetValue(5).ToString();
                    c_balance.Text = dr.GetValue(6).ToString();
                    c_credit.Text = dr.GetValue(7).ToString();
                    c_rep.Text = dr.GetValue(8).ToString();
                }
            }
           

            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {

                con.Open();
                string query = "UPDATE CUSTOMER SET customer_name=@name, street= @street, city= @city, state= @state, postal_code= @postal, balance= @balance, credit_limit= @credit, rep_num= @rep WHERE customer_num= @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", int.Parse(c_id.Text));
                cmd.Parameters.AddWithValue("@name", c_name.Text);
                cmd.Parameters.AddWithValue("@street", c_street.Text);
                cmd.Parameters.AddWithValue("@city", c_city.Text);
                cmd.Parameters.AddWithValue("@state", c_state.Text);
                cmd.Parameters.AddWithValue("@postal", c_postal.Text);
                cmd.Parameters.AddWithValue("@balance", double.Parse(c_balance.Text));
                cmd.Parameters.AddWithValue("@credit", double.Parse(c_credit.Text));
                cmd.Parameters.AddWithValue("@rep", c_rep.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Records Inserted Successfully.");

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
    }
}
