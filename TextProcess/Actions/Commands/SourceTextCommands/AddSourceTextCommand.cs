using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class AddSourceTextCommand : IRequest
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
