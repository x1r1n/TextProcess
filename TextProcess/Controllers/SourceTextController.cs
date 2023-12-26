using Mapster;
using Microsoft.AspNetCore.Mvc;
using TextProcess.Database.DbModels;
using TextProcess.Database.Repositories;
using TextProcess.DTO;

namespace TextProcess.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SourceTextController : ControllerBase
	{
		private readonly TextRepository _repository;

		public SourceTextController(TextRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAllSourceTexts()
		{
			var sourceTexts = await _repository.GetAllTextsAsync();

			if (sourceTexts is null || sourceTexts.Count == 0)
			{
				return NotFound();
			}

			var sourceTextsDto = sourceTexts.Adapt<List<SourceTextDto>>();

			return Ok(sourceTextsDto);
		}

		[HttpGet("GetById/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetSourceText(int id)
		{
			var sourceText = await _repository.GetTextAsync(id);

			if (sourceText is null)
			{
				return NotFound();
			}

			var sourceTextDto = sourceText.Adapt<SourceTextDto>();

			return Ok(sourceTextDto);
		}

		[HttpPost("Add")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> AddSourceText([FromForm] string title, [FromForm] string text)
		{
			var newSourceText = new SourceText { Title = title, Content = text };

			await _repository.AddTextAsync(newSourceText);

			var newSourceTextDto = newSourceText.Adapt<SourceTextDto>();

			return Created("", newSourceTextDto);
		}

		[HttpDelete("DeleteAll")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteAllSourceTexts()
		{
			await _repository.DeleteAllTextsAsync();

			return NoContent();
		}

		[HttpDelete("DeleteById/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteSourceText(int id)
		{
			await _repository.DeleteTextAsync(id);

			return NoContent();
		}
	}
}