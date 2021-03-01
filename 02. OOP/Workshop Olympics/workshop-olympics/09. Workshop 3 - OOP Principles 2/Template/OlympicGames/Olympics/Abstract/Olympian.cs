using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlympicGames.Olympics.Abstract
{
    public abstract class Olympian : IOlympian
    {

        private string firstName;
        private string lastName;
        private string country;

        protected Olympian(string firstName, string lastName, string country) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (!ValidateStringName(value, 2, 20))
                {
                    throw new ArgumentException("First name must be between 2 and 20 characters long!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (!ValidateStringName(value, 2, 20))
                {
                    throw new ArgumentException("Last name must be between 2 and 20 characters long!");
                }

                this.lastName = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            private set
            {
                if (!ValidateStringName(value, 3, 25))
                {
                    throw new ArgumentException("Country must be between 3 and 25 characters long!");
                }
                this.country = value;
            }
        }

        protected abstract string AdditionalInfo();

        public string ListOlympians()
        {
            string olympian = this.GetType().Name;

            return $"{olympian.ToUpper()}: {this.firstName} {this.lastName} from {this.country}\n" +
                $"{this.AdditionalInfo()}".Trim();
        }

        public string CreateOlympian()
        {
            string olympian = this.GetType().Name;

            return $"Created {olympian}\n" + ListOlympians();
        }

        public bool ValidateStringName(string name, int minValue, int maxValue)
        {
            if (name.Length < minValue || name.Length > maxValue)
            {
                return false;
            }
            return true;
        }
    }
}
