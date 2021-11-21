using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    public class Servizio
    {
        private string nome;
        private int prezzo;

        public Servizio(string nome, int prezzo)
        {
            this.nome = nome;
            this.prezzo = prezzo;
        }

        public int GetPrezzo()
        {
            return this.prezzo;
        }

        public string GetNome()
        {
            return this.nome;
        }
    }
}
