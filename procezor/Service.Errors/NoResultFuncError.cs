using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class NoResultFuncError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new NoResultFuncError(period, target);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Result.Fail<ITermResult, ITermResultError>(NoResultFuncError.CreateError(period, target));
        }
        NoResultFuncError(IPeriod period, ITermTarget target) : base(period, target, null, "No result calculation function!")
        {
        }
    }
}
