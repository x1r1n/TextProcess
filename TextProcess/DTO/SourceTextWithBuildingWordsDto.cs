using Microsoft.Identity.Client;

namespace TextProcess.DTO
{
	public class SourceTextWithBuildingWordsDto
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public string? BuildingWords { get; set; }
	}
}
