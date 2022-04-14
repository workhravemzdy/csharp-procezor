using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Providers
{
    public interface ISpecProvider<S, C> where C : ISpecCode
    {
        C Code { get; }
        S GetSpec(IPeriod period, VersionCode version);
    }
}
