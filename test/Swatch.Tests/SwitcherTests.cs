using Swatch;
using Xunit;

namespace Tests
{
    public class SwitcherTests
    {
        private readonly TestClass _instance;

        public SwitcherTests()
        {
            _instance = new TestClass { Name = "Foo" };
        }

        [Fact]
        public void ShouldHandleTrueCases()
        {
            var swatch = new Switcher<TestClass>();

            var result = false;

            swatch.Switch(_instance,
                swatch.Case(x => x.Name == "Foo",
                    x => result = true)
            );

            Assert.True(result);
        }

        [Fact]
        public void ShouldSkipFalseCases()
        {
            var swatch = new Switcher<TestClass>();

            var result = false;

            swatch.Switch(_instance,
                swatch.Case(x => x.Name == "Bar",
                    x => result = true)
            );

            Assert.False(result);
        }

        [Fact]
        public void ShouldRunDefaultAlways()
        {
            var swatch = new Switcher<TestClass>();

            var result = false;

            swatch.Switch(_instance,
                swatch.Default(
                    x => result = true)
            );

            Assert.True(result);
        }

        [Fact]
        public void ShouldStopAfterFirstTrueCase()
        {
            var swatch = new Switcher<TestClass>();

            int calls = 0;

            swatch.Switch(_instance,
                swatch.Case(
                    x => {
                        calls++;
                        return false;
                    },
                    x => {
                        // no op
                    }
                ),

                swatch.Case(
                    x => {
                        calls++;
                        return true;
                    },
                    x => {
                        // no op
                    }
                ),

                // stops here

                swatch.Case(
                    x => {
                        calls++;
                        return true;
                    },
                    x => {
                        // no op
                    }
                )
            );

            Assert.Equal(calls, 2);
        }
    }

    class TestClass
    {
        public string Name { get; set; }
    }
}
