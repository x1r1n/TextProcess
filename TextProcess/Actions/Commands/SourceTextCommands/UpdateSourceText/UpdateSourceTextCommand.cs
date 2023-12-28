using MediatR;

namespace TextProcess.Actions.Commands.SourceTextCommands.UpdateSourceText
{
    public class UpdateSourceTextCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
