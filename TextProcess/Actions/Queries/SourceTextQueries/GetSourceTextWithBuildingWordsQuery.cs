using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SourceTextQueries
{
    public class GetSourceTextWithBuildingWordsQuery : IRequest<SourceTextWithBuildingWordsDto>
    {
        public int Id { get; set; }
    }
}
