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
    public class ControladorArticulo : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorArticulo()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Articulos.db3"));
            conexion.CreateTable<Articulo>();
        }

        public void Insert(Articulo art)
        {
            conexion.Insert(art);
        }

        public void Update(Articulo art)
        {
            conexion.Update(art);
        }

        public void Delete(Articulo art)
        {
            conexion.Delete(art);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Articulo>();
        }

        public Articulo FindById(int id)
        {
            var articulo = (from art in conexion.Table<Articulo>()
                            where art.IdArticulo == id
                            select art).FirstOrDefault();
            return articulo;
        }

        public Articulo FindByName(string name)
        {
            var articulo = (from art in conexion.Table<Articulo>()
                            where art.Denominacion == name
                            select art).FirstOrDefault();
            return articulo;
        }

        public List<Articulo> ShowAll()
        {
            var articulos = (from art in conexion.Table<Articulo>()
                             orderby art.IdArticulo
                             select art).ToList();
            return articulos;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
