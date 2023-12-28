using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class DeleteAllSourceTextsCommandHandler : IRequestHandler<DeleteAllSourceTextsCommand>
    {
        private readonly ApplicationContext _context;

        public DeleteAllSourceTextsCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteAllSourceTextsCommand request, CancellationToken cancellationToken)
        {
            await _context.SourceText.ExecuteDeleteAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
