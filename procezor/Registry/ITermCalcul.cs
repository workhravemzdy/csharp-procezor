using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Registry
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IEnumerable<Result<ITermResult, ITermResultError>>>;
    interface ITermCalcul : ITermSymbol
    {
        ITermTarget Target { get; }
        IArticleSpec Spec { get; }
        ResultFunc ResultDelegate { get; }
        IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results);
    }
}
