using GraphQLCrudM.IServicio;
using GraphQLCrudM.Modelo;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Estructura
{
    public class GeneroTipo : ObjectType<Genero>
    {
        protected override void Configure(IObjectTypeDescriptor<Genero> descriptor)
        {
            descriptor.Field(x => x.GeneroId).Type<IdType>();
            descriptor.Field(x => x.Nombre).Type<StringType>();
            descriptor.Field(x => x.Abreviatura).Type<StringType>();
            descriptor.Field<MusicaResolver>(x=>x.GetMusicas(default,default));
        }
    }

    public class MusicaResolver {
        private readonly IMusicaServicio _musicaServicio;
        
        public MusicaResolver([Service] IMusicaServicio musicaServicio) {
            _musicaServicio = musicaServicio;

        }
        public IEnumerable<Musica> GetMusicas(Genero genero, IResolverContext ctx) {
            return _musicaServicio.GetAll().Where(x => x.GeneroId == genero.GeneroId);
        }

    }
}
