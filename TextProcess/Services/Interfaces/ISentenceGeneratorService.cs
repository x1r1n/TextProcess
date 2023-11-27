using TextProcess.Database.DbModels;
using TextProcess.DTO;

namespace TextProcess.Services.Interfaces
{
	public interface ISentenceGeneratorService
	{
		Task<SentenceDto> GenerateSentenceAsync(SourceText sourceTextId, string phraseBeginning, int wordsCount);
	}
}
