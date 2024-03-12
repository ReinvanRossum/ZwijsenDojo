using GildedRoseKata;
using System.Text;

namespace GildedRoseTests
{
    public class ApprovalTest
    {
        [Fact]
        public Task ThirtyDays()
        {
            var fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { "30" });
            var output = fakeOutput.ToString();

            return Verifier.Verify(output);
        }
    }
}