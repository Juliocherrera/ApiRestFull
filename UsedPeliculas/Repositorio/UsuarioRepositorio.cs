﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UsedPeliculas.Models;
using UsedPeliculas.Repositorio.IRepositorio;

namespace UsedPeliculas.Repositorio
{
    public class UsuarioRepositorio : Repositorio<UsuarioU>, IUsuarioRepositorio
    {
        //Inyección de dependencias, se debe importar el IHttpClientFactory
        private readonly IHttpClientFactory _clientFactory;

        public UsuarioRepositorio(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
