using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoFinalApp.Modelo;
using Xamarin.Forms;

namespace TrabajoFinalApp.Controladores
{
    public class ControladorPedidoVentaDetalle : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorPedidoVentaDetalle()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "PedidoVentaDetalles.db3"));
            conexion.CreateTable<PedidoVentaDetalle>();
        }

        public void Insert(PedidoVentaDetalle det)
        {
            conexion.Insert(det);
        }

        public void Update(PedidoVentaDetalle det)
        {
            conexion.Update(det);
        }

        public void Delete(PedidoVentaDetalle det)
        {
            conexion.Delete(det);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<PedidoVentaDetalle>();
        }

        public PedidoVentaDetalle FindById(int id)
        {
            var pedidoVentaDetalle = (from det in conexion.Table<PedidoVentaDetalle>()
                                      where det.IdPedidoVentaDetalle == id
                                      select det).FirstOrDefault();
            return pedidoVentaDetalle;
        }

        public List<PedidoVentaDetalle> FindByPedidoVenta(int pedidoVenta)
        {
            var pedidos = (from det in conexion.Table<PedidoVentaDetalle>()
                           where det.IdPedidoVenta == pedidoVenta
                           select det).ToList();
            return pedidos;
        }

        public List<PedidoVentaDetalle> ShowAll()
        {
            var pedidoVentaDetalles = (from det in conexion.Table<PedidoVentaDetalle>()
                                       orderby det.IdPedidoVentaDetalle
                                       select det).ToList();
            return pedidoVentaDetalles;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }

    }
}
