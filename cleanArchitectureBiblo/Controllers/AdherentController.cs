using Domain.Model;
using Infrastructure.Contrat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cleanArchitectureBiblo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdherentController : ControllerBase
    {
        private readonly IGenerique<Adherent> _adhrent;
        public AdherentController(IGenerique<Adherent> adherent)
        {
            _adhrent = adherent;
        }

        [HttpGet]
        public ActionResult<List<Adherent>> Get()
        {
            return Ok(_adhrent.getAll());
        }
        [HttpGet("id")]
        public ActionResult<Adherent> GetById(int id) 
        {
            return Ok(_adhrent.getOne(id));
        }
        [HttpPost]
        public ActionResult Add(Adherent adherent)
        {
           
                _adhrent.addOne(adherent);
            return Ok("adherent was added ");
        }
        [HttpPut]
        public ActionResult Update(Adherent  adherent) 
        {
            _adhrent.UpdateOne(adherent);
            return Ok("the adherent was Updated");
        }
        [HttpDelete("id")]
        public ActionResult Delete(Adherent adherent) 
        {
            _adhrent.removeOne(adherent);
            return Ok("Adherent was removedS"); 
        }
    }
}
