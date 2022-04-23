using Microsoft.EntityFrameworkCore;
using PptNemocnice.Shared;

namespace PptNemocnice.Api.Data
{
	public class NemocniceDbContext : DbContext
	{
		public NemocniceDbContext(DbContextOptions<NemocniceDbContext> options) : base(options)
		{
		}

		public DbSet<Vybaveni> Vybaveni => Set<Vybaveni>();
		public DbSet<RevizeModel> Revize => Set<RevizeModel>();
	}
}
