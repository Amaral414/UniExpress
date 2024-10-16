using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DataAccess _dataAccess;
        public ClienteController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IActionResult Index()
        {
            try
            {
                var cliente = _dataAccess.ListarClientes();
                return View(cliente);
            }
            catch (Exception ex)
            {
                var cliente = _dataAccess.ListarClientes();
                TempData["MensagemErro"] = "Ocorreu um erro na criação do usuároio";
                return View(cliente);
            }
        }
    }
}
