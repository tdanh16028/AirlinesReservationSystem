using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormCityCE : Form
    {
        City city;
        FormMode mode;
        public FormCityCE(City city = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();
            // Luu admin account ben FormList truyen sang
            this.city = city;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }

        private void FormCityCE_Load(object sender, EventArgs e)
        {
            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua account len form
            if (mode == FormMode.EDIT)
            {
                txtCode.Text = city.Code;
                txtName.Text = city.Name;
            }
            else
            {
                // Neu dang o che do them moi
                // Tao moi mot account
                city = new City();
                // Gan gia tri mac dinh cho ID (ID no se tu tang nen minh khong can phai tao)
                city.ID = 0;
                // Nhung gia tri khac se duoc gan vao account khi nguoi dung bam nut Submit
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            city.Code = txtCode.Text;
            city.Name = txtName.Text;

            // Tao mot API
            CityWrapper cityWrapper = new CityWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await cityWrapper.Post(city);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT city len server
                isSuccess = await cityWrapper.Put(city.ID, city);
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
                MessageBox.Show("An error has occurred:\n" + cityWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
