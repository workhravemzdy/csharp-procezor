using System;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ITermResult : ITermSymbol
    {
        ITermTarget Target { get; }
        IArticleSpec Spec { get; }
        ConceptCode Concept { get; }
        string ConceptDescr();
    }
}
