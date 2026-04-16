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
                    
                    throw new ArgumentException("Ongeldige lengte."); // of throw new ArgumentOutOfRangeException(nameof (Heigth), "Ongeldige lengte.")
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

                    throw new ArgumentException("Ongeldig gewicht.");
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
                throw new InvalidOperationException($"Het lidmaatschap van lid {Name} kan niet geactiveerd worden omdat het al actief is!");
            }

            if (startDate < DateTime.Now.AddYears(-1))
            {
                throw new ArgumentException($"Het lidmaatschap van {Name} kan niet geactiveerd worden omdat de startdatum meer dan een jaar in het verleden ligt.");
            }

            if (startDate > DateTime.Now.AddMonths(1))
            {
                throw new ArgumentException($"Het lidmaatschap van {Name} kan niet geactiveerd worden omdat de startdatum meer dan een maand in de toekomst ligt.");
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
