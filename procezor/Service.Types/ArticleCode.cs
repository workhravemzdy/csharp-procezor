using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record ArticleCode(Int32 Value) : ISpecCode, IComparable<ArticleCode>
    {
        public static readonly Int32 ZeroCode = 0;

        public static readonly ArticleCode Zero = New();

        public static ArticleCode New() => new(ZeroCode);

        public static ArticleCode Get(Int32 value) => new(value);

        public static ArticleCode Reduce(ArticleCode code, ArticleCode otherCode)
        {
            if (code != otherCode)
            {
                return Zero;
            }
            return code;
        }

        public int CompareTo(ArticleCode other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
