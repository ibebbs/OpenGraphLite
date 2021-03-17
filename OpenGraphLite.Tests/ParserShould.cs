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
                ).SetName("Extract the correct open graph values for Agriculture Bill Royal Assent");

                yield return new TestCaseData(
                    File.ReadAllText("./Data/Agriculture Bill Briefing for Lords Stages - House of Lords Library.html"),
                    new[]
                    {
                        new Value("og:locale", "en_GB"),
                        new Value("og:type", "article"),
                        new Value("og:title", "Agriculture Bill: Briefing for Lords Stages - House of Lords Library"),
                        new Value("og:description", "The House of Lords stages of the Agriculture Bill began on 18 May 2020 with first reading."),
                        new Value("og:url", "https://lordslibrary.parliament.uk/research-briefings/lln-2020-0105/"),
                        new Value("og:site_name", "House of Lords Library"),
                        new Value("og:image", "https://lordslibrary.parliament.uk/content/uploads/sites/2/2020/09/Environment.png"),
                        new Value("og:image:width", "1233"),
                        new Value("og:image:height", "925"),
                    }
                ).SetName("Extract the correct open graph values for Agriculture Bill: Briefing for Lords Stages");

                yield return new TestCaseData(
                    File.ReadAllText("./Data/Have your say on the Agriculture Bill - UK Parliament.html"),
                    new[]
                    {
                        new Value("og:url", "https://www.parliament.uk/business/news/2020/february/have-your-say-on-the-agriculture-bill/"),
                        new Value("og:title", "Have your say on the Agriculture Bill"),
                        //new Value("og:description", "Do you have relevant expertise and experience or a special interest in the Agriculture Bill, which is currently passing through Parliament?If so, you can submit your views in writing to the House of Commons Public Bill Committee which is going to consider this Bill."),
                        new Value("og:image", "https://www.parliament.uk/content/img/opengraph-card.png")
                    }
                ).SetName("Extract the correct open graph values for Agriculture Bill Press Notice");

                yield return new TestCaseData(
                    File.ReadAllText("./Data/The Agriculture Act 2020 - House of Commons Library.html"),
                    new[]
                    {
                        new Value("og:locale", "en_GB"),
                        new Value("og:type", "article"),
                        new Value("og:title", "The Agriculture Act 2020 - House of Commons Library"),
                        new Value("og:description", "The Agriculture Bill 2019-21 has passed through the House of Commons and the House of Lords, and is now going through the “ping-pong” process of amendments."),
                        new Value("og:url", "https://commonslibrary.parliament.uk/research-briefings/cbp-8702/"),
                        new Value("og:site_name", "House of Commons Library"),
                        new Value("og:image", "https://commonslibrary.parliament.uk/content/uploads/2020/08/farming-and-fishing-scaled.jpg"),
                        new Value("og:image:width", "2560"),
                        new Value("og:image:height", "1920")
                    }
                ).SetName("Extract the correct open graph values for Agriculture Bill Commons Breifing Paper");
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