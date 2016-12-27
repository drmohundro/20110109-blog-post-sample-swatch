using System.Collections.Generic;
using Swatch;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void ShouldBeCorrect()
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
                        x => results.Add("the object is null")),

                    swatch.Case(x => x.Moolah > 10000.00m,
                        x => results.Add("Whoa, these guys (" + x.Name + ") got some money")),

                    swatch.Default(
                        x => results.Add("default!"))
                );
            }

            Assert.Equal(results[0], "Whoa, these guys (Amazon) got some money");
            Assert.Equal(results[1], "default!");
        }
    }
}
