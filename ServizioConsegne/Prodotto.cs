﻿using System.Drawing;

namespace ServizioConsegne
{
    class Prodotto
    {
        public int Chiave { get; set; }
        public string NomeProdotto { get; set; }
        public decimal PrezzoProdotto { get; set; }
        public Bitmap ImmagineProdotto { get; set; }

        public Prodotto()
        {
        }
    }
}
