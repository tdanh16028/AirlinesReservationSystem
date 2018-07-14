using ARSWinForm.HelperClass;
using ARSWinForm.Model;
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

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {

        }
    }
}
