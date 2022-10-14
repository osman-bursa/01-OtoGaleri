using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoGaleri.BUSINESS.Abstract;
using OtoGaleri.ENTITIES.Entities;

namespace OtoGaleri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IGenericService<Kullanici> _kullaniciService;

        public KullaniciController(IGenericService<Kullanici> kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
    }
}
