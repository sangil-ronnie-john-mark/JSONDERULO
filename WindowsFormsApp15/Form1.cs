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
    public partial class Form1 : Form
    {
        // meaning ng json is javascript on notation
        string file_name = "user.json";
        List<dynamic> user = new List<dynamic>();
     
        void signUp(string username, string password)
        {
            // babasahin niya yung text sa loob ng user.json tapos po ilalagay nya sa json file
            var jsonFile = File.ReadAllText(file_name);

            user = JsonConvert.DeserializeObject<List<dynamic>>(jsonFile);

            var credentials = new
            {
                username = username,
                password = password,
                balance = 10000,
            };

            user.Add(credentials);

            var userJson = JsonConvert.SerializeObject(user);
            File.WriteAllText(file_name, userJson);

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            signUp(txtUsername.Text, txtPassword.Text);
            MessageBox.Show("Signup!");
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jsonFile = File.ReadAllText(file_name);
            user = JsonConvert.DeserializeObject<List<dynamic>>(jsonFile);
            // ilalagay po naten yung mga map kay melvin
            foreach (var melvin in user)
            {
                string user = melvin["username"];
                string pass = melvin["password"];
                double bal = melvin["balance"];
                if (txtUsername.Text == "hyperAdmin" && txtPassword.Text == "123")
                {
                    Form form5 = new Form5();
                    form5.Show();
                    this.Hide();
                    return;
                }
                if (user == txtUsername.Text && pass == txtPassword.Text) 
                {
                    MessageBox.Show("Login");
                    Form form2 = new Form2(user, pass, bal);
                    this.Hide();
                    form2.Show();
                    return;

                  
                } 
            }
            MessageBox.Show("Invalid Username or Password");
        }
    }
}
