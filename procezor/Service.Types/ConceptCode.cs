using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record ConceptCode(Int32 Value) : ISpecCode, IComparable<ConceptCode>
    {
        public static readonly Int32 ZeroCode = 0;

        public static readonly ConceptCode Zero = New();

        public static ConceptCode New() => new(ZeroCode);

        public static ConceptCode Get(Int32 value) => new(value);

        public static ConceptCode Reduce(ConceptCode code, ConceptCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(ConceptCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
