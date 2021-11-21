using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    public class Cliente
    {
        private string nome;
        private Postazione miaPostazione;
        private TipoCliente tipo;
        private int numServizi;
        private double budget;
        private double spesa;

        public Cliente(TipoCliente tipoCliente, string nome, double budget, int numServizi)
        {
            this.nome = nome;
            this.numServizi = numServizi;
            this.miaPostazione = null;
            this.budget = budget;
            this.tipo = tipoCliente;
            this.spesa = 0;
        }

        public double GetBudget()
        {
            return this.budget;
        }

        public void SetSpesa(double costo)
        {
            this.spesa += costo;
        }

        public double GetSpesa()
        {
            return this.spesa;
        }
        public string GetNome()
        {
            return this.nome;
        }

        public Postazione GetPostazione()
        {
            return this.miaPostazione;
        }

        public void SetPostazione(Postazione postazione)
        {
            this.miaPostazione = postazione;
        }

        public int GetNumServizi()
        {
            return this.numServizi;
        }

        public void SetNumServizi(int val)
        {
            this.numServizi = val;
        }
        
        public TipoCliente GetTipo()
        {
            return this.tipo;
        }

        public void LiberaPostazione()
        {
            this.miaPostazione.Libera();
            this.miaPostazione = null;
        }

        public bool Pagare(double costo)
        {
            if (this.budget >= costo)
            {
                this.budget -= costo;
                return true;
            }
            return false;
        }

        public void ChiediServizi()
        {
            Random rnd = new Random();
            List<Servizio> servizi;
            Servizio servizioScelto;
            servizi = this.miaPostazione.GetServizi();
            servizioScelto = servizi[rnd.Next(servizi.Count)];
            if (!this.Pagare(servizioScelto.GetPrezzo()))
            {
                Console.WriteLine("\nIl/la cliente " + this.nome + " non può permettersi il servizio '" + servizioScelto.GetNome() + "' che ha richiesto. Quindi esce...");
                this.numServizi = 0;
            }
            else
            {
                Console.WriteLine("\nIl/la cliente " + this.nome + " sta effettuando il servizio '" + servizioScelto.GetNome() + "'.");
                SetSpesa(servizioScelto.GetPrezzo());
                this.numServizi--;
            }

        }
    }
}
