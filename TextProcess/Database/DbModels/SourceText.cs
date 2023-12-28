namespace TextProcess.Database.DbModels
{
	public class SourceText : BaseModel
	{
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? BuildingWords { get; set; }
		public List<SyntheticPhrase>? SyntheticPhrases { get; set; }
	}
}