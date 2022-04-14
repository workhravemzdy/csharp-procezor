using System;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class TermTarget : TermSymbol, ITermTarget
    {
        public TermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article)
        {
            Concept = concept;
        }

        public ConceptCode Concept { get; private set; }
        public virtual string ConceptDescr()
        {
            return string.Format("ConceptCode for {0}", Concept.Value);
        }
    }
}
