namespace TextProcess.Database.DbModels
{
	public class SourceTexts : BaseModel
	{
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? GenerationWords { get; set; }
		public List<GeneratedSentences>? GeneratedSentences { get; set; }
	}
}