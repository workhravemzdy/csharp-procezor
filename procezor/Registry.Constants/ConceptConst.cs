using System;

namespace HraveMzdy.Procezor.Registry.Constants
{
    public enum ConceptConst : Int32
    {
        CONCEPT_NOTFOUND = 0,
    }
    public static class ConceptConstExtensions
    {
        public static string GetSymbol(this ConceptConst concept)
        {
            return concept.ToString();
        }
    }
}
