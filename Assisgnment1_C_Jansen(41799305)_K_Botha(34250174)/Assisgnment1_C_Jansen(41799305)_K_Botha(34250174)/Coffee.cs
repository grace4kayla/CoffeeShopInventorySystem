using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //To use sql queries

namespace Assisgnment1_C_Jansen_41799305__K_Botha_34250174_
{
    public partial class Coffee : Form
    {

        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter;
        SqlDataAdapter reader;
        DataSet ds; //make sql variables

        public string CoffeeName { get; set; }
        public string CoffeeSize { get; set; }
        public int CoffeeAmount { get; set; } //Get variables to read into database using sql statement insert like %name, %price etc
        public string CoffeeID { get; set; }

        public string[] CoffeeArray = new string[100];
        public int CoffeeCounter = 0;

        public decimal CoffeePrice;
        public decimal CoffeeSizePrice;
        public decimal CoffeeFinalPrice; //calculate new price bsed on size and amount

        public Coffee()
        {
            InitializeComponent();
        }

        public void COFFEENAME_DISPLAY(string sql) //Method to display CoffeeNames in combobox
        {
            try
            {
                conn.Open();

                adapter = new SqlDataAdapter();
                command = new SqlCommand(sql, conn);
                ds = new DataSet();

                adapter.SelectCommand = command;
                adapter.Fill(ds, "Coffee");

                cbxCoffeeItems.DisplayMember = "CoffeeName";
                cbxCoffeeItems.ValueMember = "CoffeeName";
                cbxCoffeeItems.DataSource = ds.Tables["Coffee"];

                conn.Close();
            }
            catch (SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        public void ORDER_ADDED()
        {
            cbxCoffeeItems.SelectedIndex = -1; //reset all controls, erase user input
            rdoSmall.Checked = false;
            rdoMed.Checked = false;
            rdoLarge.Checked = false;
            nudCoffee.Value = 0;

            lblOrderAdded.Show(); //show order has been added
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

        public void FIND_COFFEEID(string sql)
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

        private void Coffee_Load(object sender, EventArgs e)
        {
            COFFEENAME_DISPLAY("SELECT * FROM Coffee"); //display names in listbox
            cbxCoffeeItems.SelectedIndex = -1; //deselct items in combobox
            lblNoSelected.Text = "";
        }

        private void btnCoffeeBack_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage frmHomePage = new HomePage();
            frmHomePage.Show();
            frmHomePage.SHOW_CONTROLS(); //brings user back to main page
        }

        private void btnOrderCoffee_Click(object sender, EventArgs e)
        {
            try
            {

                if (rdoSmall.Checked)
                {
                    CoffeeSize = "Small";
                    CoffeeSizePrice = CoffeePrice;
                }
                else if (rdoMed.Checked)
                {
                    CoffeeSize = "Medium";
                    CoffeeSizePrice = CoffeePrice + 10;
                }
                else if (rdoLarge.Checked)
                {
                    CoffeeSize = "Large";
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (nudCoffee.Value >= 1)
                {
                    CoffeeAmount = Convert.ToInt32(nudCoffee.Value);
                    CoffeeFinalPrice = (CoffeePrice + CoffeeSizePrice * Convert.ToDecimal(CoffeeAmount));
                }
                else
                {
                    lblNoSelected.Show();
                }

                if (cbxCoffeeItems.SelectedIndex != -1)
                {
                    CoffeeName = cbxCoffeeItems.Text;

                    //CoffeePrice = $"SELECT CoffeePrice FROM Coffee WHERE CoffeeName = '{CoffeePrice}'";

                    FIND_COFFEEID($"SELECT CoffeeID FROM Coffee WHERE CoffeeName = '{CoffeeName}'");

                }
                else
                {
                    lblNoSelected.Show();
                }

                try
                {
                    ADD_ORDER_TO_TABLE($"INSERT INTO Orders (OrderID, OrderName) VALUES ('{CoffeeID}','{CoffeeName}')");

                }
                catch (SqlException Error)
                {
                    MessageBox.Show(Error.Message);
                }

                CoffeeArray[CoffeeCounter] = CoffeeName + "  " + CoffeeAmount.ToString();
                CoffeeCounter++;

                ORDER_ADDED();

            }
            catch(SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void cbxCoffeeItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOrderAdded.Hide(); //hide order added label when user start new order
        }
    }
}
