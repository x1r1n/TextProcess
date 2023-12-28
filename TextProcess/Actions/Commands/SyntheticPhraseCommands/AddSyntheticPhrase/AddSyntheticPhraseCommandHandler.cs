using MediatR;
using TextProcess.Database;
using TextProcess.Database.DbModels;
using TextProcess.DTO;

namespace TextProcess.Actions.Commands.SyntheticPhraseCommands.AddSyntheticPhrase
{
    public class AddSyntheticPhraseCommandHandler : IRequestHandler<AddSyntheticPhraseCommand, SyntheticPhraseDto>
    {
        private readonly ApplicationContext _context;

        public AddSyntheticPhraseCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SyntheticPhraseDto> Handle(AddSyntheticPhraseCommand request, CancellationToken cancellationToken)
        {
            await _context.SyntheticPhrase.AddAsync(
                new SyntheticPhrase
                {
                    Phrase = request.Phrase,
                    SourceTextId = request.SourceTextId
                }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new SyntheticPhraseDto
            {
                Phrase = request.Phrase,
                SourceTextId = request.SourceTextId
            };
        }
    }
}
