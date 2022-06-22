using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ServizioConsegne
{
    public partial class Menu : Form
    {
        private string connString = @"Data Source=PCCHIARA\SQLEXPRESS;Initial Catalog= Pizzeria;User ID=sa;Password=cs";
        public Menu()
        {
            InitializeComponent();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var sqlAdapter = new SqlDataAdapter("SELECT * FROM Menu", connection);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);

                var prodotti = new List<Prodotto>();
                foreach (DataRow row in dataTable.Rows)
                {
                    Stream array = new MemoryStream((byte[])row["ImmagineProdotto"]);
                    var Prodotto = new Prodotto
                    {
                        Chiave = Convert.ToInt32(row["IDRow"]),
                        NomeProdotto = (string)row["NomeProdotto"],
                        PrezzoProdotto = Convert.ToDecimal(row["PrezzoProdotto"]),
                        ImmagineProdotto = new Bitmap(array)
                    };
                    prodotti.Add(Prodotto);
                }
                prodottoBindingSource.DataSource = prodotti;
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Hide();
            var home = new User();
            home.ShowDialog();
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var prodotto = (Prodotto)prodottoBindingSource.Current;

                using (var connection = new SqlConnection(connString))
                {
                    var add = new SqlCommand("INSERT INTO Carrello(IDRow, QuantitaOrdinata) VALUES (@id, @quantit)", connection);
                    add.Parameters.AddWithValue("id", prodotto.Chiave);
                    add.Parameters.AddWithValue("quantit", Convert.ToInt16(textBox1.Text));

                    connection.Open();

                    add.ExecuteNonQuery();
                }
            }
        }
    }
}
