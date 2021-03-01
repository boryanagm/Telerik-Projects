using System.Collections.Generic;

using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Contracts
{
    public interface IOlympicCommittee
    {
        IReadOnlyList<IOlympian> Olympians { get; }

        void Add(IOlympian olympian);
    }
}
