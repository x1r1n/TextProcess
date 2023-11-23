namespace TextProcess.Database.DbModels
{
	public class GeneratedSentences : BaseModel
	{
		public string? Sentence { get; set; }
		public int TextTitleId { get; set; }
		public SourceTexts? TextTitle { get; set; }
	}
}