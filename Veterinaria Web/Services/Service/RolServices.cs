using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Services.Service
{
    public class RolServices : IRolServices
    {

        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetAll()
        {
            try
            {

                var response = await _context.Roles.ToListAsync();
                return response;

            }
            catch (Exception ex)
            {


                throw;

            }
        }


        public async Task<Rol> GetByIdRol(int id)
        {
            try
            {
                //Articulo response = await _context.Articulo.FindAsync(id);
                Rol response = await _context.Roles.FirstOrDefaultAsync(x => x.PkRoles == id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Rol> CrearRol(Rol i)
        {
            try
            {
                Rol request = new Rol()
                {
                    Nombre = i.Nombre,
                    PkRoles = i.PkRoles,
                };
                var result = await _context.Roles.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public bool EliminarRol(int id)
        {
            try
            {
                Rol RolesToDelete = _context.Roles.Find(id);

                if (RolesToDelete != null)
                {
                    var res = _context.Roles.Remove(RolesToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else

                {
                    throw new Exception("El libro no existe");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }
        public async Task<Rol> EditarRol(Rol O)
        {
            try
            {

                 
                /*
                 _context.Entry(rol).State = EntityState.Modified;
                 await _context.SaveChangesAsync();*/
               

                using(var context = _context)
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@idr", O.PkRoles, DbType.Int32);
                    parametros.Add("@Nombrer", O.Nombre, DbType.String);
                     _context.Database.GetDbConnection().ExecuteAsync("SpEditarRol", parametros,
                    commandType: CommandType.StoredProcedure);
                }


                
                await _context.SaveChangesAsync(); 
                return O;


              

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }

    }



}
