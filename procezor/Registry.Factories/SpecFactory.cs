using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry.Factories
{
    using CODE = Int32;
    public abstract class SpecFactory<P, S, C> : ISpecFactory<P, S, C> 
        where P : ISpecProvider<S, C>
        where S : ISpecDefine<C>
        where C : ISpecCode
    {
        protected IReadOnlyDictionary<CODE, P> Providers { get; set; }
        protected P NotFoundProvider { get; set; }
        protected S NotFoundSpec { get; set; }

        public SpecFactory()
        {
        }

        static protected IReadOnlyDictionary<CODE, P> BuildProvidersFromAssembly<A>() where A : class
        {
            var assemblyType = typeof(A);
            var providerType = typeof(P);

            var providers = assemblyType.Assembly.DefinedTypes
                .Where((x) => (IsValidType(x) && HasValidConstructor(x)))
                .Select((x) => (Activator.CreateInstance(x)))
                .Cast<P>()
                .ToImmutableDictionary(x => x.Code.Value, x => x);

            return providers;

        }

        public S GetSpec(C code, IPeriod period, VersionCode version)
        {
            P provider = GetProvider(code, NotFoundProvider);
            if (provider == null)
            {
                return NotFoundSpec;
            }
            return provider.GetSpec(period, version);
        }
        public IEnumerable<S> GetSpecList(IPeriod period, VersionCode version)
        {
            return Providers.Select((x) => (x.Value.GetSpec(period, version))).ToList();
        }
        private static bool IsValidType(Type testType)
        {
            var providerType = typeof(P);

            return (providerType.IsAssignableFrom(testType) && !testType.IsInterface && !testType.IsAbstract);
        }
        private static bool HasValidConstructor(Type testType)
        {
            var parameterlessConstructor = testType.GetConstructors()
                .SingleOrDefault((c) => (c.GetParameters().Length == 0));
            return (parameterlessConstructor is not null);
        }
        private P GetProvider(C code, P defProvider)
        {
            P provider = Providers.GetValueOrDefault(code.Value, defProvider);

            return provider;

        }
    }
}
