using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SyntheticPhraseQueries.GetAllSyntheticPhrases
{
	public class GetAllSyntheticPhrasesQuery : IRequest<List<SyntheticPhraseDto>>
	{
	}
}
