using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsedPeliculas.Models;
using UsedPeliculas.Repositorio.IRepositorio;
using UsedPeliculas.Utilidades;

namespace UsedPeliculas.Controllers
{
    public class CategoriasController : Controller
    {
        //Hacemos la instancia de ICategoriaRepositorio
        private readonly ICategoriaRepositorio _repoCategoria;
        public CategoriasController(ICategoriaRepositorio repoCategoria)
        {
            _repoCategoria = repoCategoria;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Categoria() { });
        }
        [HttpGet]
        public async Task<IActionResult> GetTodasCategorias()
        {
            return Json(new { data = await _repoCategoria.GetTodoAsync(CT.RutaCategoriasApi)});
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _repoCategoria.CrearAsync(CT.RutaCategoriasApi, categoria);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Categoria itemCategoria = new Categoria();
            if (id == null)
            {
                return NotFound();
            }
            itemCategoria = await _repoCategoria.GetAsync(CT.RutaCategoriasApi, id.GetValueOrDefault());
            if (itemCategoria == null)
            {
                return NotFound();
            }

            return View(itemCategoria);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _repoCategoria.BorrarAsync(CT.RutaCategoriasApi2, id);

            if (status)
            {
                return Json(new { success = true, message = "Cancelado correctamente" });
            }

            return Json(new { success = false, message = "No se pudo borrar" });
        }
    }
}
