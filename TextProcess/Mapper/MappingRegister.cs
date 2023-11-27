using Mapster;
using TextProcess.Database.DbModels;
using TextProcess.DTO;

namespace TextProcess.Mapper
{
	public class MappingRegister : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<SourceText, TextDto>()
				.RequireDestinationMemberSource(true);

			config.NewConfig<GeneratedSentence, SentenceDto>()
				.RequireDestinationMemberSource(true);
		}
	}
}