using ARSWinForm.HelperClass;
using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormRouteCE : Form
    {
        Route route;
        FormMode mode;
        public FormRouteCE(Route route = null, FormMode mode = FormMode.CREATE)
        {
            InitializeComponent();
            // Luu admin account ben FormList truyen sang
            this.route = route;

            // Luu che do (tao moi hay chinh sua)
            this.mode = mode;
        }

        private async void FormRouteCE_Load(object sender, System.EventArgs e)
        {
            // Goi API lay danh sach cac Loai may bay ve
            CityWrapper cityWrapper = new CityWrapper();
            List<City> lstCityA = await cityWrapper.List();
            List<City> lstCityB = new List<City>(lstCityA);

            // Dua danh sach loai may bay len Combobox
            cboFromCity.DataSource = lstCityA;
            cboFromCity.DisplayMember = "Name";

            cboToCity.DataSource = lstCityB;
            cboToCity.DisplayMember = "Name";
            // Neu la che do chinh sua (Edit) thi hien thi thong tin cua may bay len form
            if (mode == FormMode.EDIT)
            {
                

                // Chon thanh pho tuong ung
                cboFromCity.SelectedItem = lstCityA.Where(at => at.ID == route.CityAID).Single();
                cboToCity.SelectedItem = lstCityB.Where(at => at.ID == route.CityBID).Single();

                if (route.IsActive)
                {
                    // Neu may bay nay dang active thi check vao radio button Active
                    rbtnActive.Checked = true;
                }
                else
                {
                    rbtnInActive.Checked = true;
                }

                numSkyMiles.Value = route.SkyMiles;
                numBasePrice.Value = Convert.ToDecimal(route.BasePrice);
                
            }
            else
            {
                // Neu dang o che do them moi
                // Tao moi mot may bay
                route = new Route();

                // Nhung gia tri khac se duoc gan vao may bay khi nguoi dung bam nut Submit
            }

        }

        private async void btnSubmit_Click(object sender, System.EventArgs e)
        {
            // Lay gia tri tren form gan vao account
            route.CityAID = (((City)cboFromCity.SelectedItem).ID);
            route.CityBID = (((City)cboToCity.SelectedItem).ID);
            route.SkyMiles = Convert.ToInt32(numSkyMiles.Value);
            route.BasePrice = Convert.ToDouble(numBasePrice.Value);
            route.IsActive = rbtnActive.Checked;

            // Tao mot API
            RouteWrapper routeWrapper = new RouteWrapper();
            // Tao bien luu ket qua tra ve
            bool isSuccess;

            // Kiem tra xem dang o che do nao
            if (mode == FormMode.CREATE)
            {
                // Neu dang o che do them moi (CREATE)
                // POST account len server
                isSuccess = await routeWrapper.Post(route);
            }
            else
            {
                // Neu dang o che do chinh sua (EDIT)
                // PUT account len server
                isSuccess = await routeWrapper.Put(route.ID, route);
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
                MessageBox.Show("An error has occurred:\n" + routeWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
