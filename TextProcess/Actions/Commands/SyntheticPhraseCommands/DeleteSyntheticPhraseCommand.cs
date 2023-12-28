using MediatR;

namespace TextProcess.Actions.Commands.SyntheticPhraseCommands
{
    public class DeleteSyntheticPhraseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
