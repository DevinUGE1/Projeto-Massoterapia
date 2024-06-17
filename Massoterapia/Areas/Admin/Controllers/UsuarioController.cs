using Massoterapia.Data;
using Massoterapia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Massoterapia.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : AdminController
    {


            //atributos
            BancoDados _bancoDados;
            IWebHostEnvironment _servidorWeb;

            //metodo construtor
            public UsuarioController(IWebHostEnvironment webHostEnvironment)
            {
                _servidorWeb = webHostEnvironment;
            }

            //metodos auxiliares
            private string SalvaArquivo(IFormFile arquivo)
            {
                //verifica se tem um arquivo
                if (arquivo == null)
                {
                    return string.Empty;
                }
                //armazenar o arquivo no servidor
                string nomeArquivo = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(arquivo.FileName)}";
                var pastaArquivo = Path.Combine(_servidorWeb.WebRootPath, "uploads");
                var localArquivo = Path.Combine(pastaArquivo, nomeArquivo);
                var dadosArquivo = new FileStream(localArquivo, FileMode.Create);
                arquivo.CopyTo(dadosArquivo);
                dadosArquivo.Close();
                return nomeArquivo;
            }

            private bool ExcluiArquivo(string nomeArquivo)
            {
                //verifica se tem o aquivo
                if (string.IsNullOrWhiteSpace(nomeArquivo))
                {
                    return false;
                }
                //remover o arquivo do servidor
                var pastaArquivo = Path.Combine(_servidorWeb.WebRootPath, "uploads");
                var localArquivo = Path.Combine(pastaArquivo, nomeArquivo);
                System.IO.File.Delete(localArquivo);
                return true;
            }

            [HttpGet]
            public IActionResult Index()
            {
                //lista de usuarios do banco de dados
                _bancoDados = new BancoDados();
                var usuarios = _bancoDados.Usuarios.ToList();
                return View(usuarios);
            }

            [HttpPost]
            public IActionResult Index(string busca)
            {
                //lista de usuarios do banco de dados fazendo filtros
                _bancoDados = new BancoDados();
                var usuarios = _bancoDados.Usuarios.ToList();
                if (!string.IsNullOrEmpty(busca))
                {
                    usuarios = usuarios
                        .Where(e => e.Email.Contains(busca) || e.Perfil.ToString().Contains(busca))
                        .ToList();
                }
                return View(usuarios);
            }

            [HttpGet]
            public IActionResult Inclui()
            {
                Usuario usuario = new Usuario();
                usuario.Perfil = Perfil.Administrador;
                return View(usuario);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Inclui(Usuario usuario, IFormFile arquivo)
            {
                if (ModelState.IsValid)
                {
                    //verifica se existe um arquivo
                    if (arquivo != null)
                    {
                        var nomeArquivo = SalvaArquivo(arquivo);
                        usuario.Imagem = nomeArquivo;
                    }

                    //faz a inclusao no banco de dados
                    _bancoDados = new BancoDados();
                    _bancoDados.Add(usuario);
                    _bancoDados.SaveChanges();
                    //volta para o inicio
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Imagem", "Usuário inválido");
                }
                return View(usuario);
            }

            [HttpGet]
            public IActionResult Altera(int id)
            {
                //faz a busca pelo id do usuario
                _bancoDados = new BancoDados();
                var usuario = _bancoDados.Usuarios.FirstOrDefault(e => e.Id == id);
                return View(usuario);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Altera(Usuario usuario)
            {
                if (ModelState.IsValid)
                {
                    //inicia o banco de dados
                    _bancoDados = new BancoDados();
                    //atualiza o usuario
                    _bancoDados.Usuarios.Update(usuario);
                    //executa o comando
                    _bancoDados.SaveChanges();
                    return RedirectToAction("Index");
                }
                //se estiver inválido retorna para view
                return View(usuario);
            }

            [HttpGet]
            public IActionResult Exibe(int id)
            {
                //faz a busca pelo id do usuario
                _bancoDados = new BancoDados();
                var usuario = _bancoDados.Usuarios.FirstOrDefault(e => e.Id == id);
                return View(usuario);
            }

            [HttpGet]
            public IActionResult Exclui(int id)
            {
                //faz a busca pelo id do usuario
                _bancoDados = new BancoDados();
                var usuario = _bancoDados.Usuarios.FirstOrDefault(e => e.Id == id);
                return View(usuario);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Exclui(Usuario usuario)
            {
                if (usuario.Perfil == Perfil.Administrador)
                {

                    _bancoDados = new BancoDados();
                    var tecnico = _bancoDados.Administradores.FirstOrDefault(e => e.Id == usuario.IdPerfil);
                    _bancoDados.Remove(tecnico);
                    _bancoDados.SaveChanges();
                }
                if (usuario.Perfil == Perfil.Cliente)
                {

                    _bancoDados = new BancoDados();
                    var cliente = _bancoDados.Clientes.FirstOrDefault(e => e.Id == usuario.IdPerfil);
                    _bancoDados.Remove(cliente);
                    _bancoDados.SaveChanges();
                }
                if (usuario.Perfil == Perfil.Profissional)
                {

                    _bancoDados = new BancoDados();
                    var cliente = _bancoDados.Profissionais.FirstOrDefault(e => e.Id == usuario.IdPerfil);
                    _bancoDados.Remove(cliente);
                    _bancoDados.SaveChanges();
                }

                if (usuario.Id > 0)
                {
                    //faz a exclusao do usuario pelo id
                    _bancoDados = new BancoDados();
                    _bancoDados.Remove(usuario);
                    _bancoDados.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);

        }


    }
}
