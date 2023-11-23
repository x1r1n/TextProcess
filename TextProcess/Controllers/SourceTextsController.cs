using Microsoft.AspNetCore.Mvc;
using TextProcess.Database.DbModels;
using TextProcess.Database.Repositories;

namespace TextProcess.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SourceTextsController : ControllerBase
	{
		private readonly TextProcessRepository _repository;

		public SourceTextsController(TextProcessRepository repository)
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

			return Ok(sourceTexts);
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

			return Ok(sourceText);
		}

		[HttpPost("Add")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> AddSourceText([FromForm] string title, [FromForm] string text)
		{
			var newSourceText = new SourceTexts { Title = title, Content = text };

			await _repository.AddTextAsync(newSourceText);

			return Created();
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