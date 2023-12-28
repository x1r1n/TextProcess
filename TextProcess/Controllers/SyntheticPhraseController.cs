using MediatR;
using Microsoft.AspNetCore.Mvc;
using TextProcess.Actions.Commands.SyntheticPhraseCommands.DeleteAllSyntheticPhrases;
using TextProcess.Actions.Commands.SyntheticPhraseCommands.DeleteSyntheticPhrase;
using TextProcess.Actions.Queries.SourceTextQueries.GetSourceTextWithBuildingWords;
using TextProcess.Actions.Queries.SyntheticPhraseQueries.GetAllSyntheticPhrases;
using TextProcess.Actions.Queries.SyntheticPhraseQueries.GetSyntheticPhrase;
using TextProcess.Services.Interfaces;

namespace TextProcess.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SyntheticPhraseController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IPhraseGeneratorService _sentenceGenerator;

		public SyntheticPhraseController(
			IMediator mediator,
			IPhraseGeneratorService sentenceGenerator)
		{
			_mediator = mediator;
			_sentenceGenerator = sentenceGenerator;
		}

		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetAllSyntheticPhrases(CancellationToken token)
		{
			var sentences = await _mediator.Send(new GetAllSyntheticPhrasesQuery(), token);

			if (sentences is null || sentences.Count == 0)
			{
				return NotFound();
			}

			return Ok(sentences);
		}

		[HttpGet("GetById/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetSyntheticPhrase(GetSyntheticPhraseQuery request, CancellationToken token)
		{
			var sentence = await _mediator.Send(request, token);

			if (sentence is null)
			{
				return NotFound();
			}

			return Ok(sentence);
		}

		[HttpPost("Generate")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GenerateSyntheticPhrase(
			[FromForm] int sourceTextId, 
			[FromForm] string phraseBeginning, 
			[FromForm] int wordsCount,
			CancellationToken token)
		{
			var sourceText = await _mediator.Send(new GetSourceTextWithBuildingWordsQuery
			{
				Id = sourceTextId
			}, token); 

			if (sourceText is null)
			{
				return NotFound(sourceTextId);
			}

			var newSentence = await _sentenceGenerator.GeneratePhraseAsync(sourceText, phraseBeginning, wordsCount, token);

			return Created("", newSentence);
		}

		[HttpDelete("DeleteAll")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> DeleteAllSyntheticPhrases(CancellationToken token)
		{
			await _mediator.Send(new DeleteAllSyntheticPhrasesCommand(), token);

			return NoContent();
		}

		[HttpDelete("DeleteById")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> DeleteSyntheticPhrases(DeleteSyntheticPhraseCommand request, CancellationToken token)
		{
			await _mediator.Send(request, token);

			return NoContent();
		}
	}
}