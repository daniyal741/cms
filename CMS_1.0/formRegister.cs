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
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();

        }

   
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please Fill the required fields to continue....");
            }
            else if(password.Text != confirmPassword.Text){


                MessageBox.Show("Check your Password again...");


            }
            else{

                string path = System.IO.Directory.GetCurrentDirectory();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+path+@"\DB\db_cms.mdf;Integrated Security=True;Connect Timeout=30");
                try
                {
                    con.Open();
                    string query = "INSERT INTO USERS VALUES(@username, @password)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Registerd...");


                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.ToString());

                }
                finally
                {

                    con.Close();

                    username.Text = "";
                    password.Text = "";
                    confirmPassword.Text = "";
                }

            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new formLogin();           
            this.Hide();
            f.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
