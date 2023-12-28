using MediatR;

namespace TextProcess.Actions.Commands.SourceTextCommands.SetBuildingWords
{
    public class SetBuildingWordsCommand : IRequest
    {
        public int Id { get; set; }
        public string? BuildingWords { get; set; }
    }
}
