using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidTargetError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return new InvalidTargetError(period, target, typeDesr);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return Result.Fail<ITermResult, ITermResultError>(InvalidTargetError.CreateError(period, target, typeDesr));
        }
        InvalidTargetError(IPeriod period, ITermTarget target, string typeDesr) : base(period, target, null, $"Invalid target type {typeDesr} error!")
        {
        }
    }
}
