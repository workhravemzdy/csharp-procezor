using System;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry.Factories
{
    public interface IConceptSpecFactory : ISpecFactory<IConceptSpecProvider, IConceptSpec, ConceptCode>
    {
    }
}
