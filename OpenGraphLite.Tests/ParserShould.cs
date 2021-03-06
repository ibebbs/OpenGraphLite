using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace OpenGraphLite.Tests
{
    public class ParserShould
    {
        public static IEnumerable<TestCaseData> ExtractTheCorrectValuesTests
        {
            get
            {

                yield return new TestCaseData(
                    File.ReadAllText("./Data/bills_2551_stages_12546.html"),
                    new[]
                    {
                        new Value("og:title", "Agriculture Bill Royal Assent - Parliamentary Bills - UK Parliament"),
                        new Value("og:description", "Agriculture Bill Royal Assent sittings"),
                        new Value("og:type", "website"),
                        new Value("og:url", "https://bills.parliament.uk/bills/2551/stages/12546"),
                        new Value("og:image", "https://bills.parliament.uk/dist/opengraph-card.png"),
                    }
                ).SetName("Full HTML page");

                /*
                yield return new TestCaseData(
                    File.ReadAllText("./Data/bills_2551_stages_12546.html"),
                    new[]
                    {
                        new Value("og:locale", "en_GB"),
                        new Value("og:type", "article"),
                        new Value("og:title", "Commons Library analysis of the Business and Planning Bill 2019-21 - House of Commons Library"),
                        new Value("og:description", "This Library Paper has been prepared for the Commons stages of the Business and Planning Bill 2019-21 on 29 June 2020."),
                        new Value("og:url", "https://commonslibrary.parliament.uk/research-briefings/cbp-8947/"),
                        new Value("og:site_name", "House of Commons Library"),
                        new Value("og:locale", "en_GB"),
                        new Value("og:image", "https://commonslibrary.parliament.uk/content/uploads/2020/08/economic-situation-scaled.jpg"),
                    }
                ).SetName("Full HTML page");
                */
            }
        }

        [TestCaseSource(nameof(ExtractTheCorrectValuesTests))]
        public void ExtractTheCorrectValues(string source, IReadOnlyCollection<Value> expected)
        {
            var actual = Parser.Default.Parse(source);

            Assert.That(actual, Is.EqualTo(expected).AsCollection.Using(Equ.MemberwiseEqualityComparer<Value>.ByProperties));
        }
    }
}