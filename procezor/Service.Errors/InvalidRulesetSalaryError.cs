using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidRulesetError<T> : TermResultError where T : IProps
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new InvalidRulesetError<T>(period, target);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Result.Fail<ITermResult, ITermResultError>(InvalidRulesetError<T>.CreateError(period, target));
        }
        InvalidRulesetError(IPeriod period, ITermTarget target) : base(period, target, null, $"Invalid {typeof(T).Name} Ruleset error!")
        {
        }
    }
}
