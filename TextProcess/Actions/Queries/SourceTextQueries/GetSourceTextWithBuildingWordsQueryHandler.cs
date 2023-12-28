using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;
using TextProcess.DTO;

#nullable disable

namespace TextProcess.Actions.Queries.SourceTextQueries
{
    public class GetSourceTextWithBuildingWordsQueryHandler
        : IRequestHandler<GetSourceTextWithBuildingWordsQuery, SourceTextWithBuildingWordsDto>
    {
        private readonly ApplicationContext _context;

        public GetSourceTextWithBuildingWordsQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SourceTextWithBuildingWordsDto> Handle(
            GetSourceTextWithBuildingWordsQuery request,
            CancellationToken cancellationToken)
        {
            var text = await _context.SourceText
            .AsNoTracking()
            .Where(t => t.Id == request.Id)
            .Select(t => new SourceTextWithBuildingWordsDto
            {
                Id = t.Id,
                Content = t.Content,
                BuildingWords = t.BuildingWords
            })
            .FirstOrDefaultAsync(cancellationToken);

            return text;
        }
    }
}
