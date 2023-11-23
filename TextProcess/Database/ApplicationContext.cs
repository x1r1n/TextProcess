using Microsoft.EntityFrameworkCore;
using TextProcess.Database.DbModels;

namespace TextProcess.Database
{
	public class ApplicationContext : DbContext
	{
		public DbSet<SourceTexts> SourceTexts { get; set; }
		public DbSet<GeneratedSentences> GeneratedSentences { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
	}
}