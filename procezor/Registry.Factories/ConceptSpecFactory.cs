using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Registry.Factories
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IList<Result<ITermResult, ITermResultError>>>;
    class NotFoundConceptProvider : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ConceptConst.CONCEPT_NOTFOUND;
        public class NotFoundConceptSpec : ConceptSpec
        {
            public NotFoundConceptSpec() : base(CONCEPT_CODE)
            {
                Path = new List<ArticleCode>();

                //ResultDelegate;
            }
        }
        public NotFoundConceptProvider() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new NotFoundConceptSpec();
        }
    }

    public class ConceptSpecFactory : SpecFactory<IConceptSpecProvider, IConceptSpec, ConceptCode>, IConceptSpecFactory
    {
        public ConceptSpecFactory()
        {
            this.NotFoundProvider = new NotFoundConceptProvider();

            this.NotFoundSpec = new NotFoundConceptProvider.NotFoundConceptSpec();
        }
    }
}
