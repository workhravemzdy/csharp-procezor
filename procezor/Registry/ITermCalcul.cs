using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;

namespace HraveMzdy.Procezor.Registry
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Either<ITermResultError, ITermResult>>, IEnumerable<Either<ITermResultError, ITermResult>>>;
    interface ITermCalcul : ITermSymbol
    {
        ITermTarget Target { get; }
        IArticleSpec Spec { get; }
        ResultFunc ResultDelegate { get; }
        IEnumerable<Either<ITermResultError, ITermResult>> GetResults(IPeriod period, IBundleProps ruleset, IList<Either<ITermResultError, ITermResult>> results);
    }
}
