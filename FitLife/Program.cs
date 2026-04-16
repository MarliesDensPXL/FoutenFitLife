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
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Ongeldige invoer. Vul je naam in: ");
                name = Console.ReadLine();
            }

            bool isValidHeight = false;
            double height = 0;
            double weight = 50; //@Wim: ik heb dit op 50 gezet omdat dit een geldige waarde is in mijn member-klasse, maar ik neem aan dat er een elegantere manier is om dit op te lossen. (Die ik dus zelf nog niet gevonden heb)
            while (!isValidHeight)
            {
                Console.Write("Lengte in meter: ");
                if (!double.TryParse(Console.ReadLine(), out height))
                    {
                    Console.WriteLine("Ongeldige invoer.");
                    continue;
                }
                try
                {
                    new Member(name, height, weight); //@Wim: op welke plaats moet ik een nieuw object aanmaken? 
                    
                    isValidHeight = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool isValidWeight = false;
            
            
            while (!isValidWeight)
            {
                Console.Write("Gewicht in kg: ");
                if (!double.TryParse(Console.ReadLine(), out weight))
                    {
                    Console.WriteLine("Ongeldige invoer.");
                    continue;
                }
                try
                {
                    new Member(name, height, weight);
                    isValidWeight = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }


            bool isValidTraining = false;
            DateTime training = default(DateTime);
            while (!isValidTraining)
            {
                Console.Write("Datum eerste training: ");
                if (!DateTime.TryParse(Console.ReadLine(), out training))
                {
                    Console.WriteLine("Ongeldige invoer");
                    continue;
                }

                isValidTraining = true;
            }
           

            //Print summary:
            Console.Clear();
            Console.WriteLine($"Bedankt {name}, controleer je gegevens nog een laatste keer:");
            Console.WriteLine($"Naam:   \t {name}");
            Console.WriteLine($"Lengte: \t {height:f2}m");
            Console.WriteLine($"Gewicht:\t {weight:f2}kg");
            Console.WriteLine($"Start:  \t {training.ToLongDateString()}");

            Console.WriteLine("Druk op een toets om je lidmaatschap te activeren...");
            Console.ReadKey(true);


            Member member = new Member(name, height, weight);
            //member.Name = name;
            //member.Height = height;
            //member.Weight = weight;

            bool activate = false;

            while (!activate) //TODO aanpassen: er moet een nieuwe datum gelezen worden (loop verplaatsen naar ingave datum training hierboven?)
            {
                try
                {
                    member.ActivateMembership(training);

                    Console.WriteLine($"Lidmaatschap succesvol geactiveerd voor {member.Name} op {member.StartDate.ToLongDateString()}.");
                    Console.WriteLine("Druk op een toets om verder te gaan...");
                    Console.ReadKey(true);
                    activate = true;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Geef een geldige datum in: ");
                    Console.ReadLine();
                    continue;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Geef een geldige datum in: ");
                    Console.ReadLine();
                    continue;
                }
            }

            bool close = false;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welkom bij FitLife {member.Name}!");
                Console.WriteLine("Beheer hier je lidmaatschap");
                Console.WriteLine();
                Console.WriteLine("1. Lidmaatschap verlengen");
                Console.WriteLine("2. Lidmaatschap stopzetten");
                Console.Write("Selecteer de gewenste optie: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        member.RenewMembership(1);
                        Console.WriteLine($"Proficiat {member.Name}, jouw lidmaatschap is verlengd tot {member.ValidUntil.ToShortDateString()}");
                        break;
                    case "2":
                        Console.Write("Datum stopzetting: ");
                        string endDate = Console.ReadLine();
                        DateTime end = DateTime.Parse(endDate);
                        member.DeactivateMembership(end) ;
                        break;
                    default:
                        close = true;
                        break;
                }

            } while (close); ;
        }
    }
}
