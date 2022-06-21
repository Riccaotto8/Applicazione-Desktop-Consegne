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
using System.IO;

namespace ServizioConsegne
{
    public partial class Administrator : Form
    {
        private int indexRow;
        private string connString = @"Data Source = PCCHIARA\SQLEXPRESS;Initial Catalog = Pizzeria; User ID = sa; Password=cs";
        public Administrator()
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
                prodottoBindingSource1.DataSource = prodotti;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
            }
            catch (IndexOutOfRangeException) { }

            
            pictureBox1.Image = ImmagineProdotto.Image;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];

            newDataRow.Cells[0].Value = textBox1.Text;
            newDataRow.Cells[1].Value = textBox2.Text;
            newDataRow.Cells[2].Value = pictureBox1.Image;

            var prodotto = (Prodotto)prodottoBindingSource1.Current;

            using (var connection = new SqlConnection(connString))
            {
                var update = new SqlCommand("UPDATE Menu SET NomeProdotto = @nome, PrezzoProdotto = @prezzo, ImmagineProdotto = @img WHERE IDRow = @id", connection);
                update.Parameters.AddWithValue("nome", textBox1.Text);
                update.Parameters.AddWithValue("prezzo", Convert.ToDecimal(textBox2.Text));
                update.Parameters.AddWithValue("id", prodotto.Chiave);
                var memoryStream = new MemoryStream();
                pictureBox1.Image.Save(memoryStream, pictureBox1.Image.RawFormat);
                update.Parameters.AddWithValue("img", memoryStream.ToArray());

                connection.Open();

                update.ExecuteNonQuery();

                prodottoBindingSource1.EndEdit();
            }
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(connString))
            {

                var add = new SqlCommand("INSERT INTO Menu(NomeProdotto, PrezzoProdotto, ImmagineProdotto) VALUES (@nome, @prezzo, @img)", connection);
                add.Parameters.AddWithValue("nome", textBox1.Text);
                add.Parameters.AddWithValue("prezzo", Convert.ToDecimal(textBox2.Text));
                var memoryStream = new MemoryStream();
                pictureBox1.Image.Save(memoryStream, pictureBox1.Image.RawFormat);
                add.Parameters.AddWithValue("img", memoryStream.ToArray());

                connection.Open();

                var img = new Bitmap(memoryStream);

                var prodotto = new Prodotto
                {
                    NomeProdotto = textBox1.Text,
                    PrezzoProdotto = Convert.ToDecimal(textBox2.Text),
                    ImmagineProdotto = img
                };

                prodottoBindingSource1.Add(prodotto);

                add.ExecuteNonQuery();


            }
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            var prodotto = (Prodotto)prodottoBindingSource1.Current;

            using (var connection = new SqlConnection(connString))
            {

                var delete = new SqlCommand("DELETE FROM Menu WHERE IDRow = @id", connection);
                delete.Parameters.AddWithValue("id", prodotto.Chiave);

                connection.Open();

                delete.ExecuteNonQuery();

                prodottoBindingSource1.Remove(prodottoBindingSource1.Current);
            }
        }

        private void SelectImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "SELECT image(*.jpg; *.png)|*.jpg; *png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
