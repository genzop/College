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
    public class ControladorDomicilio : IDisposable
    {

        private SQLiteConnection conexion;

        public ControladorDomicilio()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Domicilios.db3"));
            conexion.CreateTable<Domicilio>();
        }

        public void Insert(Domicilio dom)
        {
            conexion.Insert(dom);
        }

        public void Update(Domicilio dom)
        {
            conexion.Update(dom);
        }

        public void Delete(Domicilio dom)
        {
            conexion.Delete(dom);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Domicilio>();
        }

        public Domicilio FindById(int id)
        {
            var domicilio = (from dom in conexion.Table<Domicilio>()
                             where dom.IdDomicilio == id
                             select dom).FirstOrDefault();
            return domicilio;
        }

        public List<Domicilio> ShowAll()
        {
            var domicilios = (from dom in conexion.Table<Domicilio>()
                              orderby dom.IdDomicilio
                              select dom).ToList();
            return domicilios;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
