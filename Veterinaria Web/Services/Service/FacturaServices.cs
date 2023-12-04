using Microsoft.EntityFrameworkCore;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Services.Service
{
    public class FacturaServices:IFacturaServices
    {
        private readonly ApplicationDbContext _context;

        public FacturaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Factura> CrearFacturas(Factura i)
        {
            try
            {

                Factura request = new Factura()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    Correo= i.Correo,
                    Identificador= i.Identificador,
                    Total= i.Total,
                    
                };

                var response = await _context.Facturas.AddAsync(request);
                _context.SaveChanges();
                return request;

            }
            catch (Exception ex)
            {


                throw;

            }
        }

        public async Task<List<Factura>> GetAll()
        {
            try
            {

                var response = await _context.Facturas.ToListAsync();
                return response;

            }
            catch (Exception ex)
            {


                throw new Exception("Surgio un error" + ex.Message);

            }
        }


        public async Task<Factura> GetByIdFactura(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Factura response = await _context.Facturas.FirstOrDefaultAsync(x => x.PkFactura == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }


        public async Task<Factura> EditarFactura(Factura i)
        {
            try
            {

                Factura Usuario = _context.Facturas.Find(i.PkFactura);

                Usuario.Nombre = i.Nombre;
                Usuario.Apellido = i.Apellido;
                Usuario.Correo= i.Correo;
                Usuario.Identificador= i.Identificador;


                _context.Entry(Usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }


        public bool DeleteFactura(int id)
        {

            try
            {
                Factura libros = _context.Facturas.Find(id);

                if (libros != null)
                {


                    var res = _context.Facturas.Remove(libros);
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
