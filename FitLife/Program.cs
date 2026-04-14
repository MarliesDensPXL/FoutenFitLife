namespace FitLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij FitLife!");
            Console.WriteLine("Schrijf je in via onderstaande formulier.");
            Console.WriteLine();
            Console.Write("Naam: ");
            string name = Console.ReadLine();

            Console.Write("Lengte in meter: ");
            double height = double.Parse(Console.ReadLine());

            Console.Write("Gewicht in kg: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Datum eerste training: ");
            DateTime training = DateTime.Parse(Console.ReadLine());

            //Print summary:
            Console.Clear();
            Console.Write("Bedankt {name}, controleer je gegevens nog een laatste keer:");
            Console.WriteLine($"Naam:   \t {name}");
            Console.WriteLine($"Lengte: \t {weight:f2}m");
            Console.WriteLine($"Gewicht:\t {height:f2}kg");
            Console.WriteLine($"Start:  \t {traning.ToLongDateString}");

            Console.WriteLine("Druk op een toets om je lidmaatschap te activeren...");
            Console.ReadKey(true);

            Member member;
            member.Name = name;
            member.Height = height;
            member.Weight = weight;

            member.ActivateMembership(training);

            Console.WriteLine($"Lidmaatschap succesvol geactiveerd voor {member.Name} op {member.StartDate}.");
            Console.WriteLine("Druk op een toets om verder te gaan...");
            Console.ReadKey(true);

            bool close = false;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welkom bij FitLife {member.name}!");
                Console.WriteLine("Beheer hier je lidmaatschap");
                Console.WriteLine();
                Console.WriteLine("1. Lidmaatschap verlengen");
                Console.WriteLine("2. Lidmaatschap stopzetten");
                Console.Write("Selecteer de gewenste optie: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        member.RenewMembership();
                        Console.WriteLine($"Proficiat {member.Name}, jouw lidmaatschap is verlengd tot {member.ValidUnit}")
                        break;
                    case "2":
                        Console.Write("Datum stopzetting: ");
                        string endDate = Console.ReadLine();
                        member.DeactivateMembership(endDate);
                        break;
                    default:
                        close = true;
                        break;
                }

            } while (close); ;
        }
    }
}
