using System;
using Microsoft.AspNetCore.Mvc;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PptNemocnice.Api.Controllers
{
	[Route("[controller]")]

    [ApiController]
   
	public class VybaveniController : ControllerBase
	{

        private readonly NemocniceDbContext _db;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public VybaveniController(NemocniceDbContext db, IMapper mapper, ILogger<VybaveniController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<VybaveniModel>> GetAllVybaveni()
		{
            List<VybaveniModel> seznam = new();

            var ents = _db.Vybaveni.Include(x => x.Revizes);

            foreach (var ent in ents)
            {
                VybaveniModel item = _mapper.Map<VybaveniModel>(ent);
                if (ent.Revizes.Count > 0)
                {
                    item.LastRevisionDate = ent.Revizes.Last().DateTime;
                }

                seznam.Add(item);
            }

            return seznam;
        }

        [HttpGet("{Id}")]
        public ActionResult<VybaveniModel> GetOneVybaveni(Guid Id)
        {
            Vybaveni item = _db.Vybaveni.Include(x => x.Revizes).First(a => a.Id == Id);
            if (item == null)
            {
                return NotFound("Tato položka nebyla nalezena!!");
            }

            VybaveniModel item2 = _mapper.Map<VybaveniModel>(item);
            item2.LastRevisionDate = item.Revizes.Last().DateTime;
            return item2;
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteVybaveni(Guid Id)
        {
            var item = _db.Vybaveni.Where(x => x.Id == Id);

            if (item == null)
            {
                return NotFound("Tato položka nebyla nalezena!!");
            }

            _db.Remove(_db.Vybaveni.Single(a => a.Id == Id));
            _db.SaveChanges();

            _logger.LogWarning("Bylo smazáno vybavení");

            return Ok();
        }

        [HttpPost]
        public ActionResult<VybaveniModel> PostVybaveni(VybaveniModel prichoziModel)
        {
            prichoziModel.Id = Guid.Empty;
            Vybaveni ent = _mapper.Map<Vybaveni>(prichoziModel);

            _db.Vybaveni.Add(ent);
            _db.SaveChanges();

            return Created("/vybaveni", ent.Id);
        }

        [HttpPut("{Id}")]
        public ActionResult<VybaveniModel> UpdateVybaveni([FromBody] VybaveniModel incomingItem)
        {
            var item = _db.Vybaveni.FirstOrDefault(a => a.Id == incomingItem.Id);

            if (item == null)
            {
                return NotFound("Tato položka nebyla nalezena!!");
            }

            _mapper.Map(incomingItem, item);

            _db.SaveChanges();

            return Ok();
        }
    }
}

