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
    public class AdherentController : ControllerBase
    {
        private readonly IGenerique<Adherent> _adhrent;
        private readonly IMapper _mapper;
        public AdherentController(IGenerique<Adherent> adherent, IMapper mapper)
        {
            _adhrent = adherent;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Adherent>> Get()
        {
            return Ok(_adhrent.getAll(sourc => sourc.Include(i => i.livres)));
        }
        [HttpGet("id")]
        public ActionResult<Adherent> GetById(int id) 
        {
            var entity = _adhrent.getOne(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
        [HttpPost]
        public ActionResult Add(AdherentDTO adherent)
        {
            var entity = _mapper.Map<Adherent>(adherent);
                _adhrent.addOne(entity);
            return Ok("adherent was added ");
        }
        [HttpPut]
        public ActionResult Update(AdherentDTO  adherent) 
        {
            var entity = _mapper.Map<Adherent>(adherent);
            _adhrent.UpdateOne(entity);
            return Ok("the adherent was Updated");
        }
        [HttpDelete("id")]
        public ActionResult Delete(int adherent) 
        {
            var entity = _adhrent.getOne(adherent);
            if (entity == null)
            {
                return NotFound();
            }

            _adhrent.removeOne(entity.Id);
            return Ok("Adherent was removedS"); 
        }
    }
}
