using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ResultMonad;

namespace ProcezorTests.Registry.Providers
{
    class ExampleConceptSpec : ConceptSpec
    {
        public ExampleConceptSpec(Int32 code) : base(code)
        {
        }
    }

    class ExampleTermTarget : TermTarget
    {
        public ExampleTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept)
        {
        }
        public override string ArticleDescr()
        {
            return ArticleEnumUtils.GetSymbol(Article.Value);
        }
        public override string ConceptDescr()
        {
            return ConceptEnumUtils.GetSymbol(Concept.Value);
        }
    }

    class ExampleTermResult : TermResult
    {
        public ExampleTermResult(ITermTarget target, IArticleSpec spec) : base(target, spec)
        {
        }
        public override string ArticleDescr()
        {
            return ArticleEnumUtils.GetSymbol(Article.Value);
        }
        public override string ConceptDescr()
        {
            return ConceptEnumUtils.GetSymbol(Concept.Value);
        }
    }

}
