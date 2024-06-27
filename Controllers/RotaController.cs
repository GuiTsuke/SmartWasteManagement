using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;
using AutoMapper;
using Fiap.Web.SmartWasteManagement.Services;
using Fiap.Web.SmartWasteManagement.ViewModels;

namespace Fiap.Web.SmartWasteManagement.Controllers
{
    public class RotaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRotaService _rotaService;
        private readonly ICaminhaoService _caminhaoService;

        public RotaController(IMapper mapper, IRotaService rotaService, ICaminhaoService caminhaoService)
        {
            _mapper = mapper;
            _rotaService = rotaService;
            _caminhaoService = caminhaoService;
        }

        // GET: Rota
        public IActionResult Index()
        {
            var rotas = _rotaService.ListarRotas();
            var viewModels = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            return View(viewModels);
        }

        // GET: Rota/Details/5
        public IActionResult Details(int id)
        {
            var rota = _rotaService.ObterRotaPorId(id);
            if (rota == null)
            {
                return NotFound();
            }

            var rotaModel = _mapper.Map<RotaViewModel>(rota);
            return View(rotaModel);
        }

        // GET: Rota/Create
        public IActionResult Create()
        {

            var caminhoes = _caminhaoService.ListarCaminhoes();
            var caminhoesViewModels = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);

            var viewModel = new RotaViewModel();

            ViewData["CodigoCaminhao"] = new SelectList(caminhoesViewModels, "Codigo", "Placa");
            return View(viewModel);
        }

        // POST: Rota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(RotaViewModel rotaModel)
        {

            if (ModelState.IsValid)
            {
                var rota = _mapper.Map<RotaModel>(rotaModel);

                _rotaService.CriarRota(rota);
                return RedirectToAction(nameof(Index));
            }
            var caminhoes = _caminhaoService.ListarCaminhoes();
            var caminhoesViewModels = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);

            ViewData["CodigoCaminhao"] = new SelectList(caminhoesViewModels, "Codigo", "Placa", rotaModel.CodigoCaminhao);
            return View(rotaModel);
        }

        // GET: Rota/Edit/5
        public IActionResult Edit(int id)
        {
            var rotaModel = _rotaService.ObterRotaPorId(id);
            if (rotaModel == null)
            {
                return NotFound();
            }

            var caminhoes = _caminhaoService.ListarCaminhoes();
            var caminhoesViewModels = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);

            var rota = _mapper.Map<RotaViewModel>(rotaModel);

            ViewData["CodigoCaminhao"] = new SelectList(caminhoesViewModels, "Codigo", "Placa", rota.CodigoCaminhao);
            return View(rota);
        }

        // POST: Rota/Edit/5        
        [HttpPost]        
        public IActionResult Edit(RotaViewModel rotaModel)
        {
            var rota = _mapper.Map<RotaModel>(rotaModel);
            if (ModelState.IsValid)
            {
                try
                {
                    _rotaService.AtualizarRota(rota);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotaModelExists(rotaModel.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var caminhoes = _caminhaoService.ListarCaminhoes();
            var caminhoesViewModels = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);

            ViewData["CodigoCaminhao"] = new SelectList(caminhoesViewModels, "Codigo", "Placa", rotaModel.CodigoCaminhao);
            return View(rotaModel);
        }

        // GET: Rota/Delete/5
        public IActionResult Delete(int id)
        {
            var rotaModel = _rotaService.ObterRotaPorId(id);
            if (rotaModel == null)
            {
                return NotFound();
            }

            var rota = _mapper.Map<RotaViewModel>(rotaModel);
            return View(rota);
        }

        // POST: Rota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rotaModel = _rotaService.ObterRotaPorId(id);
            if (rotaModel != null)
            {
               _rotaService.DeletarRota(rotaModel.Codigo);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RotaModelExists(int id)
        {
            return _rotaService.ListarRotas().Any(e => e.Codigo == id);
        }
    }
}
