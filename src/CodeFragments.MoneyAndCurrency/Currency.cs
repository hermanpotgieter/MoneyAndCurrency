using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CodeFragments.MoneyAndCurrency
{
    public partial class Currency
    {
        static Currency()
        {
            Currencies = CreateCurrencyList();
        }
       
        private Currency(string iso3LetterCode, int isoNumberCode, string name, int fractionDigits)
        {
            Iso3LetterCode = iso3LetterCode;
            IsoNumberCode = isoNumberCode;
            Name = name;
            FractionDigits = fractionDigits;
        }

        public int IsoNumberCode { get; private set; }

        public string Iso3LetterCode { get; private set; }

        public string Name { get; private set; }

        public int FractionDigits { get; private set; }

        public static IEnumerable<Currency> Currencies { get; private set; }

        public static Currency FromCurrentCulture()
        {
            RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);

            return Currencies.Where(c => c.Iso3LetterCode == regionInfo.ISOCurrencySymbol).Single();
        }

        public static Currency FromCulture(string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);

            return Currencies.Where(c => c.Iso3LetterCode == regionInfo.ISOCurrencySymbol).Single();
        }

        public static Currency FromCurrentRegion()
        {
            return Currencies.Where(c => c.Iso3LetterCode == RegionInfo.CurrentRegion.ISOCurrencySymbol).Single();
        }

        public static Currency FromIso3LetterCode(string iso3LetterCode)
        {
            try
            {
                return Currencies.Where(c => c.Iso3LetterCode == iso3LetterCode).Single();
            }
            catch (InvalidOperationException ex)
            {
                throw new CurrencyNotFoundException(
                    string.Format("Could not find an exact Currency match for: {0}", iso3LetterCode), ex);
            }
        }

        public static Currency FromIsoNumberCode(int isoNumberCode)
        {
            try
            {
                return Currencies.Where(c => c.IsoNumberCode == isoNumberCode).Single();
            }
            catch (InvalidOperationException ex)
            {
                throw new CurrencyNotFoundException(
                    string.Format("Could not find an exact Currency match for: {0}", isoNumberCode), ex);
            }
        }
    }
}