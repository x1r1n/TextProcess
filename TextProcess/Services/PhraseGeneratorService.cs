using MediatR;
using Microsoft.IdentityModel.Tokens;
using PhraseForge.Interfaces;
using TextProcess.Actions.Commands.SourceTextCommands.SetBuildingWords;
using TextProcess.Actions.Commands.SyntheticPhraseCommands.AddSyntheticPhrase;
using TextProcess.DTO;
using TextProcess.Services.Interfaces;
using TextProcess.Utilities;

namespace TextProcess.Services
{
    public class PhraseGeneratorService : IPhraseGeneratorService
	{
        private readonly IMediator _mediator;
        private readonly ISentencesParser _sentenceParser;
        private readonly IFrequencyAnalysis _frequencyAnalysis;
        private readonly ISentenceGenerator _sentenceGenerator;

        public PhraseGeneratorService(
            IMediator mediator,
            ISentencesParser sentencesParser,
            IFrequencyAnalysis frequencyAnalysis,
            ISentenceGenerator sentenceGenerator)
        {
            _mediator = mediator;
            _sentenceParser = sentencesParser;
            _frequencyAnalysis = frequencyAnalysis;
            _sentenceGenerator = sentenceGenerator;
        }

        public async Task<SyntheticPhraseDto> GeneratePhraseAsync(
            SourceTextWithBuildingWordsDto sourceText, 
            string phraseBeginning, 
            int wordsCount,
            CancellationToken token)
        {
            Dictionary<string, string> buildingWords;

            if (sourceText.BuildingWords.IsNullOrEmpty())
            {
                buildingWords = await InitializeBuildingWordsAsync(sourceText, token);
            }
            else
            {
                buildingWords = DeserializeBuildingWords(sourceText.BuildingWords!);
            }

            var phrase = await _mediator.Send(new AddSyntheticPhraseCommand
            {
                Phrase = _sentenceGenerator.ContinuePhrase(buildingWords, phraseBeginning, wordsCount),
                SourceTextId = sourceText.Id
            });

            return phrase;
        }

        private async Task<Dictionary<string, string>> InitializeBuildingWordsAsync(
            SourceTextWithBuildingWordsDto sourceText,
            CancellationToken token)
        {
            var parsedSentences = _sentenceParser.ParseSentences(sourceText.Content!);
            var buildingWords = _frequencyAnalysis.GetMostFrequentWords(parsedSentences);
            
            sourceText.BuildingWords = SerializeBuildingWords(buildingWords);

            await _mediator.Send(new SetBuildingWordsCommand
            {
                Id = sourceText.Id,
                BuildingWords = sourceText.BuildingWords,
            }, token);

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