using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidRulesetError<T> : TermResultError where T : IProps
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new InvalidRulesetError<T>(period, target);
        }
        public static Either<ITermResultError, ITermResult> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Left(InvalidRulesetError<T>.CreateError(period, target));
        }
        InvalidRulesetError(IPeriod period, ITermTarget target) : base(period, target, null, $"Invalid {typeof(T).Name} Ruleset error!")
        {
        }
    }
}
