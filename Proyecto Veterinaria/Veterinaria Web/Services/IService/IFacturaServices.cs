using Veterinaria_Web.Models.Entities;

namespace Veterinaria_Web.Services.IService
{
    public interface IFacturaServices
    {
        public Task<List<Factura>> GetAll();
        public Task<Factura> GetByIdFactura(int id);
        public Task<Factura> CrearFacturas(Factura i);
        public bool DeleteFactura(int id);
        public Task<Factura> EditarFactura(Factura O);
    }
}
