namespace TextProcess.Database.DbModels
{
	public class SourceText : BaseModel
	{
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? GenerationWords { get; set; }
		public List<GeneratedSentence>? GeneratedSentences { get; set; }
	}
}