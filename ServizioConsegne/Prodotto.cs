using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServizioConsegne
{
    class Prodotto
    {
        public int Chiave { get; set; }
        public string NomeProdotto { get; set; }
        public decimal PrezzoProdotto { get; set; }

        public Prodotto()
        {
        }
    }
}
