using Mapster;
using Microsoft.IdentityModel.Tokens;
using PhraseForge.Interfaces;
using TextProcess.Database.DbModels;
using TextProcess.Database.Repositories;
using TextProcess.DTO;
using TextProcess.Services.Interfaces;
using TextProcess.Utilities;

namespace TextProcess.Services
{
    public class PhraseGeneratorService : IPhraseGeneratorService
	{
        private readonly TextRepository _repository;
        private readonly ISentencesParser _sentenceParser;
        private readonly IFrequencyAnalysis _frequencyAnalysis;
        private readonly ISentenceGenerator _sentenceGenerator;

        public PhraseGeneratorService(
            TextRepository repository,
            ISentencesParser sentencesParser,
            IFrequencyAnalysis frequencyAnalysis,
            ISentenceGenerator sentenceGenerator)
        {
            _repository = repository;
            _sentenceParser = sentencesParser;
            _frequencyAnalysis = frequencyAnalysis;
            _sentenceGenerator = sentenceGenerator;
        }

        public async Task<SyntheticPhraseDto> GeneratePhraseAsync(SourceText sourceText, string phraseBeginning, int wordsCount)
        {
            Dictionary<string, string> buildingWords;

            if (sourceText.GenerationWords.IsNullOrEmpty())
            {
                buildingWords = await InitializeBuildingWordsAsync(sourceText);
            }
            else
            {
                buildingWords = DeserializeBuildingWords(sourceText.GenerationWords!);
            }

            var sentence = new SyntheticPhraseDto
            {
                Phrase = _sentenceGenerator.ContinuePhrase(buildingWords, phraseBeginning, wordsCount),
                SourceTextId = sourceText.Id
            };

            await _repository.AddPhraseAsync(sentence.Adapt<SyntheticPhrase>());

            return sentence;
        }

        private async Task<Dictionary<string, string>> InitializeBuildingWordsAsync(SourceText sourceText)
        {
            var parsedSentences = _sentenceParser.ParseSentences(sourceText.Content!);
            var buildingWords = _frequencyAnalysis.GetMostFrequentWords(parsedSentences);
            
            sourceText.GenerationWords = SerializeBuildingWords(buildingWords);

            await _repository.UpdateTextAsync(sourceText);

            return buildingWords!;
        }

        private string SerializeBuildingWords(Dictionary<string, string> buildingWords)
        {
			var serializer = new XmlSerializer();
			return serializer.DictionaryToXml(buildingWords!);
		}

        private Dictionary<string, string> DeserializeBuildingWords(string xml)
        {
            var serializer = new XmlSerializer();
            return serializer.XmlToDictionary(xml);
        }
    }
}