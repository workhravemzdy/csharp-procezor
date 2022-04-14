using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidResultError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return new InvalidResultError(period, target, typeDesr);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return Result.Fail<ITermResult, ITermResultError>(InvalidResultError.CreateError(period, target, typeDesr));
        }
        InvalidResultError(IPeriod period, ITermTarget target, string typeDesr) : base(period, target, null, $"Invalid result type {typeDesr} error!")
        {
        }
    }
}
