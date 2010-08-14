using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests
{
    [TestFixture]
    public class MoneyTests
    {
        public void DisplayIsoCurrencyList()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            IOrderedEnumerable<RegionInfo> regions = cultures.Select(culture => new RegionInfo(culture.LCID))
                .Where(regionInfo => regionInfo.EnglishName.ToLower().Contains(""))
                .OrderBy(regionInfo => regionInfo.ISOCurrencySymbol);

            foreach (RegionInfo region in regions)
            {
                string info = string.Format("{0}\t {1}, {2}", region.ISOCurrencySymbol, region.EnglishName,
                                            region.CurrencyEnglishName);
                Console.WriteLine(info);
            }
        }

        public static string GetEnglishCurrencyName(string iso)
        {
            foreach (RegionInfo reg in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(c => new RegionInfo(c.LCID))
                .Where(reg => string.Compare(iso, reg.ISOCurrencySymbol, true) == 0))
            {
                return reg.CurrencyEnglishName;
            }
            throw new ArgumentException();
        }

        [Test]
        public void Equals_DifferentCurrencySameAmount_False()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("USD", 100);

            Assert.AreNotSame(money1, money2);
            Assert.AreNotEqual(money1, money2);
        }

        [Test]
        public void Equals_SameCurrencyAndAmount_True()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("ZAR", 100);

            Assert.AreNotSame(money1, money2);
            Assert.AreEqual(money1, money2);
        }

        [Test]
        public void Equals_SameCurrencyDifferentAmount_False()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("ZAR", 100.01m);

            Assert.AreNotSame(money1, money2);
            Assert.AreNotEqual(money1, money2);
        }

        [Test]
        public void Equals_SameInstance_True()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = money1;

            Assert.AreSame(money1, money2);
            Assert.AreEqual(money1, money2);
        }

        [Test]
        public void New_CurrencyCodeAndAmount_Money()
        {
            Money money = new Money("ZAR", 0);

            Assert.IsNotNull(money);
        }
    }
}