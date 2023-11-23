using System.ComponentModel.DataAnnotations;

namespace TextProcess.Database.DbModels
{
	public abstract class BaseModel
	{
		[Key]
		public int Id { get; set; }
	}
}