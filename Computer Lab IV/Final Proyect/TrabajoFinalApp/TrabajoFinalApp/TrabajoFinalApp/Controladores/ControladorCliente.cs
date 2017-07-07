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
    public class ControladorCliente : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorCliente()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Clientes.db3"));
            conexion.CreateTable<Cliente>();
        }

        public void Insert(Cliente cli)
        {
            conexion.Insert(cli);
        }

        public void Update(Cliente cli)
        {
            conexion.Update(cli);
        }

        public void Delete(Cliente cli)
        {
            conexion.Delete(cli);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Cliente>();
        }

        public Cliente FindById(int id)
        {
            var cliente = (from cli in conexion.Table<Cliente>()
                           where cli.IdCliente == id
                           select cli).FirstOrDefault();
            return cliente;
        }

        public Cliente FindByRazonSocial(string razonSocial)
        {
            var cliente = (from cli in conexion.Table<Cliente>()
                           where cli.RazonSocial == razonSocial
                           select cli).FirstOrDefault();
            return cliente;
        }

        public List<Cliente> ShowAll()
        {
            var clientes = (from cli in conexion.Table<Cliente>()
                            orderby cli.IdCliente
                            select cli).ToList();
            return clientes;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
