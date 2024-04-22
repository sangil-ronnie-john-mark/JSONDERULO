using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace WindowsFormsApp15
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            var json = File.ReadAllText("user.json");
            List<dynamic> user = JsonConvert.DeserializeObject<List<dynamic>>(json);

            InitializeComponent();

            dgvData.DataSource = user;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell username = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex];
            lblUsername.Text = username.Value.ToString();

            DataGridViewCell balance = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex+2];

            txtBalance.Text = balance.Value.ToString();
        }
    }
}
