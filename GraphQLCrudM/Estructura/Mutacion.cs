using GraphQLCrudM.IServicio;
using GraphQLCrudM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Estructura
{
    public class Mutacion 
    {
        private readonly IMusicaServicio _musicaServicio;

        public Mutacion(IMusicaServicio musicaServicio) {
            _musicaServicio = musicaServicio;

        }

        public Musica CrearMusica(CrearMusica inputMusica)
        {
            return _musicaServicio.Crear(inputMusica);
        }

        public Musica EliminarMusica(EliminarMusica inputMusica)
        {
            return _musicaServicio.Eliminar(inputMusica);
        }
    }
}
