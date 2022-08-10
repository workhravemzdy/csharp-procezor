using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidTargetError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return new InvalidTargetError(period, target, typeDesr);
        }
        public static Either<ITermResultError, ITermResult> CreateResultError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return Left(InvalidTargetError.CreateError(period, target, typeDesr));
        }
        InvalidTargetError(IPeriod period, ITermTarget target, string typeDesr) : base(period, target, null, $"Invalid target type {typeDesr} error!")
        {
        }
    }
}
