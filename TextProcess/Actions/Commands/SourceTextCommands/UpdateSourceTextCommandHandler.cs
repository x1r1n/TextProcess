using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class UpdateSourceTextCommandHandler : IRequestHandler<UpdateSourceTextCommand>
    {
        private readonly ApplicationContext _context;

        public UpdateSourceTextCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSourceTextCommand request, CancellationToken cancellationToken)
        {
            await _context.SourceText
                .Where(t => t.Id == request.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.Title, t => request.Title)
                .SetProperty(t => t.Content, t => request.Content), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
