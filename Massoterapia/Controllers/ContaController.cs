using Massoterapia.Data;
using Massoterapia.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;


namespace Massoterapia.Controllers
{
    public class ContaController : Controller
    {
        //Atributos
        BancoDados _bancoDados;

        //Metodos Actions
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                //inicia o banco de dados
                _bancoDados = new BancoDados();
                //consulta para obter o usuario
                var usuario = _bancoDados.Usuarios
                    .FirstOrDefault(e => e.Email == login.Email && e.Senha == login.Senha);
                //verificacao se usuario valido
                if (usuario != null)
                {
                    string nome = string.Empty;
                    //usuario valido
                    if (usuario.Perfil == Perfil.Cliente)
                    {
                        var cliente = _bancoDados.Clientes
                            .FirstOrDefault(e => e.Id == usuario.IdPerfil);
                        nome = cliente.Nome;
                    }
                    else if (usuario.Perfil == Perfil.Profissional)
                    {
                        var profissional = _bancoDados.Profissionais
                            .FirstOrDefault(e => e.Id == usuario.IdPerfil);
                        nome = profissional.Nome;
                    }

                    //cria a credencial do usuario no servidor
                    //dados da credencial
                    var credencialClaims = new List<Claim>();
                    credencialClaims.Add(new Claim(ClaimTypes.Email, usuario.Email));
                    credencialClaims.Add(new Claim(ClaimTypes.Name, nome));
                    credencialClaims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.IdPerfil.ToString()));
                    credencialClaims.Add(new Claim(ClaimTypes.Role, usuario.Perfil.ToString()));

                    //defini a identidade de acesso para credencial
                    var identidadeClaims = new ClaimsIdentity(credencialClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //defini a autenticacao da identidade de acesso
                    var autenticacaoCookie = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(120),
                        IssuedUtc = DateTime.UtcNow,
                        RedirectUri = @"~/"
                    };

                    //defini a autenticacao da identidade
                    var autenticacaoIdentidade = new ClaimsPrincipal(identidadeClaims);
                    //realiza a autenticacao do usuario no servidor web
                    HttpContext.SignInAsync(autenticacaoIdentidade, autenticacaoCookie);

                    //redireciona para o painel administrativo
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("Senha", "Usuário ou senha inválidos");
                }
            }
            //retorna para o login com o erro de autenticacao
            return View(login);
        }


        [HttpGet]
        public IActionResult Registro(string perfil)
        {
            RegistroViewModel registro = new RegistroViewModel();
            if (perfil == Perfil.Profissional.ToString())
            {
                registro.Perfil = Perfil.Profissional;
            }
            else
            {
                registro.Perfil = Perfil.Cliente;
            }

            return View(registro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(RegistroViewModel registro)
        {
            //inicia o banco de dados
            _bancoDados = new BancoDados();
            var verificaEmail = _bancoDados.Usuarios
               .FirstOrDefault(e => e.Email == registro.Email);
            if (verificaEmail == null)
            {
                if (ModelState.IsValid)
                {
                    //verifica para inserir o cliente ou tecnico
                    if (registro.Perfil == Perfil.Cliente)
                    {
                        //cadastra o cliente
                        Cliente cliente = new Cliente();
                        cliente.Nome = registro.Nome;
                        cliente.Sexo = registro.Sexo;
                        cliente.Telefone = registro.Telefone;
                        cliente.Celular = registro.Celular;
                        cliente.DataNascimento = registro.DataNascimento;
                        //cadastra o cliente no banco de dados
                        _bancoDados.Clientes.Add(cliente);
                        _bancoDados.SaveChanges();
                        //obtem o idPerfil
                        registro.IdPerfil = cliente.Id;
                    }
                    else
                    {
                        //cadastra o profissional
                        Profissional profissional1 = new Profissional();
                        profissional1.Nome = registro.Nome;
                        profissional1.Sexo = registro.Sexo;
                        profissional1.DataNascimento = registro.DataNascimento;
                        if(registro.Cromoterapia)
                        {
                        profissional1.Cromoterapia = Especialidade.Cromoterapia;
                        }
                        if (registro.Shiatsu)
                        {
                            profissional1.Shiatsu = Especialidade.Shiatsu;
                        }
                        if (registro.ShiatsuDaCadeira)
                        {
                            profissional1.ShiatsuDaCadeira = Especialidade.ShiatsuDaCadeira;
                        }
                        if (registro.DoIn)
                        {
                            profissional1.DoIn = Especialidade.DoIn;
                        }
                        if (registro.PedrasQuentes)
                        {
                            profissional1.PedrasQuentes = Especialidade.PedrasQuentes;
                        }
                        if (registro.BambuTerapia)
                        {
                            profissional1.BambuTerapia = Especialidade.BambuTerapia;
                        }
                        if (registro.MassagemRelaxante)
                        {
                            profissional1.MassagemRelaxante = Especialidade.MassagemRelaxante;
                        }
                        if (registro.QuickMassagem)
                        {
                            profissional1.QuickMassagem = Especialidade.QuickMassagem;
                        }
                        if (registro.MassagemDesportiva)
                        {
                            profissional1.MassagemDesportiva = Especialidade.MassagemDesportiva;
                        }
                        if (registro.MassagemModeladora)
                        {
                            profissional1.MassagemModeladora = Especialidade.MassagemModeladora;
                        }
                        if (registro.Reflexologia)
                        {
                            profissional1.Reflexologia = Especialidade.Reflexologia;
                        }
                        if (registro.Amaromaterapia)
                        {
                            profissional1.Amaromaterapia = Especialidade.Amaromaterapia;
                        }
                        if (registro.Maxoterapia)
                        {
                            profissional1.Maxoterapia = Especialidade.Maxoterapia;
                        }
                        if (registro.VentoSaterapia)
                        {
                            profissional1.VentoSaterapia = Especialidade.VentoSaterapia;
                        }
                        if (registro.Auriculoterapia)
                        {
                            profissional1.Auriculoterapia = Especialidade.Auriculoterapia;
                        }
                        if (registro.DrenagemLinfatica)
                        {
                            profissional1.DrenagemLinfatica = Especialidade.DrenagemLinfatica;
                        }
                        if (registro.TemAKinesioTape)
                        {
                            profissional1.TemAKinesioTape = Especialidade.TemAKinesioTape;
                        }
                        profissional1.Cep = registro.Cep;
                        profissional1.Bairro = registro.Bairro;
                        profissional1.Rua = registro.Rua;
                        profissional1.Numero = registro.Numero;
                        profissional1.Complemento = registro.Complemento;
                        //cadastra o tecnico no banco de dados
                        _bancoDados.Profissionais.Add(profissional1);
                        _bancoDados.SaveChanges();
                        //obtem o idPerfil
                        registro.IdPerfil = profissional1.Id;
                    }
                    //cadastra o usuario
                    Usuario usuario = new Usuario();
                    usuario.Email = registro.Email;
                    usuario.Senha = registro.Senha;
                    usuario.Perfil = registro.Perfil;
                    usuario.IdPerfil = registro.IdPerfil;
                    //cadastra o usuario no banco de dados
                    _bancoDados.Usuarios.Add(usuario);
                    _bancoDados.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Email já está cadastrado");
                return View(registro);
            }
            return View(registro);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //desabilita a autenticacao do usuario
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { area = "Default" });
        }

    }
}
