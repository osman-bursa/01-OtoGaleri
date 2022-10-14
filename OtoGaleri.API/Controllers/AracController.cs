using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoGaleri.BUSINESS.Abstract;
using OtoGaleri.ENTITIES.Entities;
using System;
using System.Linq.Expressions;

namespace OtoGaleri.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracController : ControllerBase
    {
        private readonly IGenericService<Arac> _aracService;

        public AracController(IGenericService<Arac> aracService)
        {
            _aracService = aracService;
        }

        // ----- GET ----- //
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAraclar()
        {
            return Ok(_aracService.GetActive());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAracByID(int id)
        {
            return Ok(_aracService.GetByID(id));
        }

        [HttpGet]
        [Route("[action]/{sasiNo}")]
        public ActionResult GetAracBySasiNo(int sasiNo)
        {
            return Ok(_aracService.GetByDefault(x=> x.SasiNo == sasiNo));
        }

        [HttpGet]
        [Route("[action]/{baslangic}/{bitis}")]
        public ActionResult GetAracByUretimYilRange(int baslangic, int bitis)
        {
            return Ok(_aracService.GetDefault(x => x.UretimTarihi.Year >= baslangic && x.UretimTarihi.Year <= bitis));
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateArac(Arac arac)
        {
            return Ok(_aracService.Add(arac));
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult UpdateArac([FromBody]Arac arac)
        {
            try
            {
                _aracService.Update(arac);
                return Ok(arac);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult DeleteArac(int id)
        {
            try
            {
                _aracService.Remove(_aracService.GetByID(id));
                return Ok("Araç silindi");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult ActivateArac(int id)
        {
            try
            {
                _aracService.Activate(id);
                return Ok("Araç aktifleştirildi");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}


/*
 *      bool Add(T item);
        bool Add(List<T> item);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(int id);
        bool RemoveAll(Expression<Func<T, bool>> exp);
        T GetByID(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        bool Activate(int id);
        bool Any(Expression<Func<T, bool>> exp);
 */
