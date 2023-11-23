using Microsoft.EntityFrameworkCore;
using TextProcess.Database.DbModels;

#nullable disable

namespace TextProcess.Database.Repositories
{
	public class TextProcessRepository
	{
		private ApplicationContext _context;
		private DbSet<SourceTexts> _sourceTexts;
		private DbSet<GeneratedSentences> _generatedSentences;

		public TextProcessRepository(ApplicationContext context)
		{
			_context = context;
			_sourceTexts = _context.Set<SourceTexts>();
			_generatedSentences = _context.Set<GeneratedSentences>();
		}

		public async Task<List<SourceTexts>> GetAllTextsAsync()
		{
			return await _sourceTexts.ToListAsync();
		}

		public async Task<SourceTexts> GetTextAsync(int id)
		{
			return await _sourceTexts.FindAsync(id);
		}

		public async Task UpdateTextAsync(SourceTexts updateText)
		{
			var text = await _sourceTexts.FindAsync(updateText.Id);

			text.GenerationWords = updateText.GenerationWords;
			text.GeneratedSentences = updateText.GeneratedSentences;

			await _context.SaveChangesAsync();
		}

		public async Task AddTextAsync(SourceTexts text)
		{
			await _sourceTexts.AddAsync(text);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAllTextsAsync()
		{
			_sourceTexts.RemoveRange(await GetAllTextsAsync());
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTextAsync(int id)
		{
			_sourceTexts.Remove(await GetTextAsync(id));
			await _context.SaveChangesAsync();
		}

		public async Task<List<GeneratedSentences>> GetAllSentencesAsync()
		{
			return await _generatedSentences.ToListAsync();
		}

		public async Task<GeneratedSentences> GetSentenceAsync(int id)
		{
			return await _generatedSentences.FindAsync(id);
		}

		public async Task AddSentenceAsync(GeneratedSentences sentence)
		{
			await _generatedSentences.AddAsync(sentence);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAllSentencesAsync()
		{
			_generatedSentences.RemoveRange(GetAllSentencesAsync().Result);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteSentenceAsync(int id)
		{
			_generatedSentences.Remove(await GetSentenceAsync(id));
			await _context.SaveChangesAsync();
		}
	}
}