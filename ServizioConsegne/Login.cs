using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ServizioConsegne
{
    public partial class  Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "Admin") && (textBox2.Text == "1234"))
            {
                Hide();
                var admin = new Administrator();
                admin.ShowDialog();
                Close();
            }
            else if(((textBox1.Text != "") && (textBox2.Text != "")) && ((textBox1.Text != "Immetti nome") && (textBox2.Text != "Immetti password")))
            {
                Hide();
                var home = new User();
                home.ShowDialog();
                Close();
            }
            else
            {
                textBox1.Text = "Immetti nome";
                textBox2.Text = "Immetti password";
            }
        }
    }
}
