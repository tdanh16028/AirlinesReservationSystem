using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormRouteList : Form
    {
        public FormRouteList()
        {
            InitializeComponent();
        }

        private void FormRoute_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormRouteCE f = new FormRouteCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            Route route = GetSelectedRoute();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (route == null)
            {
                MessageBox.Show("You must choose an aiplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co Route dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormRouteCE f = new FormRouteCE(route, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();

        }

 
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Lay may bay dang duoc chon trong bang
            Route route = GetSelectedRoute();

            // Neu hien tai khong co may bay nao duoc chon thi hien thong bao
            if (route == null)
            {
                MessageBox.Show("You must choose a route to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co may bay dang duoc chon thi sua cot IsActive lai thanh False
            route.IsActive = false;

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            RouteWrapper routeWrapper = new RouteWrapper();
            bool isSuccess = await routeWrapper.Put(route.ID, route);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Airplane status was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lai bang
                LoadDataGridView();

            }
            else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!\n" + routeWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        public async void LoadDataGridView()
        {
            // Luu lai dong hien tai dang chon
            int currentRowIndex;

            // Neu hien tai khong co dong nao duoc chon thi mac dinh la dong so 0
            if (dgvRoute.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvRoute.Rows.IndexOf(dgvRoute.SelectedRows[0]);
            }

            // Luu lai dong hien tai dang o dau` bang? trong dataGridView
            int firstRowIndex = dgvRoute.FirstDisplayedScrollingRowIndex;
            if (firstRowIndex == -1) firstRowIndex = 0;

            // Goi API lay du lieu ve
            RouteWrapper routeWrapper = new RouteWrapper();
            List<Route> lstRoute = await routeWrapper.List();

            // Khai bao API de lay du lieu cua Loai may bay (AirplaneType)
            // va Thong tin ve` so luong cua tung loai ghe (AirplaneInfo)
            CityWrapper cityWrapper = new CityWrapper();

            // Goi API lay du lieu ve
            List<City> lstCity = await cityWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID"); // Ma may bay
            table.Columns.Add("CityAID"); // ID cua thanh pho A
            table.Columns.Add("CityBID"); // ID cua thanh pho B
            table.Columns.Add("CityAName"); // Thanh pho A
            table.Columns.Add("CityBName"); // Thanh pho B
            table.Columns.Add("SkyMiles"); // Khoang cach giua hai noi
            table.Columns.Add("BasePrice"); // Gia ban dau 
            table.Columns.Add("IsActive");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstRoute != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (Route route in lstRoute)
                {
                    // Goi API de lay du lieu cua thanh pho (ten thanh pho)
                    City cityA = lstCity.Where(at => at.ID == route.CityAID).Single();
                    City cityB = lstCity.Where(at => at.ID == route.CityBID).Single();

                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = route.ID;
                    row["CityAID"] = route.CityAID;
                    row["CityBID"] = route.CityBID;
                    row["SkyMiles"] = route.SkyMiles;
                    row["BasePrice"] = route.BasePrice;
                    row["CityAName"] = lstCity.Where(at => at.ID == route.CityAID).Single().Name;
                    row["CityBName"] = lstCity.Where(at => at.ID == route.CityBID).Single().Name;
                    row["IsActive"] = route.IsActive;


                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvRoute.DataSource = table;

                // An cot CityAID va CityBID, khong hien cot nay
                dgvRoute.Columns["CityAID"].Visible = false;
                dgvRoute.Columns["CityBID"].Visible = false;

                // Chon lai dong ban dau duoc chon truoc khi reload
                dgvRoute.Rows[currentRowIndex].Selected = true;

                // Cuon. toi' dong` duoc. chon.
                dgvRoute.FirstDisplayedScrollingRowIndex = firstRowIndex;
            }
        }
        private Route GetSelectedRoute()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvRoute.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvRoute.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot Airplane moi
            Route route = new Route()
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                CityAID = Convert.ToInt32(row.Cells["CityAID"].Value),
                CityBID = Convert.ToInt32(row.Cells["CityBID"].Value),
                SkyMiles = Convert.ToInt32(row.Cells["SkyMiles"].Value),
                BasePrice = Convert.ToDouble(row.Cells["BasePrice"].Value),
                IsActive = Convert.ToBoolean(row.Cells["IsActive"].Value)
               
            };

            // Tra Airplane vua tao ve
            return route;
        }
    }
}
