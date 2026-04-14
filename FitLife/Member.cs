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

        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ValidUntil { get; set; }

        private bool _hasBeenActivated = false;

        //private bool IsActive()
        //{
        //    if (StartDate != null)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public void ActivateMembership(DateTime startDate)
        {
            if (_hasBeenActivated)
            {
                throw new Exception($"Het lidmaatschap van lid {Name} kan niet geactiveerd worden omdat het al actief is!");
            }

            StartDate = startDate;
            ValidUntil = startDate.AddYears(1);
            _hasBeenActivated = true;
        }

        public void RenewMembership(int years)
        {
            if (!_hasBeenActivated)
            {
                throw new Exception($"Het lidmaatschap van lid {Name} kan niet verlengd worden omdat dit niet actief is!");
            }
            ValidUntil = ValidUntil.AddYears(2);
        }

        public void DeactivateMembership(DateTime endDate)
        {
            if (!_hasBeenActivated)
            {
                throw new Exception($"Het lidmaatschap van lid {Name} kan niet gestopt worden omdat het niet actief is!");
            }

            ValidUntil = endDate;
        }
    }
}
