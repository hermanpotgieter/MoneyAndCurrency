using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests
{
    [TestFixture]
    public class CurrencyTests
    {
        [Test]
        public void Currencies_IsNotNull()
        {
            IEnumerable<Currency> currencies = Currency.Currencies;
            Assert.IsNotNull(currencies);
        }

        [Test]
        public void Currencies_HasMoreThanZeroElements()
        {
            IEnumerable<Currency> currencies = Currency.Currencies;
            Assert.That(currencies.Count() > 0);
        }

        [Test]
        public void Currencies_SelectUsingIso3LetterCode_ReturnsMatchingCurrency()
        {
            const string expected = "USD";
            IEnumerable<Currency> currencies = Currency.Currencies;

            string actual = currencies.Where(c => c.Iso3LetterCode == "USD").Single().Iso3LetterCode;

            Assert.That(actual == expected);
        }

        [Test]
        public void Currency_StaticIso3LetterCode_MatchesKnownIso3LetterCode()
        {
            const string expected = "USD";
            string actual = Currency.USD.Iso3LetterCode;

            Assert.That(actual == expected);
        }

        [Test]
        public void Currency_StaticIsoNumberCode_MatchesKnownIsoNumberCode()
        {
            const int expected = 840;
            int actual = Currency.USD.IsoNumberCode;

            Assert.That(actual == expected);
        }

        [Test]
        public void Currency_StaticName_MatchesKnownCurrencyName()
        {
            const string expected = "US Dollar";
            string actual = Currency.USD.Name;

            Assert.That(actual == expected);
        }

        [Test]
        public void FromCulture_CultureName_MatchingCurrency()
        {
            Currency expected = Currency.USD;
            Currency actual = Currency.FromCulture("en-US");

            Assert.That(actual == expected);
        }

        [Test]
        public void FromCulture_InvalidCultureName_ThrowsCultureNotFoundException()
        {
            TestDelegate testDelegate = () => Currency.FromCulture("noSuchCulture");
            Assert.Throws<CultureNotFoundException>(testDelegate);
        }

        [Test]
        public void FromCurrentCulture_NoArguments_CurrencyForCurrentCulture()
        {
            string expected = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID).ISOCurrencySymbol;
            string actual = Currency.FromCurrentCulture().Iso3LetterCode;

            Assert.That(actual == expected);
        }

        [Test]
        public void FromCurrentRegion_NoArguments_CurrencyForCurrentRegion()
        {
            string expected = RegionInfo.CurrentRegion.ISOCurrencySymbol;
            string actual = Currency.FromCurrentRegion().Iso3LetterCode;

            Assert.That(actual == expected);
        }

        [Test]
        public void FromIso3LetterCode_InvalidIso3LetterCode_ThrowsCurrencyNotFoundException()
        {
            TestDelegate testDelegate = () => Currency.FromIso3LetterCode("noSuchCode");
            Assert.Throws<CurrencyNotFoundException>(testDelegate);
        }

        [Test]
        public void FromIso3LetterCode_Iso3LetterCode_MatchingCurrency()
        {
            Currency expected = Currency.USD;
            Currency actual = Currency.FromIso3LetterCode("USD");

            Assert.That(actual == expected);
        }

        [Test]
        public void FromIsoNumberCode_InvalidIsoNumberCode_ThrowsCurrencyNotFoundException()
        {
            TestDelegate testDelegate = () => Currency.FromIsoNumberCode(-1);
            Assert.Throws<CurrencyNotFoundException>(testDelegate);
        }

        [Test]
        public void FromIsoNumberCode_IsoNumberCode_MatchingCurrency()
        {
            Currency expected = Currency.USD;
            Currency actual = Currency.FromIsoNumberCode(840);

            Assert.That(actual == expected);
        }

        [Test]
        public void ToString_NoArguments_Iso3LetterCodeAndCurrencyName()
        {
            const string expected = "ZAR: South African Rand";

            string actual = Currency.ZAR.ToString();

            Assert.That(string.Equals(actual, expected));
        }
    }
}
