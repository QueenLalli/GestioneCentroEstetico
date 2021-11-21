using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    public class Centro
    {
        private List<Postazione> postazioni;
        private PostazioneCreator postazioneCreator = new PostazioneCreator();
        private bool aperto;

        public Centro(int numPostazioniCapelli, int numPostazioniViso, int numPostazioniUnghie)
        {
            this.postazioni = new List<Postazione>();

            for (int i = 0; i < numPostazioniCapelli; i++)
            {
                this.postazioni.Add(postazioneCreator.FactoryMethod(TipoCliente.Capelli));
            }

            for (int i = 0; i < numPostazioniViso; i++)
            {
                this.postazioni.Add(postazioneCreator.FactoryMethod(TipoCliente.Viso));
            }

            for (int i = 0; i < numPostazioniUnghie; i++)
            {
                this.postazioni.Add(postazioneCreator.FactoryMethod(TipoCliente.Unghie));
            }

            this.aperto = true;
        }
        public bool IsAperto()
        {
            return this.aperto;
        }


        public Postazione[] GetPostazioniCapelli()
        {
            List<Postazione> postazioniCapelli = new List<Postazione>();
            foreach (Postazione postazione in this.postazioni)
            {
                if (postazione.GetTipo() == TipoCliente.Capelli)
                    postazioniCapelli.Add(postazione);
            }
            return postazioniCapelli.ToArray();
        }

        public Postazione[] GetPostazioniViso()
        {
            List<Postazione> postiViso = new List<Postazione>();
            foreach (Postazione postazione in this.postazioni)
            {
                if (postazione.GetTipo() == TipoCliente.Viso)
                    postiViso.Add(postazione);
            }
            return postiViso.ToArray();
        }

        public Postazione[] GetPostazioniUnghie()
        {
            List<Postazione> postiUnghie = new List<Postazione>();
            foreach (Postazione postazione in this.postazioni)
            {
                if (postazione.GetTipo() == TipoCliente.Unghie)
                    postiUnghie.Add(postazione);
            }
            return postiUnghie.ToArray();
        }

        public bool PienoCapelli()
        {
            bool pieno = true;
            Postazione[] postazioniCapelli = GetPostazioniCapelli();
            foreach (Postazione postazione in postazioniCapelli)
            {
                if (!postazione.IsOccupata())
                    pieno = false;
            }
            return pieno;
        }

        public bool PienoViso()
        {
            bool pieno = true;
            Postazione[] postazioniViso = GetPostazioniViso();
            foreach (Postazione postazione in postazioniViso)
            {
                if (!postazione.IsOccupata())
                    pieno = false;
            }
            return pieno;
        }

        public bool PienoUnghie()
        {
            bool pieno = true;
            Postazione[] postazioniUnghie = GetPostazioniUnghie();
            foreach (Postazione postazione in postazioniUnghie)
            {
                if (!postazione.IsOccupata())
                    pieno = false;
            }
            return pieno;
        }

        public void Chiudi()
        {
            this.aperto = false;
            Console.WriteLine("\nIl Centro estetico chiude..");
        }
    }
}
