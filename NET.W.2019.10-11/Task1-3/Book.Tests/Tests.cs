using NUnit.Framework;

namespace BookStore.Tests
{
    [TestFixture]
    public class Tests
    {
        private static TestData[] testdata1 = new TestData[]
        {
            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "ISBN = 978-0-7356-6745-7, AuthorName = Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012, NumberOfPages = 826, Price = 59,99$",
                Format = "I-A-N-PUB-Y-PA-PR",
            },
            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "ISBN = 978-0-7356-6745-7, AuthorName = Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012, NumberOfPages = 826, Price = 59,99$",
                Format = null,
            },

            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "Jeffrey Richter, CLR via C#",
                Format = "a-n",
            },

            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012",
                Format = "a-n-pub-y",
            },

            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P.826",
                Format = "i-a-n-pub-y-pa",
            },

            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012",
                Format = "a-n-pub-y",
            },

            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P.826, 59,99$",
                Format = "i-a-n-pub-y-pa-pr",
            },
        };

        private static TestData[] testdata2 = new TestData[]
        {
            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "ISBN = 978-0-7356-6745-7, AUTHORNAME = JEFFREY RICHTER, TITLE = CLR VIA C#, PUBLISHER = MICROSOFT PRESS, YEAR = 2012, NUMBEROFPAGES = 826, PRICE = 59,99$",
                Format = "U",
            },
            
        };

        private static TestData[] testdata3 = new TestData[]
        {
            new TestData()
            {
                BookSource = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99f),
                ExpectedResult = "isbn = 978-0-7356-6745-7, authorname = jeffrey richter, title = clr via c#, publisher = microsoft press, year = 2012, numberofpages = 826, price = 59,99$",
                Format = "L",
            },
        };

        [Test] 
        [TestCaseSource("testdata1")]
        public void BookFormatTests(TestData testdata)
        {
            string result = testdata.BookSource.ToString(testdata.Format);
            Assert.That(result, Is.EqualTo(testdata.ExpectedResult));
        }

        [Test]
        [TestCaseSource("testdata2")]
        public void AdditionalFormatTestsUpper(TestData testdata)
        {
            string result =  string.Format(new BookFormatter(), "{0:U}", testdata.BookSource);
            
            Assert.That(result, Is.EqualTo(testdata.ExpectedResult));
        }

        [Test]
        [TestCaseSource("testdata3")]
        public void AdditionalFormatTestsLower(TestData testdata)
        {
            string result = string.Format(new BookFormatter(), "{0:L}", testdata.BookSource);

            Assert.That(result, Is.EqualTo(testdata.ExpectedResult));
        }        
    }
}
