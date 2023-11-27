using Mapster;
using Microsoft.AspNetCore.Mvc;
using TextProcess.Database.Repositories;
using TextProcess.DTO;
using TextProcess.Services.Interfaces;

namespace TextProcess.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GeneratedSentencesController : ControllerBase
	{
		private readonly TextRepository _repository;
		private readonly ISentenceGeneratorService _sentenceGenerator;

		public GeneratedSentencesController(
			TextRepository repository,
			ISentenceGeneratorService sentenceGenerator)
		{
			_repository = repository;
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

			var sentencesDto = sentences.Adapt<List<SentenceDto>>();

			return Ok(sentencesDto);
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

			var sentenceDto = sentence.Adapt<SentenceDto>();

			return Ok(sentenceDto);
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

			if (sourceText is null)
			{
				return NotFound(sourceTextId);
			}

			var newSentence = await _sentenceGenerator.GenerateSentenceAsync(sourceText, phraseBeginning, wordsCount);

			return Created("", newSentence);
		}
	}
}