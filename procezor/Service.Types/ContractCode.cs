using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record ContractCode(Int16 Value) : ICodeValue<Int16>, IComparable<ContractCode>
    {
        public static readonly Int16 ZeroCode = 0;

        public static readonly ContractCode Zero = New();

        public static ContractCode New() => new(ZeroCode);

        public static ContractCode Get(Int16 value) => new(value);

        public static ContractCode Reduce(ContractCode code, ContractCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(ContractCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
