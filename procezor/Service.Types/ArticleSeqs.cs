using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record ArticleSeqs(Int16 Value) : ISpecSeqs, IComparable<ArticleSeqs>
    {
        public static readonly Int16 ZeroCode = 0;

        public static readonly ArticleSeqs Zero = New();

        public static ArticleSeqs New() => new(ZeroCode);

        public static ArticleSeqs Get(Int16 value) => new(value);

        public int CompareTo(ArticleSeqs other)
        {
            return this.Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
