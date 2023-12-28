using MediatR;
using TextProcess.Database;
using TextProcess.Database.DbModels;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class AddSourceTextCommandHandler : IRequestHandler<AddSourceTextCommand>
    {
        private readonly ApplicationContext _context;

        public AddSourceTextCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(AddSourceTextCommand request, CancellationToken cancellationToken)
        {
            await _context.SourceText.AddAsync(
                new SourceText
                {
                    Title = request.Title,
                    Content = request.Content
                },
                cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}