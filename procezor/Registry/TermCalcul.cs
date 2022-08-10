using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using LanguageExt;

namespace HraveMzdy.Procezor.Registry
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Either<ITermResultError, ITermResult>>, IEnumerable<Either<ITermResultError, ITermResult>>>;
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

        public IEnumerable<Either<ITermResultError, ITermResult>> GetResults(IPeriod period, IBundleProps ruleset, IList<Either<ITermResultError, ITermResult>> results)
        {
            if (ResultDelegate == null)
            {
                var resultError = NoResultFuncError.CreateResultError(period, Target);
                return new Either<ITermResultError, ITermResult>[] { resultError };
            }
            var resultTarget = ResultDelegate(Target, Spec, period, ruleset, results);
            return resultTarget.ToArray();
        }
    }
}
