using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoGaleri.BUSINESS.Abstract;
using OtoGaleri.ENTITIES.Entities;

namespace OtoGaleri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazaController : ControllerBase
    {
        private readonly IGenericService<Magaza> _magazaService;

        public MagazaController(IGenericService<Magaza> magazaService)
        {
            _magazaService = magazaService;
        }
    }
}
