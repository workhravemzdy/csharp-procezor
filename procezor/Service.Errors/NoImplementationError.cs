using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class NoImplementationError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string impDescr)
        {
            return new NoImplementationError(period, target, impDescr);
        }
        public static Either<ITermResultError, ITermResult> CreateResultError(IPeriod period, ITermTarget target, string impDescr)
        {
            return Left(NoImplementationError.CreateError(period, target, impDescr));
        }
        NoImplementationError(IPeriod period, ITermTarget target, string impDescr) : base(period, target, null, $"No implementation for {impDescr}!")
        {
        }
    }
}
