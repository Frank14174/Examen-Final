using GraphQLCrudM.IServicio;
using GraphQLCrudM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCrudM.Servicio
{
    public class GeneroServicio : IGeneroServicio
    {
        private IList<Genero> _genero;

        public GeneroServicio() {
            _genero = new List<Genero>() { 
                new Genero(){ GeneroId =1, Nombre ="Rock", Abreviatura="Rk"},
                new Genero(){ GeneroId =2, Nombre ="Electronica", Abreviatura="Electr"},
                new Genero(){ GeneroId =3, Nombre ="Salsa", Abreviatura="Sa"},
                new Genero(){ GeneroId =4, Nombre ="Cumbia", Abreviatura="Bla"},
            };
        }
        public IQueryable<Genero> GetAll()
        {
            return _genero.AsQueryable();
        }
    }
}
