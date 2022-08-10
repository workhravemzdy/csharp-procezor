using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using LanguageExt;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Either<ITermResultError, ITermResult>>, IList<Either<ITermResultError, ITermResult>>>;
    public interface IConceptSpec : IConceptDefine
    {
        IEnumerable<ArticleCode> Path { get; }
        ResultFunc ResultDelegate { get; }
        IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, 
            IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var);
    }
}
