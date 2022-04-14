using System;
using System.Text;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class TermResultError : ITermResultError 
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, ITermResultError inner, string errorText)
        {
            return new TermResultError(period, target, inner, errorText);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target, ITermResultError inner, string errorText)
        {
            return Result.Fail<ITermResult, ITermResultError>(TermResultError.CreateError(period, target, inner, errorText));
        }
        protected TermResultError(IPeriod period, ITermTarget target, ITermResultError inner, string errorText)
        {
            Period = period;
            Target = target;

            Contract = target?.Contract ?? ContractCode.Zero;
            Position = target?.Position ??  PositionCode.Zero;
            Article =  target?.Article ??  ArticleCode.Zero;
            Concept =  target?.Concept ??  ConceptCode.Zero;
            Variant =  target?.Variant ??  VariantCode.Zero;

            InnerResult = inner;

            Error = errorText;
        }
        public string ArticleDescr()
        {
             return Target?.ArticleDescr() ?? $"ArticleCode for {Article.Value}";
        }
        public string ConceptDescr()
        {
            return Target?.ConceptDescr() ?? $"ConceptCode for {Concept.Value}";
        }
        public string Description()
        {
            StringBuilder errorBuilder = new StringBuilder(Error);
            errorBuilder.AppendLine(ArticleName);
            errorBuilder.AppendLine(ConceptName);
            if (InnerResult != null)
            {
                errorBuilder.AppendLine("Inner error:");
                errorBuilder.Append(InnerResult.Description());
            }
            return errorBuilder.ToString();
        }
        public IPeriod Period { get; protected set; }
        public ITermTarget Target { get; protected set; }
        public ContractCode Contract { get; protected set; }
        public PositionCode Position { get; protected set; }
        public ArticleCode Article { get; protected set; }
        public string ArticleName { get; protected set; }
        public ConceptCode Concept { get; protected set; }
        public string ConceptName { get; protected set; }
        public VariantCode Variant { get; protected set; }
        public ITermResultError InnerResult { get; protected set; }
        public string Error { get; protected set; }
    }
}
