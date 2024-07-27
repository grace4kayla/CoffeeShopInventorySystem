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
    public partial class Teas : Form
    {

        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet ds;

        public string TeaName { get; set; }
        public string TeaSize { get; set; }
        public int TeaAmount { get; set; }
        public string TeaID { get; set; }

        public int TeaCounter = 0;
        public string[] TeaArray = new string[100];


        public decimal TeaPrice;
        public decimal TeaSizePrice;
        public decimal TeaFinalPrice;


        public Teas()
        {
            InitializeComponent();
        }

        public void TEANAME_DISPLAY(string sql) //Method to display TeaNames in combobox
        {
            try
            {
                conn.Open();

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, conn);
                ds = new DataSet();

                adapter.SelectCommand = command;
                adapter.Fill(ds, "Tea");

                cbxTeaItems.DisplayMember = "TeaName";
                cbxTeaItems.ValueMember = "TeaName";
                cbxTeaItems.DataSource = ds.Tables["Tea"];

                conn.Close();
            }
            catch(SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        public void ORDER_ADDED()
        {

            cbxTeaItems.SelectedIndex = -1;
            rdoCup.Checked = false;
            rdoTeapot.Checked = false;
            nudTea.Value = 0;

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

        public void FIND_TEAID(string sql)
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

        private void Teas_Load(object sender, EventArgs e)
        {
            TEANAME_DISPLAY("SELECT * FROM Tea");
            cbxTeaItems.SelectedIndex = -1;
            lblNoSelected.Text = "";
        }

        private void btnTeaBack_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage frmHomePage = new HomePage();
            frmHomePage.Show();
            frmHomePage.SHOW_CONTROLS();
        }

        private void btnOrderTea_Click(object sender, EventArgs e)
        {
            try
            {

                if (rdoCup.Checked)
                {
                    TeaSize = "Small";
                    TeaSizePrice = TeaPrice;
                }
                else if (rdoTeapot.Checked)
                {
                    TeaSize = "Large";
                    TeaSizePrice = TeaPrice + 10;
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (nudTea.Value >= 1)
                {
                    TeaAmount = Convert.ToInt32(nudTea.Value);
                    TeaFinalPrice = (TeaPrice + TeaSizePrice * Convert.ToDecimal(TeaAmount));
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (cbxTeaItems.SelectedIndex != -1)
                {
                    TeaName = cbxTeaItems.Text;


                   FIND_TEAID($"SELECT TeaID FROM Tea WHERE TeaName = '{TeaName}'");
                }
                else
                {
                    lblNoSelected.Show();
                }

                try
                {
                    ADD_ORDER_TO_TABLE($"INSERT INTO Orders (OrderID, OrderName) VALUES ('{TeaID}','{TeaName}')");
                }
                catch (SqlException Error)
                {
                    MessageBox.Show(Error.Message);
                }

                Checkout frmCheckout = new Checkout();
                TeaArray[TeaCounter] = TeaName + "  " + TeaAmount.ToString();
                TeaCounter++;

                ORDER_ADDED();

            }
            catch(Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void cbxTeaItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOrderAdded.Hide();
        }

    }
}
