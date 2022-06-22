using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ServizioConsegne
{
    public partial class Cart : Form
    {
        private string connString = @"Data Source = PCCHIARA\SQLEXPRESS;Initial Catalog = Pizzeria; User ID = sa; Password=cs";
        decimal tot = 0;
        public Cart()
        {
            InitializeComponent();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var sqlAdapter = new SqlDataAdapter("SELECT * FROM Menu INNER JOIN Carrello ON Menu.IDRow = Carrello.IDRow", connection);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);


                var carrello = new List<Carrello>();
                foreach (DataRow row in dataTable.Rows)
                {
                    Stream array = new MemoryStream((byte[])row["ImmagineProdotto"]);
                    var Carrello = new Carrello
                    {
                        Chiave = Convert.ToInt32(row["IDRow"]),
                        NomeProdotto = (string)row["NomeProdotto"],
                        PrezzoProdotto = Convert.ToDecimal(row["PrezzoProdotto"]),
                        ImmagineProdotto = new Bitmap(array),
                        QuantitaOrdinata = Convert.ToInt16(row["QuantitaOrdinata"])
                    };
                    carrello.Add(Carrello);
                    tot += Convert.ToDecimal(row["PrezzoProdotto"]) * Convert.ToDecimal(row["QuantitaOrdinata"]);
                    
                }
                textBox1.Text = tot.ToString();
                carrelloBindingSource.DataSource = carrello;
            }
        }

        private void Assistenza_Click(object sender, EventArgs e)
        {
            Hide();
            var assistance = new Assistance();
            assistance.ShowDialog();
            Close();
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            Hide();
            var cart = new Cart();
            cart.ShowDialog();
            Close();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Hide();
            var menu = new Menu();
            menu.ShowDialog();
            Close();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Hide();
            var user = new User();
            user.ShowDialog();
            Close();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            Hide();
            var login = new Form1();
            login.ShowDialog();
            Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var carrello = (Carrello)carrelloBindingSource.Current;

                textBox2.Text = carrello.QuantitaOrdinata.ToString();

                using (var connection = new SqlConnection(connString))
                {

                    var delete = new SqlCommand("DELETE FROM Carrello WHERE IDRow = @id", connection);
                    delete.Parameters.AddWithValue("id", carrello.Chiave);

                    tot -= carrello.PrezzoProdotto * carrello.QuantitaOrdinata;
                    textBox1.Text = tot.ToString();

                    connection.Open();

                    delete.ExecuteNonQuery();

                    carrelloBindingSource.Remove(carrelloBindingSource.Current);
                }
            }
        }

        private void ResetQuantity_Click(object sender, EventArgs e)
        {
            var carrello = (Carrello)carrelloBindingSource.Current;

            using (var connection = new SqlConnection(connString))
            {
                var update = new SqlCommand("UPDATE Carrello SET QuantitaOrdinata = @quantit WHERE IDRow = @id", connection);
                update.Parameters.AddWithValue("quantit", Convert.ToInt16(textBox2.Text));
                update.Parameters.AddWithValue("id", carrello.Chiave);

                connection.Open();

                update.ExecuteNonQuery();

                prodottoBindingSource.EndEdit();
            }
        }
    }
}
