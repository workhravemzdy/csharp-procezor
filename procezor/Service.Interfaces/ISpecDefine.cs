using System;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ISpecDefine<T> : IComparable where T : ISpecCode
    {
        T Code { get; }
    }
}
