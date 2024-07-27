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

namespace Assisgnment1_C_Jansen_41799305__K_Botha_34250174_
{
    public partial class frmLogin : Form
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand comm;
        SqlDataAdapter adap;
        SqlDataReader reader;
        public frmLogin()
        {
            InitializeComponent();
        }

        public void ListPopulate(string sql)
        {

            ListBox lbxStaff = new ListBox();
            lbxStaff.Visible = false;
            lbxStaff.Items.Clear();

            comm = new SqlCommand(sql, conn);
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                string output = Convert.ToString(reader.GetValue(0) + "/t" + Convert.ToString(reader.GetValue(1)));
                lbxStaff.Items.Add(output);
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                try
                {
                    conn.Open();

                    SqlCommand comm = new SqlCommand("SELECT * FROM Staff WHERE Username = @username AND Password = @password", conn);
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = comm.ExecuteReader();

                    // Check if the SqlDataReader contains any rows
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Successfully logged in.", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmStaffDashboard staffDashboard = new frmStaffDashboard(); // create an instance of the child form
                        staffDashboard.ShowDialog(); // display the child form

                        label1.Visible = false;
                        label2.Visible = false;
                        txtPassword.Visible = false;
                        txtUsername.Visible = false;
                        lbxStaff.Visible = false;
                        btnLogin.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    
    }
}
