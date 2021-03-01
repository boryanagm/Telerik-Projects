using Agency.Commands.Contracts;

namespace Agency.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string commandLine);
    }
}
