using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SourceTextQueries.GetAllSourceTexts
{
	public class GetAllSourceTextsQuery : IRequest<List<SourceTextDto>>
	{
	}
}
