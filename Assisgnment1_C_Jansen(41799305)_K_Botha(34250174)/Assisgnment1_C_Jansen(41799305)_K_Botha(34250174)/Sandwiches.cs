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
    public partial class Sandwiches : Form
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet ds;

        public string SandwichName { get; set; }
        public string SandwichType { get; set; }
        public int SandwichAmount { get; set; }
        public string SandwichID { get; set; }

        public string[] SandwichArray = new string[100];
        public int SandwichCounter = 0;

        public decimal SandwichPrice;
        public decimal SandwichTypePrice;
        public decimal SandwichFinalPrice;

        public Sandwiches()
        {
            InitializeComponent();
        }

        public void SANDWICHNAME_DISPLAY(string sql) //Method to display TeaNames in combobox
        {
            try
            {
                conn.Open();

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, conn);
                ds = new DataSet();

                adapter.SelectCommand = command;
                adapter.Fill(ds, "Sandwich");

                cbxSandwichItems.DisplayMember = "SandwichName";
                cbxSandwichItems.ValueMember = "SandwichName";
                cbxSandwichItems.DataSource = ds.Tables["Sandwich"];

                conn.Close();
            }
            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        public void ORDER_ADDED()
        {
            cbxSandwichItems.SelectedIndex = -1;
            rdoWhite.Checked = false;
            rdoRye.Checked = false;
            nudSandwich.Value = 0;

            lblOrderAdded.Show();
        }

        public void ADD_ORDER_TO_TABLE(string sql)
        {
            try
            {
                conn.Open();

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, conn);

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();

                conn.Close();
            }
            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }
        public void FIND_SANDWICHID(string sql)
        {
            try
            {
                conn.Open();

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, conn);

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();

                conn.Close();
            }
            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void Sandwiches_Load(object sender, EventArgs e)
        {
            SANDWICHNAME_DISPLAY("SELECT * FROM Sandwich");
            cbxSandwichItems.SelectedIndex = -1;
            lblNoSelected.Text = "";
        }

        private void btnTeaBack_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage frmHomePage = new HomePage();
            frmHomePage.Show();
            frmHomePage.SHOW_CONTROLS();
        }

        private void btnOrderSandwiches_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoWhite.Checked)
                {
                    SandwichType = "White";
                    SandwichTypePrice = SandwichPrice;
                }
                else if (rdoRye.Checked)
                {
                    SandwichType = "Rye";
                    SandwichTypePrice = SandwichPrice + 15;
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (SandwichAmount >= 1)
                {
                    SandwichAmount = Convert.ToInt32(nudSandwich.Value);
                    SandwichFinalPrice = (SandwichPrice + SandwichTypePrice * Convert.ToDecimal(SandwichAmount));
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (cbxSandwichItems.SelectedIndex != -1)
                {
                    SandwichName = cbxSandwichItems.Text;

                    FIND_SANDWICHID($"SELECT SandwichID FROM Sandwiches WHERE SandwichName = '{SandwichName}'");
                }
                else
                {
                    lblNoSelected.Show();
                }

                try
                {
                    ADD_ORDER_TO_TABLE($"INSERT INTO Orders (OrderID, OrderName, OrderPrice) VALUES ('{SandwichID}','{SandwichName}','{SandwichPrice}')");
                }
                catch (SqlException Error)
                {
                    MessageBox.Show(Error.Message);
                }

                Checkout frmCheckout = new Checkout();
                SandwichArray[SandwichCounter] = SandwichName + "  " + SandwichAmount.ToString();
                SandwichCounter++;

                ORDER_ADDED();

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void cbxSandwichItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOrderAdded.Hide();
        }
    }
}
