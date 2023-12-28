using MediatR;

namespace TextProcess.Actions.Commands.SyntheticPhraseCommands.DeleteSyntheticPhrase
{
    public class DeleteSyntheticPhraseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
