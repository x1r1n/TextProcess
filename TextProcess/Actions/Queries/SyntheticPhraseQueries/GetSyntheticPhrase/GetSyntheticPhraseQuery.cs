using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SyntheticPhraseQueries.GetSyntheticPhrase
{
	public class GetSyntheticPhraseQuery : IRequest<SyntheticPhraseDto>
	{
		public int Id { get; set; }
	}
}
