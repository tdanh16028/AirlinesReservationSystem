using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Linq;

namespace ARSWinForm
{
    public partial class FormAirplaneList : Form
    {
        public FormAirplaneList()
        {
            InitializeComponent();
        }

        private void Airplane_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormAirplaneCE f = new FormAirplaneCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            Airplane airplane = GetSelectedAirplane();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (airplane == null)
            {
                MessageBox.Show("You must choose an aiplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormAirplaneCE f = new FormAirplaneCE(airplane, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Lay may bay dang duoc chon trong bang
            Airplane airplane = GetSelectedAirplane();

            // Neu hien tai khong co may bay nao duoc chon thi hien thong bao
            if (airplane == null)
            {
                MessageBox.Show("You must choose an airplane to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co may bay dang duoc chon thi sua cot IsActive lai thanh False
            airplane.IsActive = false;

            // Gui len server de cap nhat lai cot IsActive trong CSDL
            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            bool isSuccess = await airplaneWrapper.Put(airplane.AirplaneCode, airplane);

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
                MessageBox.Show("An error has occurred!\n" + airplaneWrapper.GetErrorMessage(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvAirplane.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvAirplane.Rows.IndexOf(dgvAirplane.SelectedRows[0]);
            }

            // Luu lai dong hien tai dang o dau` bang? trong dataGridView
            int firstRowIndex = dgvAirplane.FirstDisplayedScrollingRowIndex;
            if (firstRowIndex == -1) firstRowIndex = 0;

            // Goi API lay du lieu ve
            AirplaneWrapper airplaneWrapper = new AirplaneWrapper();
            List<Airplane> lstAirplane = await airplaneWrapper.List();

            // Khai bao API de lay du lieu cua Loai may bay (AirplaneType)
            // va Thong tin ve` so luong cua tung loai ghe (AirplaneInfo)
            AirplaneTypeWrapper airplaneTypeWrapper = new AirplaneTypeWrapper();
            AirplaneInfoWrapper airplaneInfoWrapper = new AirplaneInfoWrapper();

            // Goi API lay du lieu ve
            List<AirplaneType> lstAirplaneType = await airplaneTypeWrapper.List();
            List<AirplaneInfo> lstAirplaneInfo = await airplaneInfoWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("AirplaneCode"); // Ma may bay
            table.Columns.Add("AirplaneTypeID"); // ID cua loai may bay
            table.Columns.Add("AirplaneTypeName"); // Ten cua loai may bay
            table.Columns.Add("FirstClassCount"); // So luong ghe hang nhat
            table.Columns.Add("BusinessClassCount"); // So luong ghe hang Thuong gia
            table.Columns.Add("ClubClassCount"); // So luong ghe thuong
            table.Columns.Add("IsActive"); // Trang thai cua may bay (con hoat dong khong)

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstAirplane != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (Airplane airplane in lstAirplane)
                {
                    // Goi API de lay du lieu cua Loai may bay (AirplaneType)
                    AirplaneType airplaneType = lstAirplaneType.Where(at => at.ID == airplane.TypeID).Single();

                    // Goi API de lay So luong cua moi Loai ghe tren may bay nay
                    List<AirplaneInfo> airplaneInfo = lstAirplaneInfo.Where(ai => ai.AirplaneTypeID == airplaneType.ID).ToList();

                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["AirplaneCode"] = airplane.AirplaneCode;
                    row["AirplaneTypeID"] = airplane.TypeID;
                    row["AirplaneTypeName"] = airplaneType.Name;
                    row["FirstClassCount"] = airplaneInfo.Where(ai => ai.ClassID == 1).Single().SeatCount;
                    row["BusinessClassCount"] = airplaneInfo.Where(ai => ai.ClassID == 2).Single().SeatCount;
                    row["ClubClassCount"] = airplaneInfo.Where(ai => ai.ClassID == 3).Single().SeatCount;
                    row["IsActive"] = airplane.IsActive;

                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvAirplane.DataSource = table;

                // An? cot AirplaneTypeID di, khong hien cot nay
                dgvAirplane.Columns["AirplaneTypeID"].Visible = false;

                // Chon lai dong ban dau duoc chon truoc khi reload
                if (dgvAirplane.Rows.Count > 0) dgvAirplane.Rows[currentRowIndex].Selected = true;

                // Cuon. toi' dong` duoc. chon.
                dgvAirplane.FirstDisplayedScrollingRowIndex = firstRowIndex;
            }
        }

        private Airplane GetSelectedAirplane()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvAirplane.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvAirplane.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot Airplane moi
            Airplane airplane = new Airplane()
            {
                AirplaneCode = row.Cells["AirplaneCode"].Value.ToString(),
                TypeID = Convert.ToInt32(row.Cells["AirplaneTypeID"].Value),
                IsActive = Convert.ToBoolean(row.Cells["IsActive"].Value)
            };

            // Tra Airplane vua tao ve
            return airplane;
        }
    }
}
