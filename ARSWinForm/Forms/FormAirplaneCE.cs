using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace ARSWinForm
{
    public partial class FormAirplaneCE : Form
    {
        Airplane airplane;
        FormMode mode;

        public FormAirplaneCE(Airplane airplane = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();

            // Luu admin account ben FormList truyen sang
            this.airplane = airplane;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }
        
        private async void FormAirplaneCE_Load(object sender, EventArgs e)
        {
            // Goi API lay danh sach cac Loai may bay ve
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();

            // Dua danh sach loai may bay len Combobox
            cboType.DataSource = lstAirplaneType;
            cboType.DisplayMember = "Name";

            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua may bay len form
            if (mode == FormMode.EDIT)
            {
                // Dua airplane code len
                txtAirplaneCode.Text = airplane.AirplaneCode;

                // Chon loai may bay (AirplaneType) tuong ung voi may bay nay
                cboType.SelectedItem = lstAirplaneType.Where(at => at.ID == airplane.TypeID).Single();

                if (airplane.IsActive)
                {
                    // Neu may bay nay dang active thi check vao radio button Active
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
                // Tao moi mot may bay
                airplane = new Airplane();

                // Nhung gia tri khac se duoc gan vao may bay khi nguoi dung bam nut Submit
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            airplane.AirplaneCode = txtAirplaneCode.Text;
            airplane.TypeID = ((AirplaneType)cboType.SelectedItem).ID;
            airplane.IsActive = rbtnActive.Checked;

            // Tao mot API
            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await airplaneWrapper.Post(airplane);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await airplaneWrapper.Put(airplane.AirplaneCode, airplane);
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
                MessageBox.Show("An error has occurred:\n" + airplaneWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
