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
    public class MoradorController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IMoradorService _moradorService;

        public MoradorController(IMapper mapper, IMoradorService morador)
        {
            _mapper = mapper;
            _moradorService = morador;
        }

        // GET: Morador
        public IActionResult Index()
        {
            var moradores = _moradorService.ListarMoradores();
            var viewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);
            return View(viewModels);
        }

        // GET: Morador/Details/5
        public IActionResult Details(int id)
        {
            MoradorModel moradorModel = _moradorService.ObterMoradorPorId(id);
            if (moradorModel == null)
            {
                return NotFound();
            }

            var morador = _mapper.Map<MoradorViewModel>(moradorModel);

            return View(morador);
        }

        // GET: Morador/Create
        public IActionResult Create()
        {
            var viewModel = new MoradorViewModel();
            return View(viewModel);
        }

        // POST: Morador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MoradorViewModel moradorModel)
        {
            if (ModelState.IsValid)
            {
                var morador = _mapper.Map<MoradorModel>(moradorModel);

                _moradorService.CriarMorador(morador);
                return RedirectToAction(nameof(Index));
            }
            return View(moradorModel);
        }

        // GET: Morador/Edit/5
        public IActionResult Edit(int id)
        {
            var moradorModel = _moradorService.ObterMoradorPorId(id);
            if (moradorModel == null)
            {
                return NotFound();
            }

            var morador = _mapper.Map<MoradorViewModel>(moradorModel);
            return View(morador);
        }

        // POST: Morador/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MoradorViewModel moradorViewModel)
        {           
            if (ModelState.IsValid)
            {
                try
                {
                    var morador = _mapper.Map<MoradorModel>(moradorViewModel);
                    _moradorService.AtualizarMorador(morador);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorModelExists(moradorViewModel.Codigo))
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
            return View(moradorViewModel);
        }

        // GET: Morador/Delete/5
        public IActionResult Delete(int id)
        {
            var moradorModel = _moradorService.ObterMoradorPorId(id);
            if (moradorModel == null)
            {
                return NotFound();
            }

            var morador = _mapper.Map<MoradorViewModel>(moradorModel);
            return View(morador);
        }

        // POST: Morador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var moradorModel = _moradorService.ObterMoradorPorId(id);
            if (moradorModel != null)
            {
                _moradorService.DeletarMorador(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MoradorModelExists(int id)
        {
            return _moradorService.ListarMoradores().Any(e => e.Codigo == id);
        }
    }
}
