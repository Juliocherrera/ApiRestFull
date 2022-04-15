using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsedPeliculas.Utilidades
{
    public static class CT
    {
        //Creamos la ruta principal
        public static string UrlBaseApi = "https://localhost:44367/";

        //Ahora aqui vamos a crear las constantes para las demas direcciones
        public static string RutaCategoriasApi = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/tiposCfds";
        public static string RutaCategoriasApi2 = "https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis/cancelar?motivo=02&uuid=";
        public static string RutaPeliculasApi = UrlBaseApi + "api/Peliculas/";
        public static string RutaUsuariosApi = UrlBaseApi + "api/Usuarios/";
        public static string RutaCategoApi = UrlBaseApi + "api/Categorias/";

        //Faltan otras rutas para buscar y filtrar peliculas por categoria
    }
}
