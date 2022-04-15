using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UsedPeliculas.Models;
using UsedPeliculas.Repositorio.IRepositorio;

namespace UsedPeliculas.Repositorio
{
    public class CategoRepositorio : Repositorio<Catego>, ICategoRepositorio
    {
        private readonly IHttpClientFactory _clientFactory;

        public CategoRepositorio(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
