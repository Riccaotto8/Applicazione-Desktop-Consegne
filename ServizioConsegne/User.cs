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
        private string connString = @"Data Source=PCCHIARA\SQLEXPRESS;Initial Catalog= Pizzeria;User ID=sa;Password=cs";
        public User()
        {
            InitializeComponent();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var sqlAdapter = new SqlDataAdapter("SELECT * FROM Menu", conn);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);

                var prodotti = new List<Prodotto>();
                foreach (DataRow row in dataTable.Rows)
                {
                    var Prodotto = new Prodotto
                    {
                        Name = (string)row["NomeProdotto"],
                        Prezzo = Convert.ToDecimal(row["Prezzo"])
                    };
                    prodotti.Add(Prodotto);
                }
                prodottoBindingSource.DataSource = prodotti;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
           
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            var menu = new Menu();
            menu.Show();
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            var cart = new Cart();
            cart.Show();
        }

        private void Assistance_Click(object sender, EventArgs e)
        {
            var assistace = new Assistance();
            assistace.Show();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            var login = new Form1();
            login.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
