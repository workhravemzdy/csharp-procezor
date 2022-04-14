using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Service
{
    public interface IServiceProcezor
    {
        VersionCode Version { get; }
        IList<ArticleCode> CalcArticles { get; }
        IList<ArticleTerm> BuilderOrder { get; }
        IDictionary<ArticleTerm, IEnumerable<IArticleDefine>> BuilderPaths { get; }

        IEnumerable<IContractTerm> GetContractTerms(IPeriod period, IEnumerable<ITermTarget> targets);
        IEnumerable<IPositionTerm> GetPositionTerms(IPeriod period, IEnumerable<IContractTerm> contracts, IEnumerable<ITermTarget> targets);
        IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IBundleProps ruleset, IEnumerable<ITermTarget> targets);
        bool BuildFactories();
        bool InitWithPeriod(IPeriod period);
        IArticleSpec GetArticleSpec(ArticleCode code, IPeriod period, VersionCode version);
        IConceptSpec GetConceptSpec(ConceptCode code, IPeriod period, VersionCode version);
    }
}
