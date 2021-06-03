using GraphQLCrudM.Excep;
using GraphQLCrudM.IServicio;
using GraphQLCrudM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Servicio
{
    public class MusicaServicio : IMusicaServicio
    {
        private IList<Musica> _musicas;

        public MusicaServicio() {
            _musicas = new List<Musica>()
            {
                new Musica(){GeneroId=1, Nombre="Smells Like Teen Spirit", MusicaId=1 },
                new Musica(){GeneroId=2, Nombre="Summer", MusicaId=2 },
                new Musica(){GeneroId=3, Nombre="Vivir mi vida", MusicaId=3 },
                new Musica(){GeneroId=4, Nombre="Nunca es suficiente", MusicaId=4 },

            };
        }
 

        public Musica Crear(CrearMusica inputMusica)
        {
            var musica = new Musica()
            {
                MusicaId = _musicas.Max(x => x.MusicaId) + 1,
                Nombre = inputMusica.Nombre,
                GeneroId = inputMusica.GeneroId
                        
            };
            _musicas.Add(musica);
            return musica;
        }

        public Musica Eliminar(EliminarMusica inputMusica)
        {
            var musica = _musicas.FirstOrDefault(x=>x.MusicaId==inputMusica.MusicaId);
            if (musica == null) throw new MusicaExcepcion() { MusicaId = inputMusica.MusicaId };
            _musicas.Remove(musica);
            return musica;
        }

        public IQueryable<Musica> GetAll()
        {
            return _musicas.AsQueryable();
        }
    }
}
