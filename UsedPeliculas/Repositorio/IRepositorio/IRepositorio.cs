using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsedPeliculas.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        //Empezamos a crear los metodos generales
        // Con este metodo traemos la lista de las categorias, peliculas y usuarios
        Task<IEnumerable> GetTodoAsync(string url);
        Task<T> GetAsync(string url, int Id);
        //Metodo para crear peliculas y categorias
        Task<bool> CrearAsync(string url, T itemCrear);
        //Metodo para actualizar peliculas y categorias
        Task<bool> ActualizarAsync(string url, T itemActualizar);
        //Metodo para borra peliculas y categorias
        Task<bool> BorrarAsync(string url, int Id);
    }
}
