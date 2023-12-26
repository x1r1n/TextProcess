namespace TextProcess.Database.DbModels
{
	public class SyntheticPhrase : BaseModel
	{
		public string? Phrase { get; set; }
		public int SourceTextId { get; set; }
		public SourceText? SourceText { get; set; }
	}
}