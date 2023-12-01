using Veterinaria_Web.Models.Entities;

namespace Veterinaria_Web.Services.IService
{
    public interface IArticuloServices
    {

        public Task<List<Articulo>> GetArticulos();
        public Task<Articulo> GetByIdArticulo(int id);
        public Task<Articulo> CrearArticulo(Articulo i);
        public bool EliminarArticulo(int id);
        public Task<Articulo> EditarArticulo(Articulo O);
    }
}
