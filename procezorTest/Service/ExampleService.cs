using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ProcezorTests.Registry.Factories;

namespace ProcezorTests.Service
{
    public class ExampleService : ServiceProcezor
    {
        public const Int32 TEST_VERSION = 100;

        public const Int32 TEST_FINAL_ARTICLE = (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO;

        public const Int32 TEST_FINAL_CONCEPT = (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO;

        private static readonly IList<ArticleCode> TEST_FINAL_DEFS = new List<ArticleCode>() {
            ArticleCode.Get(TEST_FINAL_ARTICLE),
        };

        public ExampleService() : base(TEST_VERSION, TEST_FINAL_DEFS)
        {
            var buildSuccess = BuildFactories();
            if (buildSuccess == false)
            {
                Console.WriteLine($"Version: {this.Version}, build factories failed");
            }
        }

        public override IEnumerable<IContractTerm> GetContractTerms(IPeriod period, IEnumerable<ITermTarget> targets)
        {
            return new List<IContractTerm>();
        }

        public override IEnumerable<IPositionTerm> GetPositionTerms(IPeriod period, IEnumerable<IContractTerm> contracts, IEnumerable<ITermTarget> targets)
        {
            return new List<IPositionTerm>();
        }

        protected override bool BuildArticleFactory()
        {
            ArticleFactory = new ExampleArticleFactory();

            return true;
        }

        protected override bool BuildConceptFactory()
        {
            ConceptFactory = new ExampleConceptFactory();

            return true;
        }
    }
}

