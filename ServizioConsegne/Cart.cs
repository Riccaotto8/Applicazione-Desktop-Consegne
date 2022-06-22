﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var sqlAdapter = new SqlDataAdapter("SELECT * FROM Carrello", connection);
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
                    tot += Convert.ToDecimal(row["PrezzoProdotto"]);
                }
                textBox1.Text = tot.ToString();
                prodottoBindingSource.DataSource = prodotti;
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

        private void Delete_Click(object sender, EventArgs e)
        {
            var prodotto = (Prodotto)prodottoBindingSource.Current;

            using (var connection = new SqlConnection(connString))
            {

                var delete = new SqlCommand("DELETE FROM Carrello WHERE IDRow = @id", connection);
                delete.Parameters.AddWithValue("id", prodotto.Chiave);

                tot -= prodotto.PrezzoProdotto;
                textBox1.Text = tot.ToString();

                connection.Open();

                delete.ExecuteNonQuery();

                prodottoBindingSource.Remove(prodottoBindingSource.Current);
            }
        }
    }
}
