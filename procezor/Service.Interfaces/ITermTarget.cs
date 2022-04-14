using System;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ITermTarget : ITermSymbol
    {
        ConceptCode Concept { get; }
        string ConceptDescr();
    }
}
