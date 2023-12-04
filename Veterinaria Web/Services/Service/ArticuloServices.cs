using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Veterinaria_Web.Context;
using Veterinaria_Web.Models.Entities;
using Veterinaria_Web.Services.IService;

namespace Veterinaria_Web.Services.Service
{
    public class ArticuloServices : IArticuloServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _httpContext;

        public ArticuloServices(ApplicationDbContext context, IHttpContextAccessor httpContext, IWebHostEnvironment webHost)

        {
            _httpContext = httpContext;
            _webHost = webHost;
            _context = context;
            //variable privada
        }
        public async Task<List<Articulo>> GetArticulos()
        {
            try
            {
                //List<Articulo> articulos = await _context.Articulo.ToListAsync();
                //return articulos;
                var response = await _context.Database.GetDbConnection().QueryAsync<Articulo>("SpGetArticulos", new { }, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }

        }

        public async Task<Articulo> GetByIdArticulo(int id)
        {
            try
            {
                //Articulo response = await _context.Articulo.FindAsync(id);
                Articulo response = await _context.Articulo.FirstOrDefaultAsync(x => x.PKArticulo == id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Articulo> CrearArticulo(Articulo i)
        {
            try
            {
                var urlImagen = i.Img.FileName;
                i.UrlImagenPath = @"Img/Articulos/" + urlImagen;

                Articulo request = new Articulo()
                {
                    Nombre = i.Nombre,
                    Descripcion = i.Descripcion,
                    Precio = i.Precio,
                    Cantidad = i.Cantidad,
                    UrlImagenPath = i.UrlImagenPath,
                };
                SubirImg(urlImagen);
                var result = await _context.Articulo.AddAsync(request);
                _context.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public bool EliminarArticulo(int id)
        {
            try
            {
                Articulo articuloToDelete = _context.Articulo.Find(id);

                if (articuloToDelete != null)
                {
                    var res = _context.Articulo.Remove(articuloToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else

                {
                    throw new Exception("El artículo no existe");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Surgió un error" + ex.Message);
            }
        }

        public async Task<Articulo> EditarArticulo(Articulo O)
        {
            try
            {

                Articulo articulo = _context.Articulo.Find(O.PKArticulo);

                articulo.Nombre = O.Nombre;
                articulo.Descripcion = O.Descripcion;
                articulo.Cantidad = O.Cantidad;
                articulo.Precio = O.Precio;


                _context.Entry(articulo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return articulo;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }


        public bool SubirImg(string Img)
        {
            bool res = false;

            try
            {
                string rutaprincipal = _webHost.WebRootPath;
                var archivos = _httpContext.HttpContext.Request.Form.Files;

                if (archivos.Count > 0 && !string.IsNullOrEmpty(archivos[0].FileName))
                {

                    var nombreArchivo = Img;
                    var subidas = Path.Combine(rutaprincipal, "Img", "articulos");

                    // Asegurarse de que el directorio de destino exista
                    if (!Directory.Exists(subidas))
                    {
                        Directory.CreateDirectory(subidas);
                    }

                    var rutaCompleta = Path.Combine(subidas, nombreArchivo);

                    using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStream);
                        res = true;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al subir la imagen: {ex.Message}");
            }

            return res;
        }
    }
}