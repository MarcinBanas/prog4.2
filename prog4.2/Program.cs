using System;
using Dapper;

namespace prog4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB(@"Data Source = DESKTOP-9K2SBT4;Initial Catalog=ZNorthwind;Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; MultipleActiveResultSets = True");
            
            foreach (Spedytorzy spedytorzy in db.GetSpedytor())
            {
                Console.WriteLine($"{spedytorzy.IDspedytora}: {spedytorzy.NazwaFirmy}   Telefon: {spedytorzy.Telefon} ");
            }

            Console.WriteLine();
            string nazwa, telefon;
            Console.WriteLine("Podaj nazwe firmy:");
            nazwa=Console.ReadLine();
            Console.WriteLine("Podaj telefon:");
            telefon = Console.ReadLine();

            db.AddSpedytorzy(nazwa, telefon);

            Console.WriteLine("Podaj id do usuniecia:");
            int a = int.Parse(Console.ReadLine());
            db.DeleteSpedytorzy(a);

            Console.WriteLine("Podaj id do zaktualizowania:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj nazwe firmy:");
            string nazwa2 = Console.ReadLine();
            Console.WriteLine("Podaj telefon:");
            string telefon2 = Console.ReadLine();
            db.UpdateSpedytorzy(b, nazwa2, telefon2);

            foreach (Spedytorzy spedytorzy in db.GetSpedytor())
            {
                Console.WriteLine($"{spedytorzy.IDspedytora}: {spedytorzy.NazwaFirmy}   Telefon: {spedytorzy.Telefon} ");
            }
        }
        
    }
}
