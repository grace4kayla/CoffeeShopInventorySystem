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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void HIDE_CONTROLS()
        {
            lblWelcome.Hide();
            lblMenu.Hide();
            btnCoffee.Hide();
            btnTea.Hide();
            btnPastries.Hide();
            btnSandwiches.Hide();
            btnStaffLogin.Hide();
        }

        public void SHOW_CONTROLS()
        {
            lblWelcome.Show();
            lblMenu.Show();
            btnCoffee.Show();
            btnTea.Show();
            btnPastries.Show();
            btnSandwiches.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            SHOW_CONTROLS();
        }

        private void btnCoffee_Click(object sender, EventArgs e)
        {
            Coffee frmCoffee = new Coffee();
            frmCoffee.MdiParent = this;
            frmCoffee.Show();
            HIDE_CONTROLS();
        } 

        private void btnTea_Click(object sender, EventArgs e)
        {
            Teas frmTea = new Teas();
            frmTea.MdiParent = this;
            frmTea.Show();
            HIDE_CONTROLS();
        }

        private void btnPastries_Click(object sender, EventArgs e)
        {
            Pastries frmPastries = new Pastries();
            frmPastries.MdiParent = this;
            frmPastries.Show();
            HIDE_CONTROLS();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Checkout frmCheckout = new Checkout();
            frmCheckout.MdiParent = this;
            frmCheckout.Show();
            HIDE_CONTROLS();
        }

        private void btnSandwiches_Click(object sender, EventArgs e)
        {
            Sandwiches frmSandwiches = new Sandwiches();
            frmSandwiches.MdiParent = this;
            frmSandwiches.Show();
            HIDE_CONTROLS();
        }


        private void btnCheckout_Click_1(object sender, EventArgs e)
        {
            Checkout frmCheckout = new Checkout();
            frmCheckout.MdiParent = this;
            frmCheckout.Show();
        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            frmLogin staffLogin = new frmLogin(); // create an instance of the child form
            staffLogin.MdiParent = this; // set the MDI parent of the child form
            staffLogin.Show(); // display the child form
        }
    }
}
