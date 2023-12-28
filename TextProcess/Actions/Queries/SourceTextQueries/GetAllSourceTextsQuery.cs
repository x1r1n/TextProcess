using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SourceTextQueries
{
    public class GetAllSourceTextsQuery : IRequest<List<SourceTextDto>>
    {
    }
}
