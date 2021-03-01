using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using System.Collections.Generic;

namespace Agency.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IList<string> commandParameters)
        {
            this.CommandParameters = new List<string>(commandParameters);
        }

        public abstract string Execute();

        protected IList<string> CommandParameters
        {
            get;
        }

        protected IDatabase Database
        {
            get
            {
                return Core.Database.Instance;
            }
        }
        
        protected IFactory Factory
        {
            get
            {
                return Core.Factory.Instance;
            }
        }
    }
}
