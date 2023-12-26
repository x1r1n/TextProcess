using Microsoft.EntityFrameworkCore;
using TextProcess.Database.DbModels;

namespace TextProcess.Database
{
	public class ApplicationContext : DbContext
	{
		public DbSet<SourceText> SourceText { get; set; }
		public DbSet<SyntheticPhrase> SyntheticPhrase { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
	}
}