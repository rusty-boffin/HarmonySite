using RustyBoffin.HarmonySite;
using RustyBoffin.HarmonySite.Data;
using System;
using System.Drawing;
using System.Linq;

namespace RustyBoffin.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string site = ReadArg(args, 0, "Site");
            string username = ReadArg(args, 1, "Username");
            string password = ReadArg(args, 2, "Password");

            HSSession session = new HSSession(new HSConnection(site, username, password));

            Console.WriteLine(session.Website.WebsiteName);

            Ensemble ensemble = session.Website.Ensembles.Last();

            Console.WriteLine(ensemble.Name);
            Console.WriteLine(ensemble.Registration);
            Console.WriteLine(ensemble.Level);
            Console.WriteLine(ensemble.Name);

            foreach (Participation p in ensemble.Participations)
                Console.WriteLine(p.Member.Greeting);

            Position position = session.Website.Positions.Last();
            Console.WriteLine(position.Name);
            foreach (Member m in position.Members)
            {
                Console.WriteLine(m.Greeting);
                foreach (Position p in m.Positions)
                {
                    Console.WriteLine(p.Name);
                    Console.WriteLine(p.Club.GetType().Name);
                    foreach (Team t in p.Teams)
                        Console.WriteLine(t.Name);
                }
            }
        }

        private static string ReadArg(string[] args, int idx, string prompt)
        {
            string result;
            if (args.Length > idx)
            {
                result = args[idx];
                Console.WriteLine("{0} : {1}", prompt, result);
            }
            else
            {
                Console.WriteLine("{0}?", prompt);
                result = Console.ReadLine();
            }
            return result;
        }
    }
}
