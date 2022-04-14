using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Models
{
    class TargetList : TermList<ITermTarget>
    {
        public TargetList() : base()
        {
        }

        public TargetList(IEnumerable<ITermTarget> list) : base(list)
        {
        }
        public override ITermList<ITermSymbol, ITermTarget> AddItem(MonthCode period, ContractCode contract, PositionCode position,
            ArticleCode article, ConceptCode concept, Int32 basis)
        {
            var variant = GetNewVariant(InternalList, contract, position, article);

            ITermTarget target = new TermTarget(period, contract, position, new VariantCode(variant),
                article, concept);

            return Add(target);
        }
        protected ITermList<ITermSymbol, ITermTarget> Add(ITermTarget item)
        {
            var results = new TargetList(InternalList.Concat(new List<ITermTarget>() { item }).
                OrderBy((x) => (x), new SymbolComparator()).ToList());

            return results;
        }
        protected ITermList<ITermSymbol, ITermTarget> AddList(IEnumerable<ITermTarget> list)
        {
            var results = new TargetList(InternalList.Concat(list).
                OrderBy((x) => (x), new SymbolComparator()).ToList());

            return results;
        }
        private class SymbolComparator : IComparer<ITermSymbol>
        {
            public SymbolComparator()
            {
            }

            public int Compare(ITermSymbol x, ITermSymbol y)
            {
                if (x == y)
                {
                    return 0;
                }

                if (x == null && y != null)
                {
                    return -1;
                }

                if (x != null && y == null)
                {
                    return 1;
                }

                if (x.MonthCode != y.MonthCode)
                {
                    return x.MonthCode.CompareTo(y.MonthCode);
                }
                if (x.Contract != y.Contract)
                {
                    return x.Contract.CompareTo(y.Contract);
                }
                if (x.Position != y.Position)
                {
                    return x.Position.CompareTo(y.Position);
                }
                if (x.Article != y.Article)
                {
                    return x.Article.CompareTo(y.Article);
                }
                return x.Variant.CompareTo(y.Variant);
            }
        }
    }
}
