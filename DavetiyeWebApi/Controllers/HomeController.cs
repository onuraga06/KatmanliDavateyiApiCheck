using DavetiyeBusiness.Abstract;
using DavetiyeEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DavetiyeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IDavetiyeService rep;
        public HomeController(IDavetiyeService _rep)
        {
            rep = _rep;

        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = rep.GetList();
            return Ok(values);

        }


        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var values = rep.GetByID(id);
            if (values != null)
            {
                return Ok(values);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Katilanlar")]
        public IActionResult Durum()
        {
           
            return Ok(rep.Durum(true));
        }
        [HttpPost]
        public IActionResult Create(Davetiye entites)
        {
            if (ModelState.IsValid)
            {
                var value = rep.Add(entites);
                return Ok(value);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(Davetiye entites)
        {
            if (rep.GetByID(entites.id) != null)
            {
                var values = rep.Update(entites);
                return Ok(values);
            }
            else
            {
                return NotFound("Güncelleme Gerçekleşmedi");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (rep.GetByID(id) != null)
            {
                var value = rep.GetByID(id);
                rep.Delete(id);
                return Ok(value);

            }
            else
            {
                return NotFound("Silme Gerceklesmedi");
            }

        }
    }
}
