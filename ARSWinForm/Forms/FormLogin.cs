using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSWinForm.Forms
{
    public partial class FormLogin : Form
    {
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            AdminAccountWrapper adminAccountWrapper = new AdminAccountWrapper();
            List<AdminAccount> lstAdminAccount = await adminAccountWrapper.List();
            
            if()
            {
                MessageBox.Show("Login not successfull","Failed", MessageBoxButtons.OK , MessageBoxIcon.Error);

            }
            else
            {
                FormMain f = new FormMain();
                f.Show();
            }
          
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
