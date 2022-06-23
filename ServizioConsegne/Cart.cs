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
        //Query di connessione
        private readonly string connString = @"Data Source = PCCHIARA\SQLEXPRESS;Initial Catalog = Pizzeria; User ID = sa; Password = cs";
        //Query tabella
        private readonly string tableString = @"SELECT * FROM Menu INNER JOIN Carrello ON Menu.IDRow = Carrello.IDRow";
        //Query di aggiornamento dei dati
        private readonly string updateString = @"UPDATE Carrello SET QuantitaOrdinata = @quantit WHERE IDRow = @id";
        //Query di eliminazione della riga
        private readonly string deleteString = @"DELETE FROM Carrello WHERE IDRow = @id";

        //Variabili universali
        decimal tot = 0;
        private int indexRow;
        public Cart()
        {
            InitializeComponent();
            DataGridView_View();
        }

        //Bottone per l'assistenza
        private void Assistenza_Click(object sender, EventArgs e)
        {
            Hide();
            var assistance = new Assistance();
            assistance.ShowDialog();
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

        //Bottone per il menu
        private void Menu_Click(object sender, EventArgs e)
        {
            Hide();
            var menu = new Menu();
            menu.ShowDialog();
            Close();
        }

        //Bottone per la home
        private void Home_Click(object sender, EventArgs e)
        {
            Hide();
            var user = new User();
            user.ShowDialog();
            Close();
        }

        //Bottone per il login
        private void Log_Click(object sender, EventArgs e)
        {
            Hide();
            var login = new Login();
            login.ShowDialog();
            Close();
        }

        //Aggiornamento della quantità
        private void ResetQuantity_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                if (indexRow >= 0)
                {
                    DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];

                    newDataRow.Cells[3].Value = textBox2.Text;

                    var carrello = (Carrello)carrelloBindingSource.Current;

                    using (var connection = new SqlConnection(connString))
                    {
                        var update = new SqlCommand(updateString, connection);
                        update.Parameters.AddWithValue("quantit", Convert.ToInt16(textBox2.Text));
                        update.Parameters.AddWithValue("id", carrello.Chiave);

                        connection.Open();

                        update.ExecuteNonQuery();

                        carrelloBindingSource.ResetCurrentItem();
                    }
                }
            }
            else
            {
                textBox2.Text = "1";
            }
        }

        private void DataGridView1_CellCounterClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            var senderGrid = (DataGridView)sender;

            var carrello = (Carrello)carrelloBindingSource.Current;

            textBox2.Text = carrello.QuantitaOrdinata.ToString();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && indexRow >= 0)
            {
                
                using (var connection = new SqlConnection(connString))
                {

                    var delete = new SqlCommand(deleteString, connection);
                    delete.Parameters.AddWithValue("id", carrello.Chiave);

                    tot -= carrello.PrezzoProdotto * carrello.QuantitaOrdinata;
                    textBox1.Text = tot.ToString();

                    connection.Open();

                    delete.ExecuteNonQuery();

                    carrelloBindingSource.RemoveCurrent();
                }
            }
        }

        private void AddOrder_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Ordine confermato";
            //var rand = new Random();
            var timeStamp = GetTimestamp(DateTime.Now);

            string pathOrder = @"C:\Users\ut02\source\repos\ServizioConsegne\ServizioConsegne\Ricevute\ordine" + timeStamp + ".txt";

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand(tableString, connection);
                connection.Open();
                var sqlAdapter = new SqlDataAdapter(tableString, connection);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);

                using (StreamWriter sw = File.CreateText(pathOrder))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        sw.Write("Pizza: " + row["NomeProdotto"] + " Prezzo: " + row["PrezzoProdotto"] + " €" + " Quantità: " + row["QuantitaOrdinata"] + "\n");
                    }

                    sw.Write("Importo totale: " + tot.ToString() + " €");
                }
            }
        }

        //Visualizzazione elementi della datagridview
        private void DataGridView_View()
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var sqlAdapter = new SqlDataAdapter(tableString, connection);
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

                    //Calcola del totale
                    tot += Convert.ToDecimal(row["PrezzoProdotto"]) * Convert.ToDecimal(row["QuantitaOrdinata"]);

                }
                //Visualizzazione totale
                textBox1.Text = tot.ToString();
                carrelloBindingSource.DataSource = carrello;
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
