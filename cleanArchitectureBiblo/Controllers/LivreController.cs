using AutoMapper;
using cleanArchitectureBiblo.ModelDTO;
using Domain.Model;

using Infrastructure.Contrat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cleanArchitectureBiblo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {   
        private readonly IGenerique<Livre> _livre;
        private readonly IMapper _mapper;
        public LivreController(IGenerique<Livre> livre, IMapper mapper)
        {
             _livre = livre;
            _mapper = mapper;

        }
        [HttpGet]
        public ActionResult<List<Livre>> Get()
        {
            return Ok(_livre.getAll(sourc => sourc.Include(i => i.Adherent)));
        }
        [HttpGet("id")]
        public ActionResult<Livre> GetId(int id)
        {
            var entity = _livre.getOne(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        [HttpPost]
        public ActionResult Post(Livre livre) { 
            var entity = _mapper.Map<Livre>(livre);
            _livre.addOne(entity);
            return Ok("livre added");

        }
        [HttpPut]
        public ActionResult UpdateLivre( Livre livre )
        {
            var entity = _mapper.Map<Livre>(livre);
            _livre.UpdateOne(entity);
            return Ok("Updated");
        }
        [HttpDelete]
        public ActionResult Delete(int livreID)
        {
            var entity = _livre.getOne(livreID);
            if (entity == null)
            {
                return NotFound();
            }
            _livre.removeOne(entity.Id);
            return Ok("Livre removed");
        }
    }
}
