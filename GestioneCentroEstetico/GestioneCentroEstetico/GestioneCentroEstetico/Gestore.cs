using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    class Gestore
    {
        public void Entra(Cliente cliente, Centro centro)
        {
            bool trovata = false;
            Postazione postazione = new Postazione(cliente.GetTipo());

            if (cliente.GetBudget() >= postazione.GetPrezzo())
            {
                switch (cliente.GetTipo())
                {
                    case TipoCliente.Viso:
                        if (CercaPostazioneViso(cliente, centro))
                            trovata = true;
                        break;

                    case TipoCliente.Capelli:
                        if (CercaPostazioneCapelli(cliente, centro))
                            trovata = true;
                        break;

                    case TipoCliente.Unghie:
                        if (CercaPostazioneUnghie(cliente, centro))
                            trovata = true;
                        break;
                }
                if (!trovata)
                {
                    Console.WriteLine("\nIl/la cliente " + cliente.GetNome() + " non ha trovato una postazione " + cliente.GetTipo() + " libera nel centro estetico. Si mette in coda");
                }
            }
            else
            {
                Console.WriteLine("\nIl cliente " + cliente.GetNome() + " purtroppo non può permettersi nessun servizio");
                cliente.SetNumServizi(0);
            }
        }

        private bool CercaPostazioneViso(Cliente cliente, Centro centro)
        {
            bool postazioneTrovata = false;
            Postazione[] listaViso = centro.GetPostazioniViso();
            if (!centro.PienoViso())
            {
                for (int i = 0; i < listaViso.Length && !postazioneTrovata; i++)
                {
                    if (!listaViso[i].IsOccupata())
                    {
                        AssegnaPostazione(cliente, listaViso[i]);
                        postazioneTrovata = true;
                        Console.WriteLine("\nIl/la cliente " + cliente.GetNome() + " ha ottenuto una postazione viso e usufruisce del servizio base: Pulizia del viso");
                        cliente.SetSpesa(cliente.GetPostazione().GetPrezzo());
                    }
                }
            }
            return postazioneTrovata;
        }

        private bool CercaPostazioneCapelli(Cliente cliente, Centro centro)
        {
            bool postazioneTrovata = false;
            Postazione[] listaCapelli = centro.GetPostazioniCapelli();
            if (!centro.PienoCapelli())
            {
                for (int i = 0; i < listaCapelli.Length && !postazioneTrovata; i++)
                {
                    if (!listaCapelli[i].IsOccupata())
                    {
                        AssegnaPostazione(cliente, listaCapelli[i]);
                        postazioneTrovata = true;
                        Console.WriteLine("\nIl/la cliente " + cliente.GetNome() + " ha ottenuto una postazione capelli e usufruisce del servizio base: Lavaggio");
                        cliente.SetSpesa(cliente.GetPostazione().GetPrezzo());
                    }
                }
            }
            return postazioneTrovata;
        }

        private bool CercaPostazioneUnghie(Cliente cliente, Centro centro)
        {
            bool postazioneTrovata = false;
            Postazione[] listaUnghie = centro.GetPostazioniUnghie();
            if (!centro.PienoUnghie())
            {
                for (int i = 0; i < listaUnghie.Length && !postazioneTrovata; i++)
                {
                    if (!listaUnghie[i].IsOccupata())
                    {
                        AssegnaPostazione(cliente, listaUnghie[i]);
                        postazioneTrovata = true;
                        Console.WriteLine("\nIl/la cliente " + cliente.GetNome() + " ha ottenuto una postazione unghie e usufruisce del servizio base: manicure");
                        cliente.SetSpesa(cliente.GetPostazione().GetPrezzo());
                    }
                }
            }
            return postazioneTrovata;
        }

        public void Esci(Cliente cliente)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("\nIl cliente " + cliente.GetNome() + " ha pagato {0:C}", cliente.GetSpesa());
            Console.WriteLine(" e sta uscendo dal centro estetico. ");
            if (cliente.GetPostazione() != null)
                cliente.LiberaPostazione();
        }

        public void AssegnaPostazione(Cliente cliente, Postazione postazione)
        {
            postazione.Occupa();
            cliente.SetPostazione(postazione);
        }
    }
}
