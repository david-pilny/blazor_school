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

    public class SeedController : ControllerBase
    {

        private readonly NemocniceDbContext _db;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        private readonly IConfiguration _config;

        public SeedController(NemocniceDbContext db, IMapper mapper, ILogger<SeedController> logger, IConfiguration config)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
            _config = config;
        }

        [HttpPost("{tajnyKod}")]
        public ActionResult SeedMethod(string tajnyKod)
        {
            if (tajnyKod != _config["seedSecrete"])
                return NotFound();

            Random rnd = new();
            List<Pracovnik> pracanti = new();
            int pocetPracantu = 10;
            for (int i = 0; i < pocetPracantu; i++)
                pracanti.Add(new() { Name = RandomString(12) });

            _db.AddRange(pracanti); _db.SaveChanges();

            foreach (var vyb in _db.Vybaveni)//pro každé vybavení
            {
                int pocetUkonu = rnd.Next(13, 25);
                for (int i = 0; i < pocetUkonu; i++)//se vytvoří několik úkonů
                {
                    Ukon uk = new()
                    {
                        DateTime = DateTime.UtcNow.AddDays(rnd.Next(-100, -1)),
                        Description = RandomString(56).Replace("x", " "),
                        Kod = RandomString(5),
                        VybaveniId = vyb.Id,//daného vybavení
                        PracovnikId = pracanti[rnd.Next(pocetPracantu - 1)].Id
                    };
                    _db.Ukon.Add(uk);
                }
            }
            _db.SaveChanges();

            return Ok();

            string RandomString(int length) =>//lokální funkce
                new(Enumerable.Range(0, length).Select(_ => (char)rnd.Next('a', 'z')).ToArray());
        }
    }
}

