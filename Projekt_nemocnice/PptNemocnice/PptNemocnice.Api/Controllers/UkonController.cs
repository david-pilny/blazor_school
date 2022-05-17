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

    public class UkonController : ControllerBase
    {

        private readonly NemocniceDbContext _db;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        private readonly IConfiguration _config;

        public UkonController(NemocniceDbContext db, IMapper mapper, ILogger<SeedController> logger, IConfiguration config)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
            _config = config;
        }

        [HttpGet("detail/{Id}")]
        public ActionResult<Task<List<UkonModel>>> GetAllRevizesForItem(Guid Id)
        {
            var ukonList = _db.Ukon.Where(x => x.VybaveniId == Id).ToList();
            List<UkonModel> list = new();

            foreach (var item in ukonList)
            {

                UkonModel item2 = _mapper.Map<UkonModel>(item);
                var pracovnik = _db.Pracovnik.First(x => x.Id == item.PracovnikId);
                item2.PracovnikName = pracovnik.Name;
                list.Add(item2);

            }
            return Ok(list);
        }
    }
}

