using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Massoterapia.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrador,Cliente,Profissional")]
    public abstract class AdminController : Controller
    {
        IHttpContextAccessor httpContextoAccessor;

        //dados compartilhados
        protected IEnumerable<Claim> contaPermissao => User.Claims;

        //Nome Conta
        protected string contaNome => User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Name).Value;


        //Perfil da conta
        protected string contaPerfil => User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Role).Value;

        //Id do perfil da conta
        protected string contaIdPerfil => User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value;

        protected string contaEmaill => User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Email).Value;



    }
}
