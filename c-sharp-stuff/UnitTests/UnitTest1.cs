using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReGex;

namespace UnitTests
{
    [TestClass]
    public class RegEx_Test
    {
        [TestMethod, TestCategory("Unit")]
        public void IsPhoneNumber_ValidPhoneNumbers()
        {
            if (!Utilities.IsPhoneNumber("(123) 123 1 x12345")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+049 1234 5678")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("(123)-456-7890")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("123.456.7890")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+1 (234)-567-8901")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+1 234 567 8901")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("123 456 7890")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+1 123-456-7890 x123")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+049 1234 5678X1234")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("(123)-456-7890 ext.12345")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("123.456.7890 EXT12345")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+1 (234)-567-8901 ex12")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+049 1234 5678 x111")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+1 (123)-456-7890 ext 12345")) Assert.Fail();
            if (!Utilities.IsPhoneNumber("+1 (123)-456-7890 ext. 12345")) Assert.Fail();
        }

        [TestMethod, TestCategory("Unit")]
        public void UsPhoneNumber_InvalidPhoneNumbers()
        {
            if (Utilities.IsPhoneNumber("a")) Assert.Fail();
            if (Utilities.IsPhoneNumber("+(")) Assert.Fail();
            if (Utilities.IsPhoneNumber("+(1")) Assert.Fail();
            if (Utilities.IsPhoneNumber("(")) Assert.Fail();
            if (Utilities.IsPhoneNumber("+")) Assert.Fail();
            if (Utilities.IsPhoneNumber("1")) Assert.Fail();
            if (Utilities.IsPhoneNumber("+1")) Assert.Fail();
            if (Utilities.IsPhoneNumber("+12 ")) Assert.Fail();
            if (Utilities.IsPhoneNumber("+123 ")) Assert.Fail();
            if (Utilities.IsPhoneNumber("(1) ")) Assert.Fail();
            if (Utilities.IsPhoneNumber("(123) ")) Assert.Fail();
            if (Utilities.IsPhoneNumber("049")) Assert.Fail();
            if (Utilities.IsPhoneNumber("(123)-")) Assert.Fail();
            if (Utilities.IsPhoneNumber("123.456.7890 A12345")) Assert.Fail();
        }
    }
}
