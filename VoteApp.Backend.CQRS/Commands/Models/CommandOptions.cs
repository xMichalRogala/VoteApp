namespace VoteApp.Backend.CQRS.Commands.Models
{
    public class CommandOptions
    {
        public bool AllowCommandExecuteByMoreThanOneCommandHandler { get; set; }
    }
}
