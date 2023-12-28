using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;

namespace TextProcess.Actions.Commands.SyntheticPhraseCommands.DeleteAllSyntheticPhrases
{
    public class DeleteAllSyntheticPhrasesCommandHandler : IRequestHandler<DeleteAllSyntheticPhrasesCommand>
    {
        private readonly ApplicationContext _context;

        public DeleteAllSyntheticPhrasesCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteAllSyntheticPhrasesCommand request, CancellationToken cancellationToken)
        {
            await _context.SyntheticPhrase.ExecuteDeleteAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
