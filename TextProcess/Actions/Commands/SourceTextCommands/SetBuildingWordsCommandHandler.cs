using MediatR;
using Microsoft.EntityFrameworkCore;
using TextProcess.Database;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class SetBuildingWordsCommandHandler : IRequestHandler<SetBuildingWordsCommand>
    {
        private readonly ApplicationContext _context;

        public SetBuildingWordsCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(SetBuildingWordsCommand request, CancellationToken cancellationToken)
        {
            await _context.SourceText
                .Where(t => t.Id == request.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.BuildingWords, t => request.BuildingWords), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
