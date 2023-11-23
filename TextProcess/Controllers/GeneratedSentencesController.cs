using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TextAnalysis.Interfaces;
using TextProcess.Database.DbModels;
using TextProcess.Database.Repositories;
using TextProcess.Utilities;

namespace TextProcess.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GeneratedSentencesController : ControllerBase
	{
		private readonly TextProcessRepository _repository;
		private readonly ISentencesParser _sentenceParser;
		private readonly IFrequencyAnalysis _frequencyAnalysis;
		private readonly ISentenceGenerator _sentenceGenerator;

		public GeneratedSentencesController(
			TextProcessRepository repository,
			ISentencesParser sentencesParser,
			IFrequencyAnalysis frequencyAnalysis,
			ISentenceGenerator sentenceGenerator)
		{
			_repository = repository;
			_sentenceParser = sentencesParser;
			_frequencyAnalysis = frequencyAnalysis;
			_sentenceGenerator = sentenceGenerator;
		}

		[HttpGet("GetAllGeneratedSentences")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAllGeneratedSentences()
		{
			var sentences = await _repository.GetAllSentencesAsync();

			if (sentences is null || sentences.Count == 0)
			{
				return NotFound();
			}

			return Ok(sentences);
		}

		[HttpGet("GetGeneratedSentence/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetGeneratedSentence(int id)
		{
			var sentence = await _repository.GetSentenceAsync(id);

			if (sentence is null)
			{
				return NotFound();
			}

			return Ok(sentence);
		}

		[HttpPost("GenerateSentence")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GenerateSentence(
			[FromForm] int sourceTextId, 
			[FromForm] string phraseBeginning, 
			[FromForm] int wordsCount)
		{
			var sourceText = await _repository.GetTextAsync(sourceTextId);
			Dictionary<string, string> buildingWords;

			if (sourceText is null)
			{
				return BadRequest(sourceTextId);
			}

			if (sourceText.GenerationWords.IsNullOrEmpty())
			{
				var parsedSentences = _sentenceParser.ParseSentences(sourceText.Content!);
				buildingWords = _frequencyAnalysis.GetMostFrequentWords(parsedSentences)!;

				var serializer = new Serializer();
				sourceText.GenerationWords = serializer.SerializeDictionaryToXml(buildingWords);

				await _repository.UpdateTextAsync(sourceText);
			}
			else
			{
				var serializer = new Serializer();
				buildingWords = serializer.DeserializeXmlToDictionary(sourceText.GenerationWords!);
			}

			var sentence = new GeneratedSentences
			{
				Sentence = _sentenceGenerator.ContinuePhrase(buildingWords, phraseBeginning, wordsCount),
				TextTitleId = sourceText.Id,
				TextTitle = sourceText
			};

			await _repository.AddSentenceAsync(sentence);

			return Created();
		}
	}
}