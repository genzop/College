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
    public class ControladorVendedor : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorVendedor()
        {
            //Se configuran la plataforma y la ubicaion de la base de datos
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Vendedores.db3"));

            //Se crea la tabla de Vendedores
            conexion.CreateTable<Vendedor>();
        }

        public void Insert(Vendedor vend)
        {
            conexion.Insert(vend);
        }

        public void Update(Vendedor vend)
        {
            conexion.Update(vend);
        }

        public void Delete(Vendedor vend)
        {
            conexion.Delete(vend);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Vendedor>();
        }

        public Vendedor FindById(int id)
        {
            var vendedor = (from vend in conexion.Table<Vendedor>()
                            where vend.IdVendedor == id
                            select vend).FirstOrDefault();
            return vendedor;
        }

        public Vendedor FindByUser(string user)
        {
            var vendedor = (from vend in conexion.Table<Vendedor>()
                            where vend.Usuario == user
                            select vend).FirstOrDefault();
            return vendedor;
        }

        public List<Vendedor> ShowAll()
        {
            var vendedores = (from vend in conexion.Table<Vendedor>()
                              orderby vend.IdVendedor
                              select vend).ToList();
            return vendedores;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
