using System;
using HraveMzdy.Procezor.Registry.Factories;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Factories
{
    class ExampleConceptFactory : ConceptSpecFactory
    {
        public ExampleConceptFactory()
        {
            this.Providers = BuildProvidersFromAssembly<ExampleConceptFactory>();
        }
    }
}