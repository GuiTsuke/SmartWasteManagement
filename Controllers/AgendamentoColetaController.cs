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
    public class AgendamentoColetaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRotaService _rotaService;
        private readonly IRecipienteService _recipienteService;
        private readonly IAgendamentoColetaService _agendamentoColetaService;

        public AgendamentoColetaController(IMapper mapper, IRotaService rotaService, IRecipienteService recipienteService, IAgendamentoColetaService agendamentoColetaService)
        {
            _mapper = mapper;
            _rotaService = rotaService;
            _recipienteService = recipienteService;
            _agendamentoColetaService = agendamentoColetaService;
        }

        // GET: AgendamentoColeta
        public IActionResult Index()
        {
            var agendamentos = _agendamentoColetaService.ListarAgendamentosColeta();
            var viewModels = _mapper.Map<IEnumerable<AgendamentoColetaViewModel>>(agendamentos);
            return View(viewModels);
        }

        // GET: AgendamentoColeta/Details/5
        public IActionResult Details(int id)
        {

            var agendamento = _agendamentoColetaService.ObterAgendamentoPorId(id);            
            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoColetaModel = _mapper.Map<AgendamentoColetaViewModel>(agendamento);
            return View(agendamentoColetaModel);
        }

        // GET: AgendamentoColeta/Create
        public IActionResult Create()
        {
            var rotas = _rotaService.ListarRotas();
            var rotasViewModels = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            var recipientes = _recipienteService.ListarRecipientes();
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);

            var viewModel = new AgendamentoColetaViewModel();
            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Endereco");
            ViewData["CodigoRota"] = new SelectList(rotasViewModels, "Codigo", "PontosColeta");
            return View(viewModel);
        }

        // POST: AgendamentoColeta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(AgendamentoColetaViewModel agendamentoColetaModel)
        {
            var agendamento = _mapper.Map<AgendamentoColetaModel>(agendamentoColetaModel);
            if (ModelState.IsValid)
            {
                _agendamentoColetaService.CriarAgendamento(agendamento);
                return RedirectToAction(nameof(Index));
            }
            var rotas = _rotaService.ListarRotas();
            var rotasViewModels = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            var recipientes = _recipienteService.ListarRecipientes();
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);
                                    
            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Endereco", agendamentoColetaModel.CodigoRecipiente);
            ViewData["CodigoRota"] = new SelectList(rotasViewModels, "Codigo", "PontosColeta", agendamentoColetaModel.CodigoRota);
            return View(agendamentoColetaModel);
        }

        // GET: AgendamentoColeta/Edit/5
        public IActionResult Edit(int id)
        {
            var agendamentoColetaModel = _agendamentoColetaService.ObterAgendamentoPorId(id);
            if (agendamentoColetaModel == null)
            {
                return NotFound();
            }
            var rotas = _rotaService.ListarRotas();
            var rotasViewModels = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            var recipientes = _recipienteService.ListarRecipientes();
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);

            var agendamentoViewModel = _mapper.Map<AgendamentoColetaViewModel>(agendamentoColetaModel);

            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Endereco", agendamentoViewModel.CodigoRecipiente);
            ViewData["CodigoRota"] = new SelectList(rotasViewModels, "Codigo", "PontosColeta", agendamentoViewModel.CodigoRota);
            return View(agendamentoViewModel);
        }

        // POST: AgendamentoColeta/Edit/5        
        [HttpPost]
        public IActionResult Edit(AgendamentoColetaViewModel agendamentoColetaModel)
        {
            var agendamento = _mapper.Map<AgendamentoColetaModel>(agendamentoColetaModel);
            if (ModelState.IsValid)
            {
                try
                {
                    _agendamentoColetaService.AtualizarAgendamento(agendamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoColetaModelExists(agendamentoColetaModel.Codigo))
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
            var rotas = _rotaService.ListarRotas();
            var rotasViewModels = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            var recipientes = _recipienteService.ListarRecipientes();
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);

            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Endereco", agendamentoColetaModel.CodigoRecipiente);
            ViewData["CodigoRota"] = new SelectList(rotasViewModels, "Codigo", "PontosColeta", agendamentoColetaModel.CodigoRota);
            return View(agendamentoColetaModel);
        }

        // GET: AgendamentoColeta/Delete/5
        public IActionResult Delete(int id)
        {

            var agendamento = _agendamentoColetaService.ObterAgendamentoPorId(id);           
            if (agendamento == null)
            {
                return NotFound();
            }
            var agendamentoColetaModel = _mapper.Map<AgendamentoColetaViewModel>(agendamento);
            return View(agendamentoColetaModel);
        }

        // POST: AgendamentoColeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var agendamento = _agendamentoColetaService.ObterAgendamentoPorId(id);
            if (agendamento != null)
            {
                _agendamentoColetaService.DeletarAgendamento(agendamento.Codigo);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoColetaModelExists(int id)
        {
            return _agendamentoColetaService.ListarAgendamentosColeta().Any(e => e.Codigo == id);
        }
    }
}
