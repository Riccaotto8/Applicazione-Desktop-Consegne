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
    public partial class User : Form
    {
        //private string connString = @"Data Source=PCCHIARA\SQLEXPRESS;Initial Catalog= Pizzeria;User ID=sa;Password=cs";
        public User()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, EventArgs e)
        {
           
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Hide();
            var menu = new Menu();
            menu.ShowDialog();
            Close();
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            Hide();
            var cart = new Cart();
            cart.ShowDialog();
            Close();
        }

        private void Assistance_Click(object sender, EventArgs e)
        {
            Hide();
            var assistance = new Assistance();
            assistance.ShowDialog();
            Close();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            Hide();
            var login = new Login();
            login.ShowDialog();
            Close();
        }
    }
}
