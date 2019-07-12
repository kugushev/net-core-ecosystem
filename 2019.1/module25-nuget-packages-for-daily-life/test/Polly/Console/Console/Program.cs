using System;
using Polly;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Policy
                .Handle<NotImplementedException>()
                .Retry(3)
                .Execute(() =>
                {
                    System.Console.WriteLine("Test");
                    throw new NotImplementedException();
                });
            
            
            
        }
    }
}