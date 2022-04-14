using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Providers
{
    public abstract class ConceptSpecProvider : IConceptSpecProvider
    {
        public ConceptSpecProvider(Int32 code)
        {
            Code = new ConceptCode(code);
        }

        public ConceptCode Code { get; protected set; }

        public abstract IConceptSpec GetSpec(IPeriod period, VersionCode version);
    }
}
