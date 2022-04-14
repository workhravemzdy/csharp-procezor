using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcezorTests.Registry.Constants
{
    public enum ExampleArticleConst : Int32
    {
        ARTICLE_TIMESHT_WORKING = 80001,
        ARTICLE_PAYMENT_SALARY = 80002,
        ARTICLE_PAYMENT_BONUS = 80003,
        ARTICLE_PAYMENT_BARTER = 80004,
        ARTICLE_ALLOWCE_HOFFICE = 80005,
        ARTICLE_HEALTH_INSBASE = 80006,
        ARTICLE_SOCIAL_INSBASE = 80007,
        ARTICLE_HEALTH_INSPAYM = 80008,
        ARTICLE_SOCIAL_INSPAYM = 80009,
        ARTICLE_TAXING_ADVBASE = 80010,
        ARTICLE_TAXING_ADVPAYM = 80011,
        ARTICLE_INCOME_GROSS = 80012,
        ARTICLE_INCOME_NETTO = 80013,
    }
    public static class ExampleArticleExtensions
    {
        public static string GetSymbol(this ExampleArticleConst article)
        {
            return article.ToString();
        }
    }
}
