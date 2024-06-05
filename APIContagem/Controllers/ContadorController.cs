using APIContagem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIContagem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContadorController : ControllerBase
    {
        private readonly IContadorService service;
        public ContadorController(IContadorService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public object Get()
        {
            return this.service.Get();
        }
    }
}