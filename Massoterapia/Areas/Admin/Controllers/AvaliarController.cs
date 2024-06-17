using Massoterapia.Data;
using Massoterapia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Massoterapia.Areas.Admin.Controllers
{
    public class AvaliarController : AdminController
    {
        BancoDados _bancoDados;
        IWebHostEnvironment _servidorWeb;
        public IActionResult Index()
        {
            _bancoDados = new BancoDados();
            var avaliacao = _bancoDados.Avaliacaos.Include(e => e.tratamento).ToList();

            return View(avaliacao);
        }

        [HttpGet]
        public IActionResult Inclui(int idtratamento)
        {
            _bancoDados = new BancoDados();
            var avaliar1 = _bancoDados.Avaliacaos.FirstOrDefault(e =>e.IdTratamento == idtratamento);
            if (avaliar1 == null)
            {
               
                var tratamento = _bancoDados.Tratamentos.Where(e => e.Id == idtratamento).ToList();
                Avaliacao avaliacao = new Avaliacao();
                ViewBag.tratamento = new SelectList(tratamento, "Id", "TecnicaTratamento", avaliacao.IdTratamento);
                return View(avaliacao);
            }
            return RedirectToAction("Exibe", new { Id = avaliar1.Id} ); 

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inclui(Avaliacao avaliacao)
        {
            //faz a inclusao no banco 
            _bancoDados = new BancoDados();

            _bancoDados.Add(avaliacao);
            _bancoDados.SaveChanges();
            //volta para o inicio
            return RedirectToAction("Index", "Tratamento");
        }
        [HttpGet]
        public IActionResult Exibe(int id)
        {
            if (id > 0)
            {
                //faz a busca pelo id do usuario
                _bancoDados = new BancoDados();
                var avalia = _bancoDados.Avaliacaos.Include(e => e.tratamento).FirstOrDefault(e => e.Id == id);

                return View(avalia);
            }
            return null;
        }

        [HttpGet]
        public IActionResult Altera(int id)
        {
            if (id >0)
            {
                //faz a busca pelo id do usuario
                _bancoDados = new BancoDados();
                var avaliacao = _bancoDados.Avaliacaos.Include(e => e.tratamento).FirstOrDefault(e => e.Id == id);
                var tratamento = _bancoDados.Tratamentos.Where(e => e.Id == avaliacao.IdTratamento).ToList();
                ViewBag.tratamento = new SelectList(tratamento, "Id", "TecnicaTratamento", avaliacao.IdTratamento);
                return View(avaliacao);
            }
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Altera(Avaliacao avaliacao)
       {
            //inicia o banco de dados
            _bancoDados = new BancoDados();
            //atualiza o usuario
            _bancoDados.Avaliacaos.Update(avaliacao);
            //executa o comando
            _bancoDados.SaveChanges();
            return RedirectToAction("Index", "Tratamento");
        }


        
        [HttpGet]
        public IActionResult ExibiAvaliacao(int idtratamento)
        {
            _bancoDados = new BancoDados();
            var avaliar1 = _bancoDados.Avaliacaos.FirstOrDefault(e => e.IdTratamento == idtratamento);
            if (avaliar1 == null)
            {
                return RedirectToAction("Index", "Tratamento");
            }
            var avalia = _bancoDados.Avaliacaos.Include(e => e.tratamento).FirstOrDefault(e => e.IdTratamento == idtratamento);

            return View(avalia);

        }
    }
}
