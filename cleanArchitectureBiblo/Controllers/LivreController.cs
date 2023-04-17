using Domain.Model;
using Infrastructure.Contrat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cleanArchitectureBiblo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {   
        private readonly IGenerique<Livre> _livre;
        public LivreController(IGenerique<Livre> livre )
        {
             _livre = livre;
        }
        [HttpGet]
        public ActionResult<List<Livre>> Get()
        {
            return Ok(_livre.getAll());
        }
        [HttpGet("id")]
        public ActionResult<Livre> GetId(int id)
        { 
            return Ok(_livre.getOne(id));
        }
        [HttpPost]
        public ActionResult Post(Livre livre)
        {
            _livre.addOne(livre);
            return Ok("livre added");

        }
        [HttpPut]
        public ActionResult UpdateLivre( Livre livre )
        {
            _livre.UpdateOne(livre);
            return Ok("Updated");
        }
        [HttpDelete]
        public ActionResult Delete(Livre livre)
        {
            _livre.removeOne(livre);
            return Ok("Livre removed");
        }
    }
}
