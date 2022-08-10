using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidResultError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return new InvalidResultError(period, target, typeDesr);
        }
        public static Either<ITermResultError, ITermResult> CreateResultError(IPeriod period, ITermTarget target, string typeDesr)
        {
            return Left(InvalidResultError.CreateError(period, target, typeDesr));
        }
        InvalidResultError(IPeriod period, ITermTarget target, string typeDesr) : base(period, target, null, $"Invalid result type {typeDesr} error!")
        {
        }
    }
}
