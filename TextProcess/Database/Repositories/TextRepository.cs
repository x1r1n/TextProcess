using Microsoft.EntityFrameworkCore;
using TextProcess.Database.DbModels;

#nullable disable

namespace TextProcess.Database.Repositories
{
	public class TextRepository
	{
		private ApplicationContext _context;
		private DbSet<SourceText> _sourceTexts;
		private DbSet<GeneratedSentence> _generatedSentences;

		public TextRepository(ApplicationContext context)
		{
			_context = context;
			_sourceTexts = _context.Set<SourceText>();
			_generatedSentences = _context.Set<GeneratedSentence>();
		}

		public async Task<List<SourceText>> GetAllTextsAsync()
		{
			return await _sourceTexts.ToListAsync();
		}

		public async Task<SourceText> GetTextAsync(int id)
		{
			return await _sourceTexts.FindAsync(id);
		}

		public async Task UpdateTextAsync(SourceText updateText)
		{
			var text = await _sourceTexts.FindAsync(updateText.Id);

			text.GenerationWords = updateText.GenerationWords;
			text.GeneratedSentences = updateText.GeneratedSentences;

			await _context.SaveChangesAsync();
		}

		public async Task AddTextAsync(SourceText text)
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

		public async Task<List<GeneratedSentence>> GetAllSentencesAsync()
		{
			return await _generatedSentences.ToListAsync();
		}

		public async Task<GeneratedSentence> GetSentenceAsync(int id)
		{
			return await _generatedSentences.FindAsync(id);
		}

		public async Task AddSentenceAsync(GeneratedSentence sentence)
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