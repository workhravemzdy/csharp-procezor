using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record VersionCode(Int32 Value) : ICodeValue<Int32>, IComparable<VersionCode>
    {
        public static readonly Int32 ZeroCode = 0;

        public static readonly VersionCode Zero = New();

        public static VersionCode New() => new(ZeroCode);

        public static VersionCode Get(Int32 value) => new(value);

        public static VersionCode Reduce(VersionCode code, VersionCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(VersionCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
