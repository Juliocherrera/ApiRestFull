using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UsedPeliculas.Models;
using UsedPeliculas.Repositorio.IRepositorio;
using UsedPeliculas.Utilidades;

namespace UsedPeliculas.Controllers
{
    public class CategosController : Controller
    {
        private readonly ICategoRepositorio _repoCatego;
        public CategosController(ICategoRepositorio repoCatego)
        {
            _repoCatego = repoCatego;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Catego() { });
        }
        [HttpGet]
        public async Task<IActionResult> GetTodasCategorias()
        {
            
            return Json(new
            {
                data = await _repoCatego.GetTodoAsync(CT.RutaCategoApi)

            });



        }

        //private void Insertj(Task<IEnumerable> datos)
        //{
        //    foreach (var item in datos)
        //    {

        //    }
        //}

        //[HttpPost]
        public JsonResult Insertj(List<Catego> datos)
        {
            foreach (var item in datos)
            {
                try
                {
                    //Console.WriteLine(item.Id);
                    //System.Diagnostics.Debug.WriteLine(item.Id);



                    string cadena = @"Data source=DESKTOP-CV57FOU\SQLEXPRESS; Initial Catalog=DBCARGA; User ID=jdev; Password=tdr123;Trusted_Connection=false;MultipleActiveResultSets=true";
                    //string connString = @"Data Source=localhost\sql2016;Initial Catalog=dwDev;Integrated Security=SSPI";
                    string sprocname = "InsertPerfCounterData";
                    //string paramName = "@json";
                    // Sample JSON string 
                    //string paramValue = "{\"dateTime\":\"2018-03-19T15:15:40.222Z\",\"dateTimeLocal\":\"2018-03-19T11:15:40.222Z\",\"cpuPctProcessorTime\":\"0\",\"memAvailGbytes\":\"28\"}";

                    using (SqlConnection conn = new SqlConnection(cadena))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(sprocname, conn))
                        {
                            // Set command object as a stored procedure
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameter that will be passed to stored procedure
                            cmd.Parameters.AddWithValue("@Id", item.Id);
                            cmd.Parameters.AddWithValue("@Nombre", item.Nombre);
                            cmd.Parameters.AddWithValue("@FechaCreacion", item.FechaCreacion);
                            //cmd.Parameters.Add(new SqlParameter(paramName, item));

                            cmd.ExecuteReader();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Json("");
        }
    }
   

     

}

