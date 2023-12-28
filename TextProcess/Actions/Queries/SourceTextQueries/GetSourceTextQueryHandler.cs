using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;
using TextProcess.DTO;

#nullable disable

namespace TextProcess.Actions.Queries.SourceTextQueries
{
    public class GetSourceTextQueryHandler : IRequestHandler<GetSourceTextQuery, SourceTextDto>
    {
        private readonly ApplicationContext _context;

        public GetSourceTextQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SourceTextDto> Handle(GetSourceTextQuery request, CancellationToken cancellationToken)
        {
            var text = await _context.SourceText
                .AsNoTracking()
                .Where(t => t.Id == request.Id)
                .Select(t => new SourceTextDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Content = t.Content
                })
                .FirstOrDefaultAsync(cancellationToken);

            return text;
        }
    }
}
