using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Registry.Factories;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Registry
{
    public interface IResultBuilder
    {
        VersionCode Version { get; }
        IPeriod PeriodInit { get; } 
        bool InitWithPeriod(VersionCode version, IPeriod period, IArticleSpecFactory articleFactory, IConceptSpecFactory conceptFactory);
        IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IBundleProps ruleset, 
            IEnumerable<IContractTerm> contractTerms, IEnumerable<IPositionTerm> positionTerms, 
            IEnumerable<ITermTarget> targets, IEnumerable<ArticleCode> calcArticles);
        IList<ArticleTerm> ArticleOrder { get; }
        IDictionary<ArticleTerm, IEnumerable<IArticleDefine>> ArticlePaths { get; }
    }
}
