using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Registry.Factories;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Factories
{
    class ExampleArticleFactory : ArticleSpecFactory
    {
        const Int16 ARTICLE_DEFAULT_SEQUENS = 0;

        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_PAYMENT_SALARY, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_PAYMENT_BONUS, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_PAYMENT_BARTER, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_ALLOWCE_HOFFICE, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_HEALTH_INSPAYM, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSPAYM, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_TAXING_ADVPAYM, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_INCOME_GROSS,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO, ARTICLE_DEFAULT_SEQUENS, (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO,
                Array.Empty<Int32>()),
        };
        public ExampleArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}