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
    public class ControladorDetalle : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorDetalle()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Detalles.db3"));
            conexion.CreateTable<Detalle>();
        }

        public void Insert(Detalle det)
        {
            conexion.Insert(det);
        }

        public void Update(Detalle det)
        {
            conexion.Update(det);
        }

        public void Delete(Detalle det)
        {
            conexion.Delete(det);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Detalle>();
        }

        public Detalle FindById(int id)
        {
            var pedidoVentaDetalle = (from det in conexion.Table<Detalle>()
                                      where det.IdDetalle == id
                                      select det).FirstOrDefault();
            return pedidoVentaDetalle;
        }

        public List<Detalle> FindByPedido(int idPedido)
        {
            var pedidos = (from det in conexion.Table<Detalle>()
                           where det.IdPedido == idPedido
                           select det).ToList();
            return pedidos;
        }

        public List<Detalle> ShowAll()
        {
            var pedidoVentaDetalles = (from det in conexion.Table<Detalle>()
                                       orderby det.IdDetalle
                                       select det).ToList();
            return pedidoVentaDetalles;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
