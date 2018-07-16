using ARSWinForm.HelperClass;
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
        bool isLoggedIn = false;
        List<AdminAccount> lstAdminAccount;
        FormMain fMain;

        public FormLogin(FormMain fMain)
        {
            InitializeComponent();
            this.fMain = fMain;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username and password must not be null","Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }

            if (lstAdminAccount == null)
            {
                AdminAccountWrapper adminAccountWrapper = new AdminAccountWrapper();
                lstAdminAccount = await adminAccountWrapper.List();
            }

            string username = txtUsername.Text;
            string password = ARSUtilities.Md5Hash(txtPassword.Text);

            AdminAccount adminAccount = lstAdminAccount.Where(aa => aa.Username == username && aa.Password.ToLower() == password.ToLower()).SingleOrDefault();
            if (adminAccount == null)
            {
                MessageBox.Show("Wrong username or password!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fMain.isLoggedIn = isLoggedIn = true;
            Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("You must login to use this software!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
