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
    public class ControladorPedido : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorPedido()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Pedidos.db3"));
            conexion.CreateTable<Pedido>();
        }

        public void Insert(Pedido ped)
        {
            conexion.Insert(ped);
        }

        public void Update(Pedido ped)
        {
            conexion.Update(ped);
        }

        public void Delete(Pedido ped)
        {
            conexion.Delete(ped);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Pedido>();
        }

        public Pedido FindById(int id)
        {
            var pedido = (from ped in conexion.Table<Pedido>()
                          where ped.IdPedido == id
                          select ped).FirstOrDefault();
            return pedido;
        }

        public List<Pedido> FindByVendedor(int idVendedor)
        {
            var pedido = (from ped in conexion.Table<Pedido>()
                          where ped.IdVendedor == idVendedor
                          select ped).ToList();
            return pedido;
        }

        public List<Pedido> FindByVendedorAndRazonSocial(int idVendedor, string cliente)
        {
            var pedido = (from ped in conexion.Table<Pedido>()
                          where ped.IdVendedor == idVendedor && ped.Cliente.Contains(cliente)
                          select ped).ToList();
            return pedido;
        }

        public List<Pedido> FindForExport(int idVendedor)
        {
            var pedidos = (from ped in conexion.Table<Pedido>()
                           where ped.IdVendedor == idVendedor && ped.Editable == true
                           select ped).ToList();
            return pedidos;
        }

        public List<Pedido> ShowAll()
        {
            var pedidos = (from ped in conexion.Table<Pedido>()
                           orderby ped.IdPedido
                           select ped).ToList();
            return pedidos;
        }

        public int LastID()
        {
            var pedido = (from ped in conexion.Table<Pedido>()
                          orderby ped.IdPedido
                          select ped).LastOrDefault();
            return pedido.IdPedido;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
