using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class TermResult : TermSymbol, ITermResult
    {
        public ITermTarget Target { get; protected set; }
        public IArticleSpec Spec { get; protected set; }
        public ConceptCode Concept { get; private set; }

        public TermResult(ITermTarget target, IArticleSpec spec) : base()
        {
            Target = target;
            Spec = spec;

            Concept = ConceptCode.Zero;

            if (target != null)
            {
                Concept = Target.Concept;
                Contract = Target.Contract;
                Position = Target.Position;
                MonthCode = Target.MonthCode;
                Article = Target.Article;
                Variant = Target.Variant;
            }
        }
        public TermResult(ITermTarget target, ContractCode con, IArticleSpec spec) : base()
        {
            Target = target;
            Spec = spec;

            Concept = ConceptCode.Zero;

            if (target != null)
            {
                Concept = Target.Concept;
                Contract = Target.Contract;
                Position = Target.Position;
                MonthCode = Target.MonthCode;
                Article = Target.Article;
                Variant = Target.Variant;
            }

            Contract = con;
        }
        public virtual string ConceptDescr()
        {
            return Target?.ConceptDescr() ?? string.Format("ConceptCode for {0}", Concept.Value);
        }
    }
}
