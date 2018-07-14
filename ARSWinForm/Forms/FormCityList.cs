using ARSWinForm.HelperClass.ModelHelper;
using ARSWinForm.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormCityList : Form
    {
        public FormCityList()
        {
            InitializeComponent();
        }

        private  void FormCityList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormCityCE f = new FormCityCE();
            // f.MdiParent = this.MdiParent;

            // Hien form Create len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Create da tat
            LoadDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lay tai khoan admin dang duoc chon trong bang
            City city = GetSelectedCity();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (city == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Neu co tai khoan dang duoc chon thi hien form chinh sua thong tin len, truyen du lieu qua
            FormCityCE f = new FormCityCE(city, HelperClass.FormMode.EDIT);
            // f.MdiParent = this.MdiParent;

            // Hien form Edit len va doi cho den khi form bi tat di
            f.ShowDialog();

            // Load lai bang sau khi form Edit da tat
            LoadDataGridView();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Lay thanh pho dang duoc chon trong bang
            City city = GetSelectedCity();

            // Neu hien tai khong co tai khoan nao duoc chon thi hien thong bao
            if (city == null)
            {
                MessageBox.Show("You must choose an account to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // Gui len server de cap nhat lai cot IsActive trong CSDL
            CityWrapper cityWrapper = new CityWrapper();
            bool isSuccess = await cityWrapper.Put(city.ID, city);

            // Kiem tra ket qua tra ve
            if (isSuccess)
            {
                // Neu ket qua la thanh cong, hien thong bao thanh cong
                MessageBox.Show("Account status was set to inactive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lai bang
                LoadDataGridView();

            }
            else
            {
                // Neu ket qua that bai, hien thong bao loi
                MessageBox.Show("An error has occurred!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private City GetSelectedCity()
        {
            throw new NotImplementedException();
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
            if (dgvCity.SelectedRows.Count == 0)
            {
                currentRowIndex = 0;
            }
            else
            {
                currentRowIndex = dgvCity.Rows.IndexOf(dgvCity.SelectedRows[0]);
            }

            // Goi API lay du lieu ve
            CityWrapper cityWrapper = new CityWrapper();
            List<City> lstCity = await cityWrapper.List();

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Code");
            table.Columns.Add("Name");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (lstCity != null)
            {
                // Lap qua tung "dong` du lieu"
                foreach (City city in lstCity)
                {
                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();

                    // Gan du lieu len dong moi tao
                    row["ID"] = city.ID;
                    row["Code"] = city.Code;
                    row["Name"] = city.Name;
                    // Gan dong moi tao vao bang
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvCity.DataSource = table;

                // Chon lai dong ban dau duoc chon truoc khi reload
                dgvCity.Rows[currentRowIndex].Selected = true;
            }
        }
    }
}
