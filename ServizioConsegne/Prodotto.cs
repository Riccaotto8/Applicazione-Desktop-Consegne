using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServizioConsegne
{
    class Prodotto
    {
        public string NomeProdotto { get; set; }
        public decimal PrezzoProdotto { get; set; }

        public Prodotto(string nomeProdotto, decimal prezzoProdotto)
        {
            NomeProdotto = nomeProdotto;
            PrezzoProdotto = prezzoProdotto;
        }

        public Prodotto()
        {
        } 

        public string Name
        {
            get => NomeProdotto;
            set => NomeProdotto = value;
        }

        public decimal Prezzo
        {
            get => PrezzoProdotto;
            set => PrezzoProdotto = value;
        }
    }
}
