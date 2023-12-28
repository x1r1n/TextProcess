using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SourceTextQueries.GetSourceText
{
	public class GetSourceTextQuery : IRequest<SourceTextDto>
	{
		public int Id { get; set; }
	}
}
