using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreatures.Models
{
    class AttackerBestTargetPair
    {
        public AttackerBestTargetPair(Creature attacker, Creature bestTarget)
        {
            this.Attacker = attacker ?? throw new ArgumentNullException();
            this.BestTarget = bestTarget ?? throw new ArgumentNullException();
        }

        public Creature Attacker
        {
            get;
        }
        public Creature BestTarget
        {
            get;
        }
    }
}
