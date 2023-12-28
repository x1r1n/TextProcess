using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SyntheticPhraseQueries
{
    public class GetAllSyntheticPhrasesQuery : IRequest<List<SyntheticPhraseDto>>
    {
    }
}
