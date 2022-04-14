using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    interface ITermList<K, V> : IEnumerable<V> where V : K
    {
        ITermList<ITermSymbol, ITermTarget> AddItem(MonthCode period, ContractCode contract, PositionCode position,
             ArticleCode article, ConceptCode concept, Int32 basis);
    }
}
