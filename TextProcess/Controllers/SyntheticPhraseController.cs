using Mapster;
using Microsoft.AspNetCore.Mvc;
using TextProcess.Database.Repositories;
using TextProcess.DTO;
using TextProcess.Services.Interfaces;

namespace TextProcess.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SyntheticPhraseController : ControllerBase
	{
		private readonly TextRepository _repository;
		private readonly IPhraseGeneratorService _sentenceGenerator;

		public SyntheticPhraseController(
			TextRepository repository,
			IPhraseGeneratorService sentenceGenerator)
		{
			_repository = repository;
			_sentenceGenerator = sentenceGenerator;
		}

		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAllSyntheticPhrases()
		{
			var sentences = await _repository.GetAllPhrasesAsync();

			if (sentences is null || sentences.Count == 0)
			{
				return NotFound();
			}

			var sentencesDto = sentences.Adapt<List<SyntheticPhraseDto>>();

			return Ok(sentencesDto);
		}

		[HttpGet("GetById/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetSyntheticPhrase(int id)
		{
			var sentence = await _repository.GetPhraseAsync(id);

			if (sentence is null)
			{
				return NotFound();
			}

			var sentenceDto = sentence.Adapt<SyntheticPhraseDto>();

			return Ok(sentenceDto);
		}

		[HttpPost("Generate")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GeneratePhrase(
			[FromForm] int sourceTextId, 
			[FromForm] string phraseBeginning, 
			[FromForm] int wordsCount)
		{
			var sourceText = await _repository.GetTextAsync(sourceTextId); 

			if (sourceText is null)
			{
				return NotFound(sourceTextId);
			}

			var newSentence = await _sentenceGenerator.GeneratePhraseAsync(sourceText, phraseBeginning, wordsCount);

			return Created("", newSentence);
		}
	}
}