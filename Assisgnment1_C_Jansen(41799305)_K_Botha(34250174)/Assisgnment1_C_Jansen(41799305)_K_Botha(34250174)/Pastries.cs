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
    public partial class Pastries : Form
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter;
        DataSet ds;

        public string PastryName { get; set; }
        public string PastryType { get; set; }
        public int PastryAmount { get; set; }
        public string PastryID { get; set; }

        public string[] PastryArray = new string[100];
        public int PastryCounter = 0;

        public decimal PastryPrice;
        public decimal PastryTypePrice;
        public decimal PastryFinalPrice;

        public Pastries()
        {
            InitializeComponent();
        }

        public void PASTRYNAME_DISPLAY(string sql) //Method to display TeaNames in combobox
        {
            try
            {
                conn.Open();

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, conn);
                ds = new DataSet();

                adapter.SelectCommand = command;
                adapter.Fill(ds, "Pastry");

                cbxPastryItems.DisplayMember = "PastryName";
                cbxPastryItems.ValueMember = "PastryName";
                cbxPastryItems.DataSource = ds.Tables["Pastry"];

                conn.Close();
            }
            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void ORDER_ADDED()
        {

            cbxPastryItems.SelectedIndex = -1;
            rdoPlain.Checked = false;
            rdoChocolate.Checked = false;
            nudPastry.Value = 0;

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
            catch(SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        public void FIND_PASTRYID(string sql)
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

        private void Pastries_Load(object sender, EventArgs e)
        {
            PASTRYNAME_DISPLAY("SELECT * FROM Pastry");
            cbxPastryItems.SelectedIndex = -1;
            lblNoSelected.Text = "";
        }

        private void btnTeaBack_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage frmHomePage = new HomePage();
            frmHomePage.Show();
            frmHomePage.SHOW_CONTROLS();
        }

        private void btnOrderPastry_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoPlain.Checked)
                {
                    PastryType = "Plain";
                    PastryTypePrice = PastryPrice;
                }
                else if (rdoChocolate.Checked)
                {
                    PastryType = "Chocolate";
                    PastryTypePrice = PastryPrice + 15;
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (nudPastry.Value >= 1)
                {
                    PastryAmount = Convert.ToInt32(nudPastry.Value);
                    PastryFinalPrice = (PastryPrice + PastryTypePrice * Convert.ToDecimal(PastryAmount));
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (cbxPastryItems.SelectedIndex != -1)
                {
                    PastryName = cbxPastryItems.Text;

                    FIND_PASTRYID($"SELECT PastryID FROM Pastry WHERE PastryName = '{PastryName}'");
                }
                else
                {
                    lblNoSelected.Show();
                }

                try
                {
                    ADD_ORDER_TO_TABLE($"INSERT INTO Orders (OrderID, OrderName, OrderPrice) VALUES ('{PastryID}','{PastryName}','{PastryPrice}')");
                }
                catch (SqlException Error)
                {
                    MessageBox.Show(Error.Message);
                }

                Checkout frmCheckout = new Checkout();
                PastryArray[PastryCounter] = PastryName + "  " + PastryAmount.ToString();
                PastryCounter++;

                ORDER_ADDED();
            }
            catch(SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void cbxPastryItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOrderAdded.Hide();
        }
    }
}
