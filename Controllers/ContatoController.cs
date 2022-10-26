using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Persistence;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly Context _context;

        public ContatoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if(ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
                _context.Contatos.Update(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);

            if(contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if(contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

       [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoDb = _context.Contatos.Find(contato.Id);

            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}