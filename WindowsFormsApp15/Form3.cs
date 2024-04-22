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
    public partial class Form3 : Form
    {
        string user;
        string pass;
        double bal;
        List<dynamic> users = new List<dynamic>();
        void paybills()
        {
            double amount = double.Parse(txtAmount.Text);
            if (bal >= amount)
            {
                bal = bal - amount;
                var jsonFile = File.ReadAllText("user.json");
                users = JsonConvert.DeserializeObject<List<dynamic>>(jsonFile);

                foreach (var credentials in users)
                {
                    string u = credentials["username"];
                    if (user == u) 
                    {
                        credentials["balance"] = bal;
                    }
                }

                var newData = JsonConvert.SerializeObject(users);
                File.WriteAllText("user.json", newData);

                Form form2 = new Form2(user, pass, bal);
                MessageBox.Show("Payment Completed");
                this.Hide();
                form2.Show();

            } else
            {
                MessageBox.Show("Insufficient Balance");
            }
        }
        public Form3(string username, string password, double balance)
        {
             user  = username;
             pass = password;
             bal = balance;

            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            paybills();
        }
    }
}
