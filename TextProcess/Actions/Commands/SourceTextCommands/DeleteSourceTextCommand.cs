using MediatR;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class DeleteSourceTextCommand : IRequest
    {
        public int Id { get; set; }
    }
}
