using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormProfileCE : Form
    {
        Profile profile;
        FormMode mode;

        public FormProfileCE(Profile profile = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();

            // Luu admin account ben FormList truyen sang
            this.profile = profile;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }

        private void FormProfileCE_Load(object sender, System.EventArgs e)
        {

            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua account len form
            if (mode == FormMode.EDIT)
            {
                txtUserID.Text = profile.UserID;
                txtPassword.Text = profile.Password;
                txtFirstName.Text = profile.FirstName;
                txtLastName.Text = profile.LastName;
                numAge.Value =  profile.Age;
                txtEmailAddress.Text = profile.EmailAddress;
                if (profile.Sex)
                {
                    rbtnMale.Checked = true;
                }
                else
                {
                    rbtnFemale.Checked = true;
                }
                txtPhoneNumber.Text = profile.PhoneNumber;
                txtAddress.Text = profile.Address;
                txtCreditCard.Text = profile.CreditCard;
                numSkyMiles.Value = profile.SkyMiles;
                if (profile.IsActive)
                {
                    // Neu tai khoan nay dang active thi check vao radio button Active
                    rbtnActive.Checked = true;
                }
                else
                {
                    rbtnInActive.Checked = true;
                }
            }
            else
            {
                // Neu dang o che do them moi
                // Tao moi mot account
                profile = new Profile();
                // Gan gia tri mac dinh cho ID (ID no se tu tang nen minh khong can phai tao)
                profile.ID = 0;
                // Nhung gia tri khac se duoc gan vao account khi nguoi dung bam nut Submit
            }
        }

        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            profile.UserID = txtUserID.Text;
            profile.Password = txtPassword.Text;
            profile.FirstName = txtFirstName.Text;
            profile.LastName = txtLastName.Text;
            profile.Address = txtAddress.Text;
            profile.PhoneNumber = txtPhoneNumber.Text;
            profile.EmailAddress = txtEmailAddress.Text;
            profile.Sex = rbtnMale.Checked;
            profile.Age = Convert.ToInt32(numAge);
            profile.CreditCard = txtCreditCard.Text;
            profile.SkyMiles = Convert.ToInt32(numSkyMiles);
            profile.IsActive = rbtnActive.Checked;

            // Neu dang o che do tao account moi thi phai lay gia tri trong o password gan vao account.
            // Neu dang o che do chinh sua ma gia tri trong o password khac voi gia tri password cua account
            // nghia la nguoi dung da thay doi password, phai cap nhat luon password
            if (mode == FormMode.CREATE || txtPassword.Text != profile.Password)
            {
                profile.Password = ARSUtilities.Md5Hash(txtPassword.Text);
            }

            // Tao mot API
            ProfileWrapper profileWrapper = new ProfileWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await profileWrapper.Post(profile);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await profileWrapper.Put(Convert.ToInt32(profile.ID), profile);
            }

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu thanh cong
                MessageBox.Show("Operation completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tat form CE
                this.Close();
            }
            else
            {
                // Neu that bai, hien thong bao loi
                MessageBox.Show("An error has occurred:\n" + profileWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
