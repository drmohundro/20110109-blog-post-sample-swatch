using System;
using System.Collections.Generic;
using Swatch;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var accts = new List<Account>
            {
                new Account
                {
                    Name = "Amazon",
                    IsPreferred = true,
                    Moolah = 123456789.01m
                },
                new Account
                {
                    Name = "Bob's Store",
                    IsPreferred = false,
                    Moolah = 15.78m
                }
            };

            var swatch = new Switcher<Account>();

            var results = new List<string>();

            foreach (var acct in accts)
            {
                swatch.Switch(acct,
                    swatch.Case(x => x == null,
                        x => Console.WriteLine("the object is null")),

                    swatch.Case(x => x.Moolah > 10000.00m,
                        x => Console.WriteLine("Whoa, these guys (" + x.Name + ") got some money")),

                    swatch.Default(
                        x => Console.WriteLine("wha?!?"))
                );
            }
        }
    }
}
