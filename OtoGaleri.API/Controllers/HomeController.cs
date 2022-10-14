using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoGaleri.BUSINESS.Abstract;
using OtoGaleri.ENTITIES.Entities;

namespace OtoGaleri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGenericService<Arac> _aracService;
        private readonly IGenericService<Kullanici> _kullaniciService;
        private readonly IGenericService<Magaza> _magazaService;

        public HomeController(IGenericService<Arac> aracService, IGenericService<Kullanici> kullaniciService, IGenericService<Magaza> magazaService)
        {
            _aracService = aracService;
            _kullaniciService = kullaniciService;
            _magazaService = magazaService;
        }

        [HttpGet]
        //[Route("[action]")]
        [Route("araclarigetir")]
        public ActionResult GetAraclar()
        {
            return Ok(_aracService.GetAll());
        }

        [HttpGet]
        //[Route("[action]")]
        [Route("kullanicilarigetir")]
        public ActionResult GetKullanicilar()
        {
            return Ok(_kullaniciService.GetAll());
        }

        [HttpGet]
        //[Route("[action]")]
        [Route("magazalarigetir")]
        public ActionResult GetMagazalar()
        {
            return Ok(_magazaService.GetAll());
        }
    }
}
