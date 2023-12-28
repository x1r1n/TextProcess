using MediatR;

namespace TextProcess.Actions.Commands.SourceTextCommands
{
    public class SetBuildingWordsCommand : IRequest
    {
        public int Id { get; set; }
        public string? BuildingWords { get; set; }
    }
}
