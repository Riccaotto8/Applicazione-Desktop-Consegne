using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServizioConsegne
{
    class Carrello
    {
        public int Chiave { get; set; }
        public string NomeProdotto { get; set; }
        public decimal PrezzoProdotto { get; set; }
        public Bitmap ImmagineProdotto { get; set; }
        public int QuantitaOrdinata { get; set; }
    }
}
