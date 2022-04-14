using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Models
{
    abstract class TermList<V> : ITermList<ITermSymbol, V> where V : ITermSymbol
    {
        const Int16 VARIANT_CODE_FIRST = 1;
        const Int16 VARIANT_CODE_NULLS = 0;

        public TermList()
        {
            InternalList = new List<V>();
        }
        public TermList(IEnumerable<V> list)
        {
            InternalList = list.ToList();
        }
        #region IENUMERATOR_SOURCE_MODEL
        public IEnumerator<V> GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }
        public IEnumerable<V> GetList()
        {
            return InternalList.ToList();
        }
        #endregion

        protected IList<V> InternalList;
        public abstract ITermList<ITermSymbol, ITermTarget> AddItem(MonthCode period, ContractCode contract, PositionCode position,
            ArticleCode article, ConceptCode concept, Int32 basis);

        protected static Int16 GetNewVariant(IEnumerable<ITermTarget> targets, ContractCode contract, PositionCode position, ArticleCode article)
        {
            IEnumerable<Int16> articleVariants = SelectArticleCodeVariants(targets, contract, position, article);

            return NextsVariantFromList(articleVariants.OrderBy(x => x).ToArray());
        }
        protected static IEnumerable<Int16> SelectArticleCodeVariants(IEnumerable<ITermTarget> targets, ContractCode contract, PositionCode position, ArticleCode article)
        {
            return targets.Where(x => (EqualitySelector(x, contract, position, article))).Select(x => x.Variant.Value).ToList();
        }

        protected static Int16 FirstVariantFromList(IEnumerable<Int16> variants)
        {
            Int16 firstVariantCode = variants.DefaultIfEmpty(VARIANT_CODE_FIRST).First();

            return firstVariantCode;
        }

        protected static Int16 NextsVariantFromList(IEnumerable<Int16> variants)
        {
            Int16 lastVariantCode = variants.Aggregate(VARIANT_CODE_NULLS, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));

            return (Int16)(lastVariantCode + 1);
        }
        protected static bool EqualitySelector(ITermSymbol target, ContractCode contract, PositionCode position, ArticleCode article)
        {
            return (target.Contract == contract && target.Position == position && target.Article == article);
        }
    }
}
