namespace TextProcess.Database.DbModels
{
	public class GeneratedSentence : BaseModel
	{
		public string? Sentence { get; set; }
		public int TextId { get; set; }
		public SourceText? Text { get; set; }
	}
}