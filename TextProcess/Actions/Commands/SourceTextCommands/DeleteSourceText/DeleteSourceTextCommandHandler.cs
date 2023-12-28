using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;

namespace TextProcess.Actions.Commands.SourceTextCommands.DeleteSourceText
{
    public class DeleteSourceTextCommandHandler : IRequestHandler<DeleteSourceTextCommand>
    {
        private readonly ApplicationContext _context;

        public DeleteSourceTextCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteSourceTextCommand request, CancellationToken cancellationToken)
        {
            await _context.SourceText
                .Where(t => t.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
