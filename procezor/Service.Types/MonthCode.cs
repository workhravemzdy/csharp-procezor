using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record MonthCode(Int32 Value) : ICodeValue<Int32>, IComparable<MonthCode>
    {
        public static readonly Int32 ZeroCode = 0;

        public static readonly MonthCode Zero = New();

        public static MonthCode New() => new(ZeroCode);

        public static MonthCode Get(Int32 value) => new(value);

        public static MonthCode Reduce(MonthCode code, MonthCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(MonthCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
