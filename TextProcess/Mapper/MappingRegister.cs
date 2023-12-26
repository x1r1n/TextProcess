using Mapster;
using TextProcess.Database.DbModels;
using TextProcess.DTO;

namespace TextProcess.Mapper
{
	public class MappingRegister : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<SourceText, SourceTextDto>()
				.RequireDestinationMemberSource(true);

			config.NewConfig<SyntheticPhrase, SyntheticPhraseDto>()
				.RequireDestinationMemberSource(true);
		}
	}
}