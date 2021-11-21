using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GestioneCentroEstetico
{
    class Program
    {
        static void Main()
        {
            Centro centro = new Centro(7, 5, 3);
            Gestore gestore = new Gestore();

            ClienteCreator clienteCreator = new ClienteCreator();
            List<Cliente> clienti = new List<Cliente>();

            int count = 0;

            string nome;
            FileInfo file = new FileInfo("Nomi.txt");
            StreamReader sr = new StreamReader(file.FullName);


            //Creo la lista di clienti tramite il factoryMethod e i nomi presi dal file di testo 
            while ((nome = sr.ReadLine()) != null)
            {
                clienti.Add(clienteCreator.FactoryMethod(count, nome));
                count++;
            }
            Console.WriteLine("Il Centro estetico apre..");
            while (centro.IsAperto())
            {   
                // Assegno una postazione libera ai clienti che non la hanno
                foreach (Cliente c in clienti)
                {
                    if (c.GetPostazione() == null)
                        gestore.Entra(c, centro);
                }
                for (int i = 0; i < clienti.Count; i++)
                {
                    // I clienti "seduti" richiedono un servizio
                    if (clienti[i].GetPostazione() != null)
                        clienti[i].ChiediServizi();

                    // I clienti che hanno svolto il numero di servizi desiderati escono
                    if (clienti[i].GetNumServizi() <= 0)
                    {
                        gestore.Esci(clienti[i]);
                        clienti.Remove(clienti[i]);
                        i--;
                    }
                }
                if (clienti.Count == 0)
                {
                    centro.Chiudi();
                }
            }
        }
    }
}
