using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class NoResultFuncError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new NoResultFuncError(period, target);
        }
        public static Either<ITermResultError, ITermResult> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Left(NoResultFuncError.CreateError(period, target));
        }
        NoResultFuncError(IPeriod period, ITermTarget target) : base(period, target, null, "No result calculation function!")
        {
        }
    }
}
