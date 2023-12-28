using MediatR;

namespace TextProcess.Actions.Commands.SourceTextCommands.DeleteSourceText
{
    public class DeleteSourceTextCommand : IRequest
    {
        public int Id { get; set; }
    }
}
