using Microsoft.EntityFrameworkCore;
using PptNemocnice.Shared;

namespace PptNemocnice.Api.Data
{
	public class NemocniceDbContext : DbContext
	{
		public NemocniceDbContext(DbContextOptions<NemocniceDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
        {
			Guid id1 = new Guid("ccc693cf-3fc5-42b3-962e-fd1ba1a3091d");
			Guid id2 = new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5");
			Guid id3 = new Guid("516cd84c-74be-460d-bd3b-5499afabef23");

			builder.Entity<Vybaveni>().HasData(
				new Vybaveni() { Id = id1, Name = "Rentgen", BoughtDate = new DateTime(2012, 12, 25), PriceCzk = 783278 },
				new Vybaveni() { Id = id2, Name = "CT Scanner", BoughtDate = new DateTime(2015, 3, 6), PriceCzk = 1324653 },
				new Vybaveni() { Id = id3, Name = "Mikroskop", BoughtDate = new DateTime(2017, 12, 20), PriceCzk = 24246 }
				);

			builder.Entity<Revize>().HasData(
				new Revize() { Id = new Guid("839da36b-86a6-475a-a157-5945ec20fe69"), VybaveniId = id1, Name = "Rentgen", DateTime = new DateTime(2020, 7, 2) },
				new Revize() { Id = new Guid("f8bd0762-5f23-4f80-bcd8-5aef1d674c49"), VybaveniId = id2, Name = "CT Scanner", DateTime = new DateTime(2019, 10, 14) },
				new Revize() { Id = new Guid("8334e45a-157f-4044-a675-53e6d977290d"), VybaveniId = id2, Name = "Mikroskop", DateTime = new DateTime(2021, 1, 18) }
				);
		}

		public DbSet<Vybaveni> Vybaveni => Set<Vybaveni>();

		public DbSet<Revize> Revize => Set<Revize>();

		public DbSet<Ukon> Ukon => Set<Ukon>();

		public DbSet<Pracovnik> Pracovnik => Set<Pracovnik>();
	}
}
