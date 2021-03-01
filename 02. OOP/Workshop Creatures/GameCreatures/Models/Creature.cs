using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCreatures.Models
{
    public class Creature
    {
        private string name;
        private int damage;
        private int healthPoints;

        public Creature(
            string name,
            int damage,
            int healthPoints,
            AttackType attackType,
            ArmorType armorType)
        {

            this.Name = name;
            this.Damage = damage;

            if (healthPoints <= 0)
            {
                throw new ArgumentOutOfRangeException("HealthPoints should be a positive number");
            }

            this.healthPoints = healthPoints; //  this.ХealthPoints = healthPoints; - no need to go through the property when calling the constructor
            this.AttackType = attackType;
            this.ArmorType = armorType;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null) throw new ArgumentNullException("Name cannot be null");

                this.name = value;
            }

        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Damage should be a positive number");

                this.damage = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.healthPoints = value;
            }
        }

        public ArmorType ArmorType
        {
            get;
        }

        public AttackType AttackType
        {
            get;
        }

        public void Attack(Creature target)
        {
            int damage = CalculateActualDamage(target);

            target.HealthPoints -= damage;
        }

        public Creature FindBestTarget(List<Creature> targets)
        {
            Creature bestTarget;

            bestTarget = targets.OrderBy(x => Math.Max(0, x.HealthPoints - this.CalculateActualDamage(x)))
                                .OrderByDescending(x => x.Damage)
                                .First(); // first or firstOrDefault?

            return bestTarget;
        }

        public void AutoAttack(List<Creature> targets)
        {
            Creature bestTarget = this.FindBestTarget(targets);

            this.Attack(bestTarget);
        }

        public int CalculateActualDamage(Creature target)
        {
            int armor = (int)target.ArmorType;
            int attack = (int)this.AttackType;

            double multiplier = DamageCoefficients[attack, armor];

            int actualDamage = (int)(this.damage * multiplier);

            return actualDamage;
        }

        private static double[,] DamageCoefficients =
        {
            {1.25,    1.00,   0.75 },
            {1.00,    1.25,   0.75 },
            {0.75,    1.00,   1.25 }
        };
    }
}
