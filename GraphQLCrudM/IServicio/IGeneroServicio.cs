using GraphQLCrudM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.IServicio
{
    public interface IGeneroServicio
    {
        IQueryable<Genero> GetAll();
    }
}
