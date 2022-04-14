using System;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ITermSymbol
    {
        ContractCode Contract { get; }
        PositionCode Position { get; }
        MonthCode MonthCode { get; }
        ArticleCode Article { get; }
        VariantCode Variant { get; }
        string ArticleDescr();

        bool IsPositionArticleEqual(ITermSymbol symbol);
        bool IsContractArticleEqual(ITermSymbol symbol);
        bool IsArticleEqual(ITermSymbol symbol);
    }
}
