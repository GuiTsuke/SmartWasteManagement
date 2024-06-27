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
    public class RecipienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMoradorService _moradorService;
        private readonly IRecipienteService _recipienteService;

        public RecipienteController(IMapper mapper, IRecipienteService recipienteService, IMoradorService moradorService)
        {
            _mapper = mapper;
            _recipienteService = recipienteService;
            _moradorService = moradorService;
        }

        // GET: Recipiente
        public IActionResult Index()
        {
            var recipientes = _recipienteService.ListarRecipientes();
            var viewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);
            return View(viewModels);
        }

        // GET: Recipiente/Details/5
        public IActionResult Details(int id)
        {
            var recipienteModel = _recipienteService.ObterRecipientePorId(id);
            if (recipienteModel == null)
            {
                return NotFound();
            }
            var recipiente = _mapper.Map<RecipienteViewModel>(recipienteModel);
            return View(recipiente);
        }

        // GET: Recipiente/Create
        public IActionResult Create()
        {
            var moradores = _moradorService.ListarMoradores();
            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);

            var viewModel = new RecipienteViewModel();

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo");
            return View(viewModel);
        }

        // POST: Recipiente/Create        
        [HttpPost]
        public IActionResult Create(RecipienteViewModel recipienteModel)
        {
            var recipiente = _mapper.Map<RecipienteModel>(recipienteModel);
            if (ModelState.IsValid)
            {
                _recipienteService.CriarRecipiente(recipiente);
                return RedirectToAction(nameof(Index));
            }
            var moradores = _moradorService.ListarMoradores();
            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo", recipienteModel.CodigoMorador);
            return View(recipienteModel);
        }

        // GET: Recipiente/Edit/5
        public IActionResult Edit(int id)
        {
            var recipienteModel = _recipienteService.ObterRecipientePorId(id);
            if (recipienteModel == null)
            {
                return NotFound();
            }
            var recipiente = _mapper.Map<RecipienteViewModel>(recipienteModel);
            var moradores = _moradorService.ListarMoradores();
            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo", recipiente.CodigoMorador);
            return View(recipiente);
        }

        // POST: Recipiente/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecipienteViewModel recipienteModel)
        {
            var recipiente = _mapper.Map<RecipienteModel>(recipienteModel);
            if (ModelState.IsValid)
            {
                try
                {
                    _recipienteService.AtualizarRecipiente(recipiente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipienteModelExists(recipienteModel.Codigo))
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
            
            var moradores = _moradorService.ListarMoradores();
            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo", recipienteModel.CodigoMorador);
            return View(recipienteModel);
        }

        // GET: Recipiente/Delete/5
        public IActionResult Delete(int id)
        {
            var recipienteModel = _recipienteService.ObterRecipientePorId(id);            
            if (recipienteModel == null)
            {
                return NotFound();
            }
            var recipiente = _mapper.Map<RecipienteViewModel>(recipienteModel);
            return View(recipiente);
        }

        // POST: Recipiente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var recipienteModel = _recipienteService.ObterRecipientePorId(id);
            if (recipienteModel != null)
            {
                _recipienteService.DeletarRecipiente(recipienteModel.Codigo);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RecipienteModelExists(int id)
        {
            return _recipienteService.ListarRecipientes().Any(e => e.Codigo == id);
        }
    }
}
