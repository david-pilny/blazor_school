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

    public class RevizeController : ControllerBase
    {
        private readonly NemocniceDbContext _db;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public RevizeController(NemocniceDbContext db, IMapper mapper, ILogger<RevizeController> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{vyhledavanyRetezec}")]
        public ActionResult<Task<List<RevizeModel>>> GetRevizeList(string vyhledavanyRetezec)
        {
            if (string.IsNullOrWhiteSpace(vyhledavanyRetezec))
            {
                return Problem("Parametr musí být neprázdný");
            }
            List<Revize> revizeList = _db.Revize.ToList();
            var kdeJeRetezec = revizeList.Where(x => x.Name.Contains(vyhledavanyRetezec));
            return Ok(kdeJeRetezec);
        }

        [HttpGet("detail/{Id}")]
        public ActionResult<Task<List<VybaveniSRevizemiModel>>> GetAllRevizesForItem(Guid Id)
        {
            var revizeList = _db.Revize.Where(x => x.VybaveniId == Id).ToList();
            List<VybaveniSRevizemiModel> list = new();

            foreach (var item in revizeList)
            {

                VybaveniSRevizemiModel item2 = _mapper.Map<VybaveniSRevizemiModel>(item);
                list.Add(item2);

            }
            return Ok(list);
        }

        [HttpPost]
        public ActionResult<Revize> PostRevize(VybaveniModel item)
        {
            Random random = new Random();
            int length = 16;
            var rString = "";

            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }

            Revize ent = new();
            ent.Id = Guid.Empty;
            ent.Name = rString;
            ent.DateTime = DateTime.Now;
            ent.VybaveniId = item.Id;
            _db.Revize.Add(ent);
            _db.SaveChanges();
            return Ok();
        }
    }
}

