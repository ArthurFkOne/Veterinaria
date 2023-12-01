using Veterinaria_Web.Models.Entities;

namespace Veterinaria_Web.Services.IService
{
    public interface IUsuariosServices
    {
        public Task<List<Usuario>> GetAll();
        public Task<Usuario> Crear(Usuario i);
        public Task<Usuario> GetByIdUsuario(int id);
        public Task<Usuario> EditarUsuario(Usuario i);
        public bool DeleteUsuario(int id);
    }
}
