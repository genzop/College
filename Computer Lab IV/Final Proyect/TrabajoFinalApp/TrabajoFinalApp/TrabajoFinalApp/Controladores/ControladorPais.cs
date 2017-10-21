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
    public class ControladorPais : IDisposable
    {
        private SQLiteConnection conexion;

        public ControladorPais()
        {
            var config = DependencyService.Get<IConfig>();
            conexion = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Paises.db3"));
            conexion.CreateTable<Pais>();
        }

        public void Insert(Pais pais)
        {
            conexion.Insert(pais);
        }

        public void Update(Pais pais)
        {
            conexion.Update(pais);
        }

        public void Delete(Pais pais)
        {
            conexion.Delete(pais);
        }

        public void DeleteAll()
        {
            conexion.DeleteAll<Pais>();
        }

        public Pais FindById(int id)
        {
            var pais = (from p in conexion.Table<Pais>()
                        where p.IdPais == id
                        select p).FirstOrDefault();
            return pais;
        }

        public Pais FindLast()
        {
            var pais = (from p in conexion.Table<Pais>()
                        orderby p.IdPais
                        select p).LastOrDefault();
            return pais;
        }

        public List<Pais> ShowAll()
        {
            var paises = (from pais in conexion.Table<Pais>()
                               orderby pais.IdPais
                               select pais).ToList();
            return paises;
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
