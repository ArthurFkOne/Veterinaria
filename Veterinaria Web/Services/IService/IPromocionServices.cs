using Veterinaria_Web.Models.Entities;

namespace Veterinaria_Web.Services.IService
{
    public interface IPromocionServices
    {
        public Task<List<Promocion>> GetPromotion();
        public Task<Promocion> GetByIdPromotion(int id);
        public Task<Promocion> CreatePromotion(Promocion i);
        public bool EliminarPromotion(int id);
        public Task<Promocion> EditarPromotion(Promocion O);
    }
}
