using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace WindowsFormsApp15
{
    public partial class Form4 : Form
    {
        string user;
        double bal;
        string file_name = "user.json";
        List<dynamic> users = new List<dynamic>();
        void deposit(double amount)
        {
            var json = File.ReadAllText(file_name);
            users = JsonConvert.DeserializeObject<List<dynamic>>(json);

            foreach (var credentials in users)
            {
                string u = credentials["username"];
                if (u == user)
                {
                    credentials["balance"] = credentials["balance"] + amount;
                    double b = credentials["balance"];
                    var jsonFile = JsonConvert.SerializeObject(users);
                    File.WriteAllText(file_name, jsonFile);

                    MessageBox.Show("Deposit Completed");
                    Form form2 = new Form2(user, "", b);
                    this.Hide();
                    form2.Show();

                }
            }

        }
        public Form4(string username, double balance)
        {
            user = username;
            bal = balance;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deposit(double.Parse(txtAmount.Text));
        }
    }
}
