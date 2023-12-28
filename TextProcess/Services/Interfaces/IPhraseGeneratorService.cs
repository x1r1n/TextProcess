using TextProcess.Database.DbModels;
using TextProcess.DTO;

namespace TextProcess.Services.Interfaces
{
	public interface IPhraseGeneratorService
	{
		Task<SyntheticPhraseDto> GeneratePhraseAsync(
			SourceTextWithBuildingWordsDto sourceTextId, 
			string phraseBeginning, 
			int wordsCount, 
			CancellationToken token);
	}
}
