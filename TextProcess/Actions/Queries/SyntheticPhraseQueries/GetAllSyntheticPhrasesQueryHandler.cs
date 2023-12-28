using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;
using TextProcess.DTO;

namespace TextProcess.Actions.Queries.SyntheticPhraseQueries
{
    public class GetAllSyntheticPhrasesQueryHandler : IRequestHandler<GetAllSyntheticPhrasesQuery, List<SyntheticPhraseDto>>
    {
        private readonly ApplicationContext _context;

        public GetAllSyntheticPhrasesQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SyntheticPhraseDto>> Handle(GetAllSyntheticPhrasesQuery request, CancellationToken cancellationToken)
        {
            var phrases = await _context.SyntheticPhrase
                .AsNoTracking()
                .Select(p => new SyntheticPhraseDto
                {
                    Id = p.Id,
                    Phrase = p.Phrase,
                    SourceTextId = p.SourceTextId
                })
                .ToListAsync(cancellationToken);

            return phrases;
        }
    }
}
