using ARSWinForm.HelperClass;
using ARSWinForm.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAdminAccountCE : Form
    {
        AdminAccount adminAccount;
        FormMode mode;

        public FormAdminAccountCE(AdminAccount adminAccount = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();

            // Luu admin account ben FormList truyen sang
            this.adminAccount = adminAccount;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }
        
        private void FormAdminAccountCE_Load(object sender, EventArgs e)
        {
            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua account len form
            if (mode == FormMode.EDIT)
            {
                txtUsername.Text = adminAccount.Username;
                txtPassword.Text = adminAccount.Password;
                txtName.Text = adminAccount.Name;
                txtRole.Text = adminAccount.Role;
                
                if (adminAccount.IsActive)
                {
                    // Neu tai khoan nay dang active thi check vao radio button Active
                    rbtnActive.Checked = true;
                } else
                {
                    rbtnInActive.Checked = true;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtRole.Text = "";
            rbtnActive.Checked = true;
        }

    }
}
