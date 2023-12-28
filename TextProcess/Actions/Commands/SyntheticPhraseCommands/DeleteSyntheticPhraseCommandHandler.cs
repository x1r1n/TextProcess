using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;

namespace TextProcess.Actions.Commands.SyntheticPhraseCommands
{
    public class DeleteSyntheticPhraseCommandHandler : IRequestHandler<DeleteSyntheticPhraseCommand>
    {
        private readonly ApplicationContext _context;

        public DeleteSyntheticPhraseCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteSyntheticPhraseCommand request, CancellationToken cancellationToken)
        {
            await _context.SyntheticPhrase
                .Where(p => p.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
