using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    public class Postazione
    {
        private double prezzoBase;
        private bool occupata;
        private TipoCliente tipo;
        private List<Servizio> servizi;


        public Postazione(TipoCliente tipoCliente)
        {
            this.tipo = tipoCliente;
            this.occupata = false;
            this.servizi = new List<Servizio>();

            switch (tipoCliente)
            {
                case TipoCliente.Capelli:
                    this.prezzoBase = 15;
                    this.servizi.Add(new Servizio("Colore", 25));
                    this.servizi.Add(new Servizio("Taglio", 20));
                    this.servizi.Add(new Servizio("Piega", 10));
                    this.servizi.Add(new Servizio("Piastra", 15));
                    this.servizi.Add(new Servizio("Permanente", 20));
                    break;

                case TipoCliente.Viso:
                    this.prezzoBase = 25;
                    this.servizi.Add(new Servizio("Make up", 15));
                    this.servizi.Add(new Servizio("Cera Viso", 10));
                    this.servizi.Add(new Servizio("Rinofiller", 50));
                    this.servizi.Add(new Servizio("Ossigenoterapia", 20));
                    this.servizi.Add(new Servizio("Laminazione Ciglia", 40));
                    break;

                case TipoCliente.Unghie:
                    this.prezzoBase = 20;
                    this.servizi.Add(new Servizio("Smalto", 30));
                    this.servizi.Add(new Servizio("Semipermanente", 38));
                    this.servizi.Add(new Servizio("Gel", 45));
                    this.servizi.Add(new Servizio("Ricostruzione in gel", 50));
                    this.servizi.Add(new Servizio("Refill", 40));
                    break;
            }
        }
        public List<Servizio> GetServizi()
        {
            return this.servizi;
        }

        public void Occupa()
        {
            this.occupata = true;
        }

        public void Libera()
        {
            this.occupata = false;
        }

        public bool IsOccupata()
        {
            return this.occupata;
        }

        public double GetPrezzo()
        {
            return this.prezzoBase;
        }

        public TipoCliente GetTipo()
        {
            return this.tipo;
        }
    }
}
