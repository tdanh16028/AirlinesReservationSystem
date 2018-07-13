using ARSWinForm.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSWinForm
{
    public partial class FormAirplaneCE : Form
    {
        public FormAirplaneCE()
        {
            InitializeComponent();
        }
        
        public async Task AddAirplane(string airplaneCode , int typeID)
        {
            string url = "http://localhost:65529/api/AdminAccounts";
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);

            Airplane aa = new Airplane()
            {
                AirplaneCode = airplaneCode,
                TypeID = typeID

            };
            response = await client.PostAsJsonAsync(url, aa);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("OK", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task AddNewAirplane(string airplaneCode , int typeID)
        {
            AddAirplane(airplaneCode , typeID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddNewAirplane(txtAirplaneCode.Text, 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
