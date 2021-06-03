using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Excep
{
    public class MusicaExcepcion :Exception

    {
        public int MusicaId { get; internal set; }

    }
}
