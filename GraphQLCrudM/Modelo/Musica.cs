using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Modelo
{
    public class Musica
    {
        public int MusicaId { get; set; }
        public string Nombre { get; set; }
        public int GeneroId { get; set; }

    }
}
