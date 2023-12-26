using TextProcess.Database.DbModels;
using TextProcess.DTO;

namespace TextProcess.Services.Interfaces
{
	public interface IPhraseGeneratorService
	{
		Task<SyntheticPhraseDto> GeneratePhraseAsync(SourceText sourceTextId, string phraseBeginning, int wordsCount);
	}
}
