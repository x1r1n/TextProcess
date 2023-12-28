using MediatR;
using TextProcess.DTO;

namespace TextProcess.Actions.Commands.SyntheticPhraseCommands
{
    public class AddSyntheticPhraseCommand : IRequest<SyntheticPhraseDto>
    {
        public string? Phrase { get; set; }
        public int SourceTextId { get; set; }
    }
}
