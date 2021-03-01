using System.Collections.Generic;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Providers
{
    public class OlympicCommittee : IOlympicCommittee
    {
        private readonly List<IOlympian> olympians = new List<IOlympian>();

        public IReadOnlyList<IOlympian> Olympians
        {
            get
            {
                return this.olympians;
            }
        }

        public void Add(IOlympian olympian) 
        {
            olympians.Add(olympian);
        }
    }
}
