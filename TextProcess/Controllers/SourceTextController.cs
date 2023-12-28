using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using TextProcess.Actions.Queries.SourceTextQueries;
using TextProcess.Actions.Commands.SourceTextCommands;

namespace TextProcess.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class SourceTextController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SourceTextController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetAllSourceTexts(CancellationToken token)
		{
			var sourceTexts = await _mediator.Send(new GetAllSourceTextsQuery(), token);

			if (sourceTexts is null || sourceTexts.Count == 0)
			{
				return NotFound();
			}

			return Ok(sourceTexts);
		}

		[HttpGet("GetById")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetSourceText([FromQuery] GetSourceTextQuery request, CancellationToken token)
		{
			var sourceText = await _mediator.Send(request, token);

			if (sourceText is null)
			{
				return NotFound();
			}

			return Ok(sourceText);
		}

		[HttpPost("Add")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> AddSourceText([FromForm] AddSourceTextCommand request, CancellationToken token)
		{
			if (request.Title.IsNullOrEmpty() || request.Content.IsNullOrEmpty())
			{
				return BadRequest(request);
			}

			await _mediator.Send(request, token);

			return Ok(request);
		}

		[HttpDelete("DeleteAll")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> DeleteAllSourceTexts(CancellationToken token)
		{
			await _mediator.Send(new DeleteAllSourceTextsCommand(), token);

			return NoContent();
		}

		[HttpDelete("DeleteById/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> DeleteSourceText([FromForm] DeleteSourceTextCommand request, CancellationToken token)
		{
			await _mediator.Send(request, token);

			return NoContent();
		}
	}
}