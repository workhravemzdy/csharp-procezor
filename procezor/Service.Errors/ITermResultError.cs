using HraveMzdy.Procezor.Service.Types;
using System;

namespace HraveMzdy.Procezor.Service.Errors
{
    public interface ITermResultError
    {
        string Description();
        ArticleCode Article { get; }
        ConceptCode Concept { get; }
        string ArticleDescr();
        string ConceptDescr();
    }
}
