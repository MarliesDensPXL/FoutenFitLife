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
            
            do
            {
                Console.Write("Naam: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            //bool isValidHeight = false;
            double height = 0;
            double weight = 0; //@Wim: ik heb dit op 50 gezet omdat dit een geldige waarde is in mijn member-klasse, maar ik neem aan dat er een elegantere manier is om dit op te lossen. (Die ik dus zelf nog niet gevonden heb)
            DateTime training;

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
                member = new Member(name, height, weight); //hier wordt height + weight gevalideerd
                //member.Name = name;
                //member.Height = height;
                //member.Weight = weight;

                member.ActivateMembership(training);

                Console.WriteLine($"Lidmaatschap succesvol geactiveerd voor {member.Name} op {member.StartDate.ToLongDateString()}.");
                Console.WriteLine("Druk op een toets om verder te gaan...");
                Console.ReadKey(true);
            }
            catch (ArgumentException ae)
            {
                //Eventuele fouten uit constructor
                Console.WriteLine(ae.Message);
                return;
            }
            catch (InvalidOperationException ioe)
            {
                //Eventuele fouten uit ActivateMembership
                Console.WriteLine(ioe.Message);
                return;
            }
            //catch(Exception ex)
            //{
            //    //Alle fouten samen opvangen
            //    Console.WriteLine(ex.Message);
            //    return;
            //}


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
