using Microsoft.EntityFrameworkCore;
using TextProcess.Database.DbModels;

namespace TextProcess.Database
{
	public class ApplicationContext : DbContext
	{
		public DbSet<SourceText> SourceTexts { get; set; }
		public DbSet<GeneratedSentence> GeneratedSentences { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
	}
}