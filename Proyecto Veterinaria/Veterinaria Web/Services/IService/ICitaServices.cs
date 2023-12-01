using Veterinaria_Web.Models.Entities;

namespace Veterinaria_Web.Services.IService
{
    public interface ICitaServices
    {

        public Task<List<Citas>> GetCitas();
        public Task<Citas> GetByIdCita(int id);
        public Task<Citas> CrearCita(Citas i);
        public bool EliminarCita(int id);
        public Task<Citas> EditarCita(Citas O);

    }
}
