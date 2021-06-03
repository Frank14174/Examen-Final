using GraphQLCrudM.IServicio;
using GraphQLCrudM.Modelo;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Estructura
{
    public class Query
    {
        private readonly IGeneroServicio _generoServicio;
        private readonly IMusicaServicio _musicaServicio;
        public Query(IGeneroServicio generoServicio, IMusicaServicio musicaServicio) {
            _generoServicio = generoServicio;
            _musicaServicio = musicaServicio;
        }
        [UsePaging(SchemaType =typeof(GeneroTipo))]
        [UseFiltering]
        public IQueryable<Genero> generos => _generoServicio.GetAll();
        [UsePaging(SchemaType = typeof(MusicaTipo))]
        [UseFiltering]
            
        public IQueryable<Musica> musicas => _musicaServicio.GetAll();
        
    }
}
