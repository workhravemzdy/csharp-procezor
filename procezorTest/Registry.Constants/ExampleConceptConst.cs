using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcezorTests.Registry.Constants
{
    public enum ExampleConceptConst : Int32
    {
        CONCEPT_TIMESHT_WORKING = 80001,
        CONCEPT_AMOUNT_BASIS = 80002,
        CONCEPT_AMOUNT_FIXED = 80003,
        CONCEPT_HEALTH_INSBASE = 80006,
        CONCEPT_SOCIAL_INSBASE = 80007,
        CONCEPT_HEALTH_INSPAYM = 80008,
        CONCEPT_SOCIAL_INSPAYM = 80009,
        CONCEPT_TAXING_ADVBASE = 80010,
        CONCEPT_TAXING_ADVPAYM = 80011,
        CONCEPT_INCOME_GROSS = 80012,
        CONCEPT_INCOME_NETTO = 80013,
    }
    public static class ExampleConceptExtensions
    {
        public static string GetSymbol(this ExampleConceptConst article)
        {
            return article.ToString();
        }
    }
}
