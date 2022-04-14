using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class TermSymbol : ITermSymbol
    {
        public ContractCode Contract { get; protected set; }

        public PositionCode Position { get; protected set; }

        public MonthCode MonthCode { get; protected set; }

        public ArticleCode Article { get; protected set; }

        public VariantCode Variant { get; protected set; }

        public static TermSymbol TermPositionArtVar(IPeriod period, ContractCode contract, PositionCode position, ArticleCode article, VariantCode variant)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            return new TermSymbol(monthCode, contract, position, variant, article);
        }
        public static TermSymbol TermPositionArtVar(IPeriod period, Int16 contractCode, Int16 positionCode, Int32 articleCode, Int16 variantCode)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            ContractCode contract = ContractCode.Get(contractCode);

            PositionCode position = PositionCode.Get(positionCode);
            
            ArticleCode article = ArticleCode.Get(articleCode);

            VariantCode variant = VariantCode.Get(variantCode);

            return new TermSymbol(monthCode, contract, position, variant, article);
        }
        public static TermSymbol TermContractArcVar(IPeriod period, ContractCode contract, ArticleCode article, VariantCode variant)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            return new TermSymbol(monthCode, contract, PositionCode.Zero, variant, article);
        }
        public static TermSymbol TermContractArcVar(IPeriod period, Int16 contractCode, Int32 articleCode, Int16 variantCode)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            ContractCode contract = ContractCode.Get(contractCode);

            ArticleCode article = ArticleCode.Get(articleCode);

            VariantCode variant = VariantCode.Get(variantCode);

            return new TermSymbol(monthCode, contract, PositionCode.Zero, variant, article);
        }
        public static TermSymbol TermArticleVar(IPeriod period, ArticleCode article, VariantCode variant)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            return new TermSymbol(monthCode, ContractCode.Zero, PositionCode.Zero, variant, article);
        }
        public static TermSymbol TermArticleVar(IPeriod period, Int32 articleCode, Int16 variantCode)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            ArticleCode article = ArticleCode.Get(articleCode);

            VariantCode variant = VariantCode.Get(variantCode);

            return new TermSymbol(monthCode, ContractCode.Zero, PositionCode.Zero, variant, article);
        }
        public TermSymbol()
        {
            this.Contract = ContractCode.Zero;
            this.Position = PositionCode.Zero;
            this.MonthCode = MonthCode.Zero;
            this.Article = ArticleCode.Zero;
            this.Variant = VariantCode.Zero;
        }
        public TermSymbol(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant, ArticleCode article)
        {
            this.Contract = contract;
            this.Position = position;
            this.MonthCode = monthCode;
            this.Variant = variant;
            this.Article = article;
        }
        public virtual string ArticleDescr()
        {
            return string.Format("ArticleCode for {0}", Article.Value);
        }
        public bool IsPositionArticleEqual(ITermSymbol symbol)
        {
            if (symbol == null)
            {
                return false;
            }
            if (this.MonthCode != symbol.MonthCode)
            {
                return false;
            }
            if (this.Contract != symbol.Contract)
            {
                return false;
            }
            if (this.Position != symbol.Position)
            {
                return false;
            }
            return (this.Article == symbol.Article);
        }
        public bool IsContractArticleEqual(ITermSymbol symbol)
        {
            if (symbol == null)
            {
                return false;
            }
            if (this.MonthCode != symbol.MonthCode)
            {
                return false;
            }
            if (this.Contract != symbol.Contract)
            {
                return false;
            }
            return (this.Article == symbol.Article);
        }
        public bool IsArticleEqual(ITermSymbol symbol)
        {
            if (symbol == null)
            {
                return false;
            }
            if (this.MonthCode != symbol.MonthCode)
            {
                return false;
            }
            return (this.Article == symbol.Article);
        }
    }
}
