namespace FitLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij FitLife!");
            Console.WriteLine("Schrijf je in via onderstaande formulier.");
            Console.WriteLine();

            string name;
            double height;
            double weight;
            DateTime training; 

            do
            {
                Console.Write("Naam: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write("Ongeldige invoer. Vul je naam in: ");
                    name = Console.ReadLine();
                }
            } while (string.IsNullOrWhiteSpace(name));

            do
            {
                Console.Write("Lengte in meter: ");
                
            } while (!double.TryParse(Console.ReadLine(), out height));


            do
            {
                Console.Write("Gewicht in kg: ");
               
            } while (!double.TryParse(Console.ReadLine(), out weight));

            do
            {
                Console.Write("Datum eerste training: ");
                
            } while (!DateTime.TryParse(Console.ReadLine(), out training));
           
                       

            //Print summary:
            Console.Clear();
            Console.WriteLine($"Bedankt {name}, controleer je gegevens nog een laatste keer:");
            Console.WriteLine($"Naam:   \t {name}");
            Console.WriteLine($"Lengte: \t {height:f2}m");
            Console.WriteLine($"Gewicht:\t {weight:f2}kg");
            Console.WriteLine($"Start:  \t {training.ToLongDateString()}");

            Console.WriteLine("Druk op een toets om je lidmaatschap te activeren...");
            Console.ReadKey(true);

            Member member; 

            try
            {
                member = new Member(name, height, weight);

                member.ActivateMembership(training);

                Console.WriteLine($"Lidmaatschap succesvol geactiveerd voor {member.Name} op {member.StartDate.ToLongDateString()}.");
                Console.WriteLine("Druk op een toets om verder te gaan...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

                        
         

            bool close = false;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welkom bij FitLife, {member.Name}!");
                Console.WriteLine("Beheer hier je lidmaatschap");
                Console.WriteLine();
                Console.WriteLine("1. Lidmaatschap verlengen");                             
                Console.WriteLine("2. Lidmaatschap stopzetten");

                string option;
                do
                {
                    Console.Write("Selecteer de gewenste optie: ");
                    option = Console.ReadLine();
                } while (!option.Equals("1") && !option.Equals("2"));

                switch (option)
                {
                    case "1":
                        int years;
                        do
                        {
                            Console.WriteLine("Met hoeveel jaar wil je verlengen? Kies '1' of '2': ");

                        } while (!int.TryParse(Console.ReadLine(), out years) || (years != 1 && years != 2));

                         member.RenewMembership(years);
                         Console.WriteLine($"Proficiat {member.Name}, jouw lidmaatschap is verlengd tot {member.ValidUntil.ToShortDateString()}");
                        
                        break;
                        

                    case "2":
                        DateTime end;
                        do
                        {
                            Console.Write("Datum stopzetting: ");
                        } while (!DateTime.TryParse(Console.ReadLine(), out end));
                        
                                            
                        member.DeactivateMembership(end) ;
                        Console.WriteLine($"Beste {member.Name}, jouw lidmaatschap is stopgezet op {member.ValidUntil.ToShortDateString()}");
                        break;
                    default:
                        close = true;
                        break;
                }

            } while (close); ;
        }
    }
}
