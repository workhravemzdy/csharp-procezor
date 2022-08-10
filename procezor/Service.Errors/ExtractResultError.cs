using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class ExtractResultError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget result, ITermSymbol target, ITermResultError inner, string errorText)
        {
            return new ExtractResultError(period, result, target, inner, errorText);
        }
        public static Either<ITermResultError, ITermResult> CreateResultError(IPeriod period, ITermTarget result, ITermSymbol target, ITermResultError inner, string errorText)
        {
            return Left(ExtractResultError.CreateError(period, result, target, inner, errorText));
        }
        protected ExtractResultError(IPeriod period, ITermTarget result, ITermSymbol target, ITermResultError inner, string errorText) : base(period, result, inner, errorText)
        {
            Error = $"{Error} for {target.ArticleDescr()}";  
        }
    }
}
