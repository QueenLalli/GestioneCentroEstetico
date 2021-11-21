using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    class ClienteCreator
    {
        public Cliente FactoryMethod(int count, string nome)
        {
            TipoCliente tipoCliente;
            Random rnd = new Random();

            if (count % 5 == 0)
            {
                tipoCliente = TipoCliente.Unghie;
            }
            else
            {
                if (count % 2 == 0)
                    tipoCliente = TipoCliente.Capelli;
                else
                    tipoCliente = TipoCliente.Viso;
            }
                                                    //budget           numServizi
            return new Cliente(tipoCliente, nome, rnd.Next(30, 100), rnd.Next(1, 3));
        }
    }
}
