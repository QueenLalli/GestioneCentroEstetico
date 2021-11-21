using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneCentroEstetico
{
    class PostazioneCreator
    {
        public Postazione FactoryMethod(TipoCliente tipoCliente)
        {
            return new Postazione(tipoCliente);
        }
    }
}
