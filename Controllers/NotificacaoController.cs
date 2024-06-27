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
    public class NotificacaoController : Controller
    {
        private readonly IMapper _mapper;

        private readonly INotificacaoService _notificacaoService;
        private readonly IMoradorService _moradorService;
        private readonly IRecipienteService _recipienteService;

        public NotificacaoController(IMapper mapper, INotificacaoService notificacaoService, IMoradorService moradorService, IRecipienteService recipienteService)
        {
            _mapper = mapper;
            _notificacaoService = notificacaoService;
            _moradorService = moradorService;
            _recipienteService = recipienteService;
        }

        // GET: Notificacao
        public IActionResult Index()
        {
            var notificacao = _notificacaoService.ListarNotificacoes();
            var viewModels = _mapper.Map<IEnumerable<NotificacaoViewModel>>(notificacao);
            return View(viewModels);
        }

        // GET: Notificacao/Details/5
        public IActionResult Details(int id)
        {
            var notificacaoModel = _notificacaoService.ObterNotificacaoPorId(id);
            if (notificacaoModel == null)
            {
                return NotFound();
            }
            var notificacao = _mapper.Map<NotificacaoViewModel>(notificacaoModel);
            return View(notificacao);
        }

        // GET: Notificacao/Create
        public IActionResult Create()
        {
            var moradores = _moradorService.ListarMoradores();
            var recipientes = _recipienteService.ListarRecipientes();

            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);

            var viewModel = new NotificacaoViewModel();

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo");
            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Codigo");
            return View(viewModel);
        }

        // POST: Notificacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(NotificacaoViewModel notificacaoModel)
        {
            var viewModels = _mapper.Map<NotificacaoModel>(notificacaoModel);
            if (ModelState.IsValid)
            {
                _notificacaoService.CriarNotificacao(viewModels);
                return RedirectToAction(nameof(Index));
            }

            var moradores = _moradorService.ListarMoradores();
            var recipientes = _recipienteService.ListarRecipientes();

            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo", notificacaoModel.CodigoMorador);
            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Codigo", notificacaoModel.CodigoRecipiente);
            return View(notificacaoModel);
        }

        // GET: Notificacao/Edit/5
        public IActionResult Edit(int id)
        {
            var notificacaoModel = _notificacaoService.ObterNotificacaoPorId(id);
            if (notificacaoModel == null)
            {
                return NotFound();
            }

            var moradores = _moradorService.ListarMoradores();
            var recipientes = _recipienteService.ListarRecipientes();

            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);

            var viewModels = _mapper.Map<NotificacaoViewModel>(notificacaoModel);

            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo", viewModels.CodigoMorador);
            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Codigo", viewModels.CodigoRecipiente);
            return View(viewModels);
        }

        // POST: Notificacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NotificacaoViewModel notificacaoModel)
        {
            var viewModels = _mapper.Map<NotificacaoModel>(notificacaoModel);
            if (ModelState.IsValid)
            {
                try
                {
                   _notificacaoService.AtualizarNotificacao(viewModels);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacaoModelExists(notificacaoModel.Codigo))
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
            var recipientes = _recipienteService.ListarRecipientes();

            var moradoresViewModels = _mapper.Map<IEnumerable<MoradorViewModel>>(moradores);
            var recipientesViewModels = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);           


            ViewData["CodigoMorador"] = new SelectList(moradoresViewModels, "Codigo", "Codigo", notificacaoModel.CodigoMorador);
            ViewData["CodigoRecipiente"] = new SelectList(recipientesViewModels, "Codigo", "Codigo", notificacaoModel.CodigoRecipiente);
            return View(notificacaoModel);
        }

        // GET: Notificacao/Delete/5
        public IActionResult Delete(int id)
        {
            var notificacaoModel = _notificacaoService.ObterNotificacaoPorId(id);
            if (notificacaoModel == null)
            {
                return NotFound();
            }

            var notificacao = _mapper.Map<NotificacaoViewModel>(notificacaoModel);
            return View(notificacao);
        }

        // POST: Notificacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var notificacaoModel = _notificacaoService.ObterNotificacaoPorId(id);
            if (notificacaoModel != null)
            {
                _notificacaoService.DeletarNotificacao(notificacaoModel.Codigo);
            }

            
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoModelExists(int id)
        {
            return _notificacaoService.ListarNotificacoes().Any(e => e.Codigo == id);
        }
    }
}
