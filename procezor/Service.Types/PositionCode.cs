using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record PositionCode(Int16 Value) : ICodeValue<Int16>, IComparable<PositionCode>
    {
        public static readonly Int16 ZeroCode = 0;

        public static readonly PositionCode Zero = New();

        public static PositionCode New() => new(ZeroCode);

        public static PositionCode Get(Int16 value) => new(value);

        public static PositionCode Reduce(PositionCode code, PositionCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(PositionCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
