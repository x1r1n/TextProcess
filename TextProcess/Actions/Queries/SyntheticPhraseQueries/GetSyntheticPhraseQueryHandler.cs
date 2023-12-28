using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;
using TextProcess.DTO;

#nullable disable

namespace TextProcess.Actions.Queries.SyntheticPhraseQueries
{
    public class GetSyntheticPhraseQueryHandler : IRequestHandler<GetSyntheticPhraseQuery, SyntheticPhraseDto>
    {
        private readonly ApplicationContext _context;

        public GetSyntheticPhraseQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SyntheticPhraseDto> Handle(GetSyntheticPhraseQuery request, CancellationToken cancellationToken)
        {
            var phrase = await _context.SyntheticPhrase
                .AsNoTracking()
                .Where(p => p.Id == request.Id)
                .Select(p => new SyntheticPhraseDto
                {
                    Id = p.Id,
                    Phrase = p.Phrase,
                    SourceTextId = p.SourceTextId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return phrase;
        }
    }
}
