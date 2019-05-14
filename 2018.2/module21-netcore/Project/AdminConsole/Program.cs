using System;
using Domain;

namespace AdminConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int quality = 0;
            bool visited = args.Length == 1 && int.TryParse(args[0], out quality);

            var service = new AssesmentService();
            Console.WriteLine(service.Asses(!visited, quality));
        }
    }
}
