using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry.Factories
{
    public interface ISpecFactory<P, S, C> 
        where P : ISpecProvider<S, C>
        where S : ISpecDefine<C>
        where C : ISpecCode
    {
        S GetSpec(C code, IPeriod period, VersionCode version);
        IEnumerable<S> GetSpecList(IPeriod period, VersionCode version);
    }
}
