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

    public partial class Checkout : Form
    {

        
      
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter;

        public string CustomerOrder;

        private SqlDataReader reader;

        private Teas TeaInstance;

        public Checkout(Teas tea)
        {
            InitializeComponent();
            TeaInstance = tea;
        }
        public Checkout()
        {
            
            InitializeComponent();
            

        }

        public void PopulateListBoxFromArray(string[] arr)
        {
            foreach (string item in arr)
            {
                lstCheckout.Items.Add(item);
            }
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            HomePage frmHomePage = new HomePage();

            Teas frmTea = new Teas();

            for (int i = 0; i < frmTea.TeaCounter; i++)
            {
                lstCheckout.Items.Add(frmTea.TeaArray[i]);
            }

            Pastries frmPastries = new Pastries();
            
            for (int i = 0; i < frmPastries.PastryCounter; i++)
            {
                lstCheckout.Items.Add(frmPastries.PastryArray[i]);
            }

            Sandwiches frmSandwiches = new Sandwiches();

            for (int i = 0; i < frmSandwiches.SandwichCounter; i++)
            {
                lstCheckout.Items.Add(frmSandwiches.SandwichArray[i]);
            } 

        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string OrderName = lstCheckout.SelectedItem.ToString();

                SqlCommand command = new SqlCommand($"DELETE FROM Orders WHERE OrderName = '{OrderName}'", conn);
                command.ExecuteNonQuery();

                conn.Close();

            }
            catch(SqlException Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teas frmTea = new Teas();

            for (int i = 0; i < frmTea.TeaCounter; i++)
            {
                lstCheckout.Items.Add(frmTea.TeaArray[i]);
                MessageBox.Show(frmTea.TeaArray[i]);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }
    }
}
