using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLife
{
    public class Member
    {
        public Member(string name, double height, double weight)
        {
            Name = name;
            Height = height;
            Weight = weight;
        }

        public string Name { get; }
        public double Height { get; }
        public double Weight { get; }
        public DateTime StartDate { get; }
        public DateTime ValidUntil { get; }

        private bool IsActive()
        {
            if (StartDate < DateTime.Today)
            {
                return true;
            }

            return false;
        }

        public void ActivateMemebership(DateTime startDate)
        {
            if (IsActive())
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet geactiveerd worden omdat het is al actief is!");
            }

            StartDate = startDate;
            ValidUntil = startDate.AddYears(1);
        }

        public void RenewMembership(int years)
        {
            if (!IsActive())
            {
                throw new Exception("Het lidmaatschap van lid {name} kan niet verlengd worden omdat dit niet actief is!");
            }
            ValidUntil = ValidUntil.AddYears(2);
        }

        public void DeactivateMembership(DateTime endDate)
        {
            if (IsActive())
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet gestopt worden omdat het niet actief is!");
            }

            ValidUntil = endDate;
        }
    }
}
