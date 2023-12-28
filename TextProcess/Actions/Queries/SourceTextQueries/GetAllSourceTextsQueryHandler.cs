using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SourceTextQueries
{
    public class GetAllSourceTextsQueryHandler : IRequestHandler<GetAllSourceTextsQuery, List<SourceTextDto>>
    {
        private readonly ApplicationContext _context;

        public GetAllSourceTextsQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SourceTextDto>> Handle(GetAllSourceTextsQuery request, CancellationToken cancellationToken)
        {
            var texts = await _context.SourceText
                .AsNoTracking()
                .Select(t => new SourceTextDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Content = t.Content
                })
                .ToListAsync(cancellationToken);

            return texts;
        }
    }
}
