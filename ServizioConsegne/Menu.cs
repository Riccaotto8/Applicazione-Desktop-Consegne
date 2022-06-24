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
        //Query di connessione 
        private readonly string connString = @"Data Source=PCCHIARA\SQLEXPRESS;Initial Catalog= Pizzeria;User ID=sa;Password=cs";
        //Query tabella
        private readonly string tableString = @"SELECT * FROM Menu";
        //Query aggiornamento dei dati
        private readonly string updateString = @"UPDATE Carrello SET QuantitaOrdinata += @quantit WHERE IDMenu = @id";
        //Query aggiunzione dei dati
        private readonly string addString = @"INSERT INTO Carrello(IDMenu, QuantitaOrdinata) VALUES (@idR, @quantit)";

        public Menu()
        {
            InitializeComponent();
            DataGridView_View();
        }

        //Bottone per la home
        private void Home_Click(object sender, EventArgs e)
        {
            Hide();
            var home = new User();
            home.ShowDialog();
            Close();
        }

        //Bottone per il carrello
        private void Cart_Click(object sender, EventArgs e)
        {
            Hide();
            var cart = new Cart();
            cart.ShowDialog();
            Close();
        }

        //Bottone per l'assistenza
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

            var prodotto = (Prodotto)prodottoBindingSource.Current;

            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "1";
            }

            using (var connection = new SqlConnection(connString))
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {

                    var update = new SqlCommand(updateString, connection);
                    update.Parameters.AddWithValue("id", prodotto.Chiave);
                    update.Parameters.AddWithValue("quantit", Convert.ToInt16(textBox1.Text));

                    var add = new SqlCommand(addString, connection);
                    add.Parameters.AddWithValue("idR", prodotto.Chiave);
                    add.Parameters.AddWithValue("quantit", Convert.ToInt16(textBox1.Text));

                    connection.Open();

                    if (update.ExecuteNonQuery() == 0)
                    {
                        add.ExecuteNonQuery();
                    }
                }
            }
        }

        private void DataGridView_View()
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var sqlAdapter = new SqlDataAdapter(tableString, connection);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);

                var prodotti = new List<Prodotto>();
                foreach (DataRow row in dataTable.Rows)
                {
                    Stream array = new MemoryStream((byte[])row["ImmagineProdotto"]);
                    var Prodotto = new Prodotto
                    {
                        Chiave = Convert.ToInt32(row["IDMenu"]),
                        NomeProdotto = (string)row["NomeProdotto"],
                        PrezzoProdotto = Convert.ToDecimal(row["PrezzoProdotto"]),
                        ImmagineProdotto = new Bitmap(array)
                    };
                    prodotti.Add(Prodotto);
                }
                prodottoBindingSource.DataSource = prodotti;
            }
        }
    }
}
