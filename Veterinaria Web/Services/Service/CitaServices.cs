using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Services.Service
{
    public class CitaServices :ICitaServices
    {

        
            private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _webHost;
            private readonly IHttpContextAccessor _httpContext;

            public CitaServices(ApplicationDbContext context, IHttpContextAccessor httpContext, IWebHostEnvironment webHost)

            {
                _httpContext = httpContext;
                _webHost = webHost;
                _context = context;
                //variable privada
            }
            public async Task<List<Citas>> GetCitas()
            {
                try
                {
                    //List<Articulo> articulos = await _context.Articulo.ToListAsync();
                    //return articulos;
                    var response = await _context.Database.GetDbConnection().QueryAsync<Citas>("SpGetCitas", new { }, commandType: CommandType.StoredProcedure);

                    return response.ToList();
                }
                catch (Exception ex)
                {

                    throw new Exception("Surgió un error" + ex.Message);
                }

            }

            public async Task<Citas> GetByIdCita(int id)
            {
                try
                {
                    //Articulo response = await _context.Articulo.FindAsync(id);
                    Citas response = await _context.Cita.FirstOrDefaultAsync(x => x.PkCita == id);
                    return response;
                }
                catch (Exception ex)
                {

                    throw new Exception("Surgió un error" + ex.Message);
                }
            }

        public async Task<Citas> CrearCita(Citas i)
        {
            try
            {


                Citas request = new Citas()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    Correo = i.Correo,
                    Fecha = i.Fecha,
                    Nombreanimal = i.Nombreanimal,
                    Animal= i.Animal,
                    Servicio = i.Servicio,
                    Numero = i.Numero,
                };
              
                var result = await _context.Cita.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public bool EliminarCita(int id)
            {
                try
                {
                    Citas citaToDelete = _context.Cita.Find(id);

                    if (citaToDelete != null)
                    {
                        var res = _context.Cita.Remove(citaToDelete);
                        _context.SaveChanges();
                        return true;
                    }
                    else

                    {
                        throw new Exception("La cita no existe");
                    }

                }
                catch (Exception ex)
                {

                    throw new Exception("Surgió un error" + ex.Message);
                }
            }

            public async Task<Citas> EditarCita(Citas O)
            {
                try
                {

                    Citas res = _context.Cita.Find(O.PkCita);

                    res.Nombre = O.Nombre;
                    res.Apellido = O.Apellido;
                    res.Correo = O.Correo;
                    res.Fecha = O.Fecha;
                    res.Nombreanimal = O.Nombreanimal;
                    res.Animal = O.Animal;


                    _context.Entry(res).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return res;

                }
                catch (Exception ex)
                {
                    throw new Exception("Succedio un error " + ex.Message);
                }
            }


          
        }

    
}
