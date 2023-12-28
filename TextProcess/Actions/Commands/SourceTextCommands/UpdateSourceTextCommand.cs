using MediatR;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class UpdateSourceTextCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
