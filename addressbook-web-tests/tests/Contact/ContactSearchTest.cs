using NUnit.Framework;
using System.Collections.Generic;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactSearchTest : ContactTestBase
    {

        [Test]
        public void NumOfSearchResultsTest()
        {
            int num_from_total = app.Contact.GetNumOfSearchResults();
            int num_from_table = app.Contact.GetContactsCount();
            Assert.AreEqual(num_from_table, num_from_total);
        }
    }
}
