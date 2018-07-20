using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace ARSWinForm
{
    public partial class FormAirplaneTypeCE : Form
    {
        AirplaneType airplaneType;
        FormMode mode;

        public FormAirplaneTypeCE(AirplaneType airplaneType = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();

            // Luu flightSchedule account ben FormList truyen sang
            this.airplaneType = airplaneType;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }

        private void AirplaneTypeCE_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.EDIT)
            {
                txtName.Text = airplaneType.Name;
                numFirstClassSeat.Value = airplaneType.AirplaneInfoes.FirstOrDefault(ai => ai.ClassID == 1).SeatCount;
                numBusinessClassSeat.Value = airplaneType.AirplaneInfoes.FirstOrDefault(ai => ai.ClassID == 2).SeatCount;
                numClubClassSeat.Value = airplaneType.AirplaneInfoes.FirstOrDefault(ai => ai.ClassID == 3).SeatCount;

                if (airplaneType.IsActive)
                {
                    rbtnActive.Checked = true;
                }
                else
                {
                    rbtnInActive.Checked = true;
                }
            } else
            {
                airplaneType = new AirplaneType();
            }
            
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            AirplaneInfoWrapper airplaneInfoWrapper = new AirplaneInfoWrapper();

            airplaneType.Name = txtName.Text;
            airplaneType.IsActive = rbtnActive.Checked;
            airplaneType.AirplaneInfoes.FirstOrDefault(ai => ai.ClassID == 1).SeatCount = Convert.ToInt32(numFirstClassSeat.Value);
            airplaneType.AirplaneInfoes.FirstOrDefault(ai => ai.ClassID == 2).SeatCount = Convert.ToInt32(numBusinessClassSeat.Value);
            airplaneType.AirplaneInfoes.FirstOrDefault(ai => ai.ClassID == 3).SeatCount = Convert.ToInt32(numClubClassSeat.Value);

            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await airplaneTypeWrapper.Post(airplaneType);

                foreach (AirplaneInfo ai in airplaneType.AirplaneInfoes)
                {
                    if (isSuccess) isSuccess = await airplaneInfoWrapper.Post(ai);
                }
                
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await airplaneTypeWrapper.Put(airplaneType.ID, airplaneType);

                foreach (AirplaneInfo ai in airplaneType.AirplaneInfoes)
                {
                    if (isSuccess) isSuccess = await airplaneInfoWrapper.Put(ai.AirplaneTypeID, ai);
                }

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
                MessageBox.Show("An error has occurred:\n" + airplaneTypeWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
