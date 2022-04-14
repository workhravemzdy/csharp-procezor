using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Registry
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IEnumerable<Result<ITermResult, ITermResultError>>>;
    class TermCalcul : TermSymbol, ITermCalcul
    {
        public TermCalcul(ITermTarget target, IArticleSpec spec, ResultFunc resultDelegate)
            : base(target.MonthCode, target.Contract, target.Position, target.Variant, target.Article)
        {
            Target = target;
            Spec = spec;

            ResultDelegate = resultDelegate;
        }
        public ITermTarget Target { get; }
        public IArticleSpec Spec { get; }
        public ResultFunc ResultDelegate { get; }

        public IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            if (ResultDelegate == null)
            {
                var resultError = NoResultFuncError.CreateResultError(period, Target);
                return new Result<ITermResult, ITermResultError>[] { resultError };
            }
            var resultTarget = ResultDelegate(Target, Spec, period, ruleset, results);
            return resultTarget.ToArray();
        }
    }
}
