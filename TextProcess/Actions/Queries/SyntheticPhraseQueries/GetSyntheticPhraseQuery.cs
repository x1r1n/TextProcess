using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SyntheticPhraseQueries
{
    public class GetSyntheticPhraseQuery : IRequest<SyntheticPhraseDto>
    {
        public int Id { get; set; }
    }
}
