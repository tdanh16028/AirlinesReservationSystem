using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAirplaneClassCE : Form
    {
        AirplaneClass airplaneClass;
        FormMode mode;
        public FormAirplaneClassCE(AirplaneClass airplaneClass = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();
            // Luu admin account ben FormList truyen sang
            this.airplaneClass = airplaneClass;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }

        private void FormAirplaneClassCE_Load(object sender, EventArgs e)
        {
            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua account len form
            if (mode == FormMode.EDIT)
            {
                txtClass.Text = airplaneClass.Class;
                txtPriceRate.Text = airplaneClass.PriceRate.ToString();
            }
            else
            {
                // Neu dang o che do them moi
                // Tao moi mot account
                airplaneClass = new AirplaneClass();
                // Gan gia tri mac dinh cho ID (ID no se tu tang nen minh khong can phai tao)
                airplaneClass.ID = 0;
                // Nhung gia tri khac se duoc gan vao account khi nguoi dung bam nut Submit
            }
        }
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            airplaneClass.Class = txtClass.Text;
            airplaneClass.PriceRate = Convert.ToDouble(txtPriceRate.Text);


            // Tao mot API
            AirplaneClassWrapper airplaneClassWrapper = new AirplaneClassWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await airplaneClassWrapper.Post(airplaneClass);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await airplaneClassWrapper.Put(airplaneClass.ID, airplaneClass);
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
                MessageBox.Show("An error has occurred:\n" + airplaneClassWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
