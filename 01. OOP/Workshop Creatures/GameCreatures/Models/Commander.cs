using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCreatures.Models
{
    public class Commander
    {
        private readonly List<Creature> army;

        public Commander(string name, List<Creature> army)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            if (army == null)
            {
                throw new ArgumentNullException("Army list cannot be null");
            }

            this.Name = name; //OR this.Name = name ?? throw new ArgumentNullException(); 
            this.army = army;
        }

        public string Name
        {
            get;
        }

        public int ArmySize
        {
            get
            {
                return this.army.Count;
            }
        }

        public List<Creature> Army
        {
            get
            {
                return this.army;
            }
        }


        public void AttackAtPosition(Commander enemy, int attackerIndex, int targetIndex)
        {
            Creature target = enemy.Army[targetIndex];

            Creature attacker = this.Army[attackerIndex];

            AttackEnemyCreature(enemy, attacker, target);
        }

        public void AttackEnemyCreature(Commander enemy, Creature attacker, Creature target) // OR overload of AttackAtPositon(Commander enemy, Creature attacker, Creature target)
        {
            attacker.Attack(target);

            if (target.HealthPoints == 0)
            {
                enemy.Army.Remove(target);
            }
        }

        //public void AutoAttack(Commander enemy) - Usiang a Dictionary;
        //{
        //    Dictionary<Creature, Creature> bestMatches = new Dictionary<Creature, Creature>();

        //    foreach (Creature attacker in this.Army)
        //    {
        //        Creature bestTarget = attacker.FindBestTarget(enemy.Army);

        //        bestMatches.Add(attacker, bestTarget);
        //    }

        //    var bestMatch = bestMatches.OrderBy(x => Math.Max(0, x.Value.HealthPoints - x.Key.CalculateActualDamage(x.Value)))
        //                               .OrderByDescending(x => x.Value.Damage)
        //                               .FirstOrDefault();

        //    if (bestMatch.Key == null)
        //        return;


        //    this.AttackEnemyCreature(enemy, bestMatch.Key, bestMatch.Value);
        //}

        public void AutoAttack(Commander enemy)
        {
            List<AttackerBestTargetPair> attackerTargetPairs = new List<AttackerBestTargetPair>();

            foreach (var attackingCreature in this.army)
            {
                var bestTarget = attackingCreature.FindBestTarget(enemy.army);
                var pair = new AttackerBestTargetPair(attackingCreature, bestTarget);

                attackerTargetPairs.Add(pair);
            }

            var bestPair = attackerTargetPairs
                            .OrderBy(x => Math.Max(0, x.BestTarget.HealthPoints - x.Attacker.CalculateActualDamage(x.BestTarget)))
                            .OrderByDescending(x => x.BestTarget.Damage)
                            .FirstOrDefault();

            if (bestPair == null)
            {
                return;
            }

            Creature attacker = bestPair.Attacker;
            Creature target = bestPair.BestTarget;

            this.AttackEnemyCreature(enemy, attacker, target);

            // LINQ Solution
            // ---------------------------------------------
            // var (attacker, defender) = this.army
            // 	    .Select(a => (attacker: a, target: a.FindBestTarget(enemy.army)))
            // 	    .OrderBy(p => Math.Max(0, p.target.HealthPoints - p.attacker.CalculateActualDamage(p.target)))
            // 	    .ThenByDescending(p => p.target.Damage)
            // 	    .First();
        }

    }
}
