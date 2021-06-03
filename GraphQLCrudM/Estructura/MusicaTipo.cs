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
    public class MusicaTipo : ObjectType<Musica>
    {
        protected override void Configure(IObjectTypeDescriptor<Musica> descriptor)
        {
            descriptor.Field(x => x.MusicaId).Type<IdType>();
            descriptor.Field(x => x.Nombre).Type<StringType>();
            descriptor.Field<GeneroResolver>(x => x.GetGenero(default, default));


        }
    }
    public class GeneroResolver {
        private readonly IGeneroServicio _generoServicio;
        public GeneroResolver([Service] IGeneroServicio generoServicio) {
            _generoServicio = generoServicio;
        }
        public Genero GetGenero(Musica musica, IResolverContext ctx) {
            return _generoServicio.GetAll().Where(x=>x.GeneroId==musica.GeneroId).FirstOrDefault();
        }

    }

}
