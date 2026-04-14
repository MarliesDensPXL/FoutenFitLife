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


        private double _height;

        public double Height
        {
            get { return _height; }
            set 
            { 
                if (value >= 1.00 && value <= 3.00)
                {
                    _height = value;
                }
                else
                {
                    
                    throw new ArgumentOutOfRangeException("Ongeldige lengte.");
                }
                    
             }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value > 40 && value < 200)
                {
                    _weight = value;
                }
                else
                {

                    throw new ArgumentOutOfRangeException("Ongeldig gewicht.");
                }

            }
        }

                
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
