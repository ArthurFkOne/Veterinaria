using Microsoft.EntityFrameworkCore;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Services.Service
{
    public class UsuariosServices : IUsuariosServices
    {


        private readonly ApplicationDbContext _context;

        public UsuariosServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Crear(Usuario i)
        {
            try
            {

                Usuario request = new Usuario()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    UserName = i.UserName,
                    Password = i.Password,
                    FkRol = i.FkRol,
                };

                var response = await _context.Usuarios.AddAsync(request);
                _context.SaveChanges();
                return request;

            }
            catch (Exception ex)
            {


                throw;

            }
        }

        public async Task<List<Usuario>> GetAll()
        {
            try
            {

                var response = await _context.Usuarios.Include(k=>k.Roles).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {


                throw new Exception("Surgio un error" + ex.Message);

            }
        }


        public async Task<Usuario> GetByIdUsuario(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Usuario response = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }


        public async Task<Usuario> EditarUsuario(Usuario i)
        {
            try
            {

                Usuario Usuario = _context.Usuarios.Find(i.PkUsuario);

                Usuario.Nombre = i.Nombre;
                Usuario.Apellido = i.Apellido;
                Usuario.UserName = i.UserName;
                Usuario.Password = i.Password;
                Usuario.FkRol = i.FkRol;


                _context.Entry(Usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }


         public bool DeleteUsuario(int id)
        {

            try
            {
                Usuario libros = _context.Usuarios.Find(id);

                if (libros != null)
                {


                    var res = _context.Usuarios.Remove(libros);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;

                }


            }
            catch (Exception ex)
            {

                new Exception("Sucedio un error " + ex.Message);

                return false;

            }
        }

    }
}
