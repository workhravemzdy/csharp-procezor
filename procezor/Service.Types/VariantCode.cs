using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record VariantCode(Int16 Value) : ICodeValue<Int16>, IComparable<VariantCode>
    {
        public static readonly Int16 ZeroCode = 0;

        public static readonly VariantCode Zero = New();

        public static VariantCode New() => new(ZeroCode);

        public static VariantCode Get(Int16 value) => new(value);

        public static VariantCode Reduce(VariantCode code, VariantCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(VariantCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
