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
        private readonly string tableString = @"SELECT * FROM Menu INNER JOIN Carrello ON Menu.IDMenu = Carrello.IDMenu";
        //Query tabella ordine
        private readonly string tableOrdineString = @"SELECT * FROM Ordine";
        //Query tabella ordine
        private readonly string tableMenuString = @"SELECT * FROM Menu";
        //Query di aggiornamento dei dati
        private readonly string updateString = @"UPDATE Carrello SET QuantitaOrdinata = @quantit WHERE IDMenu = @id";
        //Query di eliminazione della riga
        private readonly string deleteString = @"DELETE FROM Carrello WHERE IDMenu = @id";
        //Query di creazione ordine
        private readonly string addString = @"INSERT INTO Ordine(Destinazione, ImportoTotale) VALUES (@dest, @imp)";
        //Query di creazione ordine
        private readonly string passString = @"INSERT INTO ProdottosuOrdine(IDOrdine, IDMenu, QuantitaOrdinata) VALUES (@id1, @id2, @quant)";

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

        }

        private void DataGridView1_CellCounterClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            var senderGrid = (DataGridView)sender;

            var carrello = (Carrello)carrelloBindingSource.Current;

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
                var create = new SqlCommand(addString, connection);
                create.Parameters.AddWithValue("dest", "dhorhjdòkhn");
                create.Parameters.AddWithValue("imp", tot);

                connection.Open();

                create.ExecuteNonQuery();

                var sqlAdapter = new SqlDataAdapter(tableOrdineString, connection);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);

                int ultimaRiga = dataTable.Rows.Count;
                int i = 0;
                var Ordine = new Ordine();
                foreach (DataRow row in dataTable.Rows)
                {
                    if (i == ultimaRiga - 1)
                        Ordine.IDOrdine = Convert.ToInt16(row["IDOrdine"]);
                    i++;
                }

                sqlAdapter = new SqlDataAdapter(tableString, connection);
                dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    var pass = new SqlCommand(passString, connection);
                    pass.Parameters.AddWithValue("id1", Ordine.IDOrdine);
                    pass.Parameters.AddWithValue("id2", row["IDMenu"]);
                    pass.Parameters.AddWithValue("quant", row["QuantitaOrdinata"]);
                    pass.ExecuteNonQuery();
                }
            }
            /*
            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand(tableString, connection);
                connection.Open();
                var sqlAdapter = new SqlDataAdapter(tableString, connection);
                var dataTable = new DataTable();
                sqlAdapter.Fill(dataTable);

                using (StreamWriter sw = File.CreateText(pathOrder))
                {
                    var scontrino = new List<Carrello>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var Carrello = new Carrello
                        {
                            NomeProdotto = (string)row["NomeProdotto"],
                            PrezzoProdotto = Convert.ToDecimal(row["PrezzoProdotto"]),
                            QuantitaOrdinata = Convert.ToInt16(row["QuantitaOrdinata"])
                        };
                        scontrino.Add(Carrello);
                    }

                    foreach (Carrello c in scontrino)
                    {
                        var somma = 0;
                        var sommaCarrello = c.NomeProdotto.Length + c.PrezzoProdotto.ToString().Length + c.QuantitaOrdinata.ToString().Length;
                        if (sommaCarrello > somma)
                        {
                            somma = sommaCarrello;
                        }
                    }
                }
            }*/
        }

        //Visualizzazione datagridview
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
                        Chiave = Convert.ToInt32(row["IDMenu"]),
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

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellEventArgs e)
        {
            var carrello = (Carrello)carrelloBindingSource.Current;

            using (var connection = new SqlConnection(connString))
            {
                var update = new SqlCommand(updateString, connection);
                update.Parameters.AddWithValue("quantit", carrello.QuantitaOrdinata);
                update.Parameters.AddWithValue("id", carrello.Chiave);

                connection.Open();

                update.ExecuteNonQuery();

                carrelloBindingSource.ResetCurrentItem();
            }
        }
    }
}
