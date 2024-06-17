using Massoterapia.Data;
using Massoterapia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Linq;


namespace Massoterapia.Areas.Admin.Controllers
{
    public class TratamentoController : AdminController
    {
        BancoDados _bancoDados;
        IWebHostEnvironment _servidorWeb;

        
        public IActionResult Index()
            {
            _bancoDados = new BancoDados();
            Usuario usuario = new Usuario();
            usuario = _bancoDados.Usuarios.FirstOrDefault(e => e.Email == Convert.ToString(contaEmaill)); 

             
            if (usuario.Perfil == Perfil.Cliente)
            {
                var cliente = _bancoDados.Clientes.FirstOrDefault(e => e.Id == Convert.ToInt32(contaIdPerfil));

                var tratamento = _bancoDados.Tratamentos.Where(e => e.IdCliente == Convert.ToInt32(contaIdPerfil)).Include(e => e.Cliente).Include(e => e.profissional).Include(e => e.avaliacaos).ToList(); 

                return View(tratamento);

            }
            if (usuario.Perfil == Perfil.Profissional)
            {

                var profissional = _bancoDados.Profissionais.FirstOrDefault(e => e.Id == Convert.ToInt32(contaIdPerfil));

                var tratamento = _bancoDados.Tratamentos.Where(e => e.IdProfissional == Convert.ToInt32(contaIdPerfil)).Include(e => e.Cliente).Include(e => e.profissional).Include(e => e.avaliacaos).ToList(); 

                return View(tratamento);
            }
            return View();
        }

        public IActionResult Exibe(int id)
        {
            //faz a busca pelo id do usuario
            _bancoDados = new BancoDados();
            var tratamento = _bancoDados.Tratamentos.Include(e => e.Cliente).Include(e => e.profissional).FirstOrDefault(e => e.Id == id);

            return View(tratamento);
        }


        [HttpGet]

        public IActionResult ExibeProfissionais()
        {
            
            _bancoDados = new BancoDados();
            var profissionais = _bancoDados.Profissionais.ToList();

            return View(profissionais);
        }
        [HttpGet]
        public IActionResult Inclui(int id)
        {
            _bancoDados = new BancoDados();
            var profissionals = _bancoDados.Profissionais.Where(e => e.Id == id).ToList();

            var tratamentos = _bancoDados.Profissionais.Where(e => Convert.ToInt32(e.Cromoterapia) == 1);

            var clientes = _bancoDados.Clientes.Where(e => e.Id == Convert.ToInt32(contaIdPerfil));
            Tratamento tratamento = new Tratamento();
            ViewBag.Profissional = new SelectList(profissionals , "Id", "Nome", tratamento.IdProfissional);
            ViewBag.clientes = new SelectList(clientes, "Id", "Nome" , tratamento.IdCliente);

            //ViewBag.TecnicaTratamento = new SelectList();

            return View(tratamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inclui(Tratamento tratamento1)
        {
            DateTime Dia = tratamento1.Data;
            var tratamento = tratamento1.TecnicaTratamento;
            int idproficional = tratamento1.Id;
            //faz a inclusao no banco 
            _bancoDados = new BancoDados();

            tratamento1 = new Tratamento();

            tratamento1.IdProfissional = idproficional;
            tratamento1.IdCliente = Convert.ToInt32(contaIdPerfil);
            tratamento1.Data = Dia;
            tratamento1.TratamentoFinalizado = false;
            tratamento1.TecnicaTratamento = tratamento.ToString();
            _bancoDados.Add(tratamento1);
            _bancoDados.SaveChanges();
            //volta para o inicio
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Exclui(int id)
        {

            //faz a busca pelo id do usuario
            _bancoDados = new BancoDados();

            var tratamento = _bancoDados.Tratamentos.Include(e => e.Cliente).Include(e => e.profissional).FirstOrDefault(e => e.Id == id);

            return View(tratamento);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Exclui(Tratamento tratamento)
        {
            //faz a busca pelo id do usuario
            _bancoDados = new BancoDados();


            
            var avaliacao = _bancoDados.Avaliacaos.FirstOrDefault(e => e.IdTratamento == tratamento.Id);

            if (avaliacao != null)
            {
                _bancoDados.Remove(avaliacao);
                _bancoDados.SaveChanges();
            }

            _bancoDados.Remove(tratamento);
            _bancoDados.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Altera(int Id)
        {
            if(Id > 0)
            {
                //faz a busca pelo id do usuario
                _bancoDados = new BancoDados();

                var profissionals = _bancoDados.Profissionais.ToList();

                var clientes = _bancoDados.Clientes.ToList();

                var tratamento = _bancoDados.Tratamentos.Include(e => e.Cliente).Include(e => e.profissional).FirstOrDefault(e => e.Id == Id);

                ViewBag.Profissional = new SelectList(profissionals, "Id", "Nome", tratamento.IdProfissional);
                ViewBag.clientes = new SelectList(clientes, "Id", "Nome", tratamento.IdCliente);

                return View(tratamento);
            }
            return null;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Altera(Tratamento tratamento)
        {

            //inicia o canco de dados
            _bancoDados = new BancoDados();
            _bancoDados.Tratamentos.Update(tratamento);
            _bancoDados.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExibeProfissionais(string busca)
        {
            //lista de usuarios do banco de dados fazendo filtros
            _bancoDados = new BancoDados();
            var profissonal = _bancoDados.Profissionais.ToList();

            if (!string.IsNullOrEmpty(busca))
            {
                    if (busca.ToLower() == "cromoterapia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.Cromoterapia == Especialidade.Cromoterapia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "shiatsu")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.Shiatsu == Especialidade.Shiatsu).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "shiatsudacadeira")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.ShiatsuDaCadeira == Especialidade.ShiatsuDaCadeira).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "doin")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.DoIn == Especialidade.DoIn).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "pedrasquentes")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.PedrasQuentes == Especialidade.PedrasQuentes).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "bambuterapia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.BambuTerapia == Especialidade.BambuTerapia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "massagemrelaxante")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.MassagemRelaxante == Especialidade.MassagemRelaxante).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "quickmassagem")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.QuickMassagem == Especialidade.QuickMassagem).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "massagemdesportiva")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.MassagemDesportiva == Especialidade.MassagemDesportiva).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "MassagemModeladora")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.MassagemModeladora == Especialidade.MassagemModeladora).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "reflexologia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.Reflexologia == Especialidade.Reflexologia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "amaromaterapia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.Amaromaterapia == Especialidade.Amaromaterapia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "maxoterapia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.Maxoterapia == Especialidade.Maxoterapia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "ventosaterapia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.VentoSaterapia == Especialidade.VentoSaterapia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "auriculoterapia")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.Auriculoterapia == Especialidade.Auriculoterapia).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "drenagemlinfatica")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.DrenagemLinfatica == Especialidade.DrenagemLinfatica).ToList();
                        return View(profissonal);
                    }
                    if (busca.ToLower() == "temakinesiotape")
                    {
                        profissonal = _bancoDados.Profissionais.Where(e => e.TemAKinesioTape == Especialidade.TemAKinesioTape).ToList();
                        return View(profissonal);
                    }
                    else
                    {

                        profissonal = _bancoDados.Profissionais.Where(e => e.Nome.Contains(busca) || e.Sexo.Contains(busca)).ToList();

                        return View(profissonal);
                    }

            }

            var profissionais = _bancoDados.Profissionais.ToList();

            return View(profissionais);
        }
    }
}
