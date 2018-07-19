using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAirplaneTypeList : Form
    {
        public FormAirplaneTypeList()
        {
            InitializeComponent();
        }

        private async void AirplaneType_Load(object sender, EventArgs e)
        {
            // Dia chi API
            string url = "http://localhost:61765/api/AirplaneTypes/";

            // Cu phap goi API
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Nhan ket qua tra ve tu API
            HttpResponseMessage response = await client.GetAsync(url);

            // Tao bang de chua du lieu tra ve tu API
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("IsActive");

            // Kiem tra xem ket qua goi API co thanh cong hay khong
            if (response.IsSuccessStatusCode)
            {
                // Lay du lieu tra ve tu API
                var responseData = response.Content.ReadAsStringAsync().Result;
                JArray parser = JArray.Parse(responseData.ToString());

                // Sau khi lay du lieu, ta se co cac dong` du lieu
                // Lap qua tung "dong` du lieu"
                foreach (var pair in parser)
                {
                    // Kiem tra xem co phai mot cot trong bang khong
                    if (pair is IList) continue;

                    // Tao mot dong` trong bang winForm
                    DataRow row = table.NewRow();
                    JObject obj = JObject.Parse(pair.ToString());
                    int count = 0;

                    // Lap qua cac cot trong "dong` du lieu"
                    foreach (var s in obj)
                    {
                        // Lay du lieu trong cot, gan' len cot trong dong` WinForm
                        row[count++] = s.Value.ToString();
                    }

                    // Sau khi lap qua het cac cot trong dong du lieu
                    // Ta co mot dong WinForm hoan chinh
                    // Lay dong WinForm gan len bang WinForm
                    table.Rows.Add(row);
                }

                // Sau khi lap qua het cac dong du lieu
                // Ta co bang WinForm hoan chinh
                // Gan bang WinForm len DataGridView
                dgvAirplaneType.DataSource = table;
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormAirplaneTypeCE f = new FormAirplaneTypeCE();
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormAirplaneTypeCE f = new FormAirplaneTypeCE();
            f.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }
    }
}
