using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp15
{
    public partial class Form2 : Form
    {
        string user;
        string pass;
        double bal;

        public Form2(string username, string password, double balance)
        {
             user = username;
             pass = password;
             bal = balance;

            InitializeComponent();
            lblBalance.Text = bal.ToString();
            lblUser.Text = "Welcome "+user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3(user, pass, bal);
            form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form4 = new Form4(user, bal);
            this.Hide();
            form4.Show();

        }
    }
}
