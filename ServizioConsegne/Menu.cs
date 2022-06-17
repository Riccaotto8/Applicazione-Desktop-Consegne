using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServizioConsegne
{
    public partial class Menu : Form
    {
        private string connString = @"Data Source=PCCHIARA\SQLEXPRESS;Initial Catalog= Pizzeria;User ID=sa;Password=cs";
        public Menu()
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

        private void Home_Click(object sender, EventArgs e)
        {
            var home = new User();
            home.Show();
        }
    }
}
