using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry.Factories
{
    public record ProviderRecord(Int32 article, Int16 sequens, Int32 concept, Int32[] sums)
    {
    }
    class NotFoundArticleProvider : ArticleSpecProvider
    {
        public class NotFoundArticleSpec : ArticleSpec
        {
            const Int32 ARTICLE_CODE = NotFoundArticleProvider.ARTICLE_CODE;

            const Int32 CONCEPT_CODE = (Int32)ConceptConst.CONCEPT_NOTFOUND;

            public NotFoundArticleSpec() : base(ARTICLE_CODE, ArticleSeqs.ZeroCode, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }

        public const Int32 ARTICLE_CODE = (Int32)ArticleConst.ARTICLE_NOTFOUND;
        public NotFoundArticleProvider() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new NotFoundArticleSpec();
        }
    }

    public class ArticleSpecFactory : SpecFactory<IArticleSpecProvider, IArticleSpec, ArticleCode>, IArticleSpecFactory
    {
        public ArticleSpecFactory()
        {
            this.NotFoundProvider = new NotFoundArticleProvider();

            this.NotFoundSpec = new NotFoundArticleProvider.NotFoundArticleSpec();
        }
        static protected IReadOnlyDictionary<Int32, IArticleSpecProvider> BuildProvidersFromRecords(IEnumerable<ProviderRecord> records)
        {
            var providers = records.Select(x => 
                new ArticleProviderConfig(x.article, x.sequens, x.concept, x.sums))
                .Cast<IArticleSpecProvider>()
                .ToImmutableDictionary(k => k.Code.Value, v => v);

            return providers;

        }
    }
}
