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
        private City GetSelectedCity()
        {
            // Neu khong co dong nao dang duoc chon thi tra ve null
            if (dgvCity.SelectedRows.Count != 1) return null;

            // Neu co 1 dong dang duoc chon thi lay dong do ra
            DataGridViewRow row = dgvCity.SelectedRows[0];

            // Lay du lieu trong dong do va tao ra mot AdminAccount moi
            City city = new City()
            {
              
                Code = row.Cells["Code"].Value.ToString(),
                Name = row.Cells["Name"].Value.ToString(),
            };

            // Tra AdminAccount vua tao ve
            return city;
        }
    }
}
