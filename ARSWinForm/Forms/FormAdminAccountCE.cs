using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
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
            } else
            {
                // Neu dang o che do them moi
                // Tao moi mot account
                adminAccount = new AdminAccount();
                // Gan gia tri mac dinh cho ID (ID no se tu tang nen minh khong can phai tao)
                adminAccount.ID = 0;
                // Nhung gia tri khac se duoc gan vao account khi nguoi dung bam nut Submit
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            adminAccount.Username = txtUsername.Text;
            adminAccount.Password = txtPassword.Text;
            adminAccount.Name = txtName.Text;
            adminAccount.Role = txtRole.Text;
            adminAccount.IsActive = rbtnActive.Checked;

            // Tao mot API
            AdminAccountWrapper adminAccountWrapper = new AdminAccountWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await adminAccountWrapper.Post(adminAccount);
            } else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await adminAccountWrapper.Put(adminAccount.ID, adminAccount);
            }

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu thanh cong
                MessageBox.Show("Operation completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tat form CE
                this.Close();
            }
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
