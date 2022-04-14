using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Procezor.Service.Types
{
    public sealed record ArticleTerm(ArticleCode Code, ArticleSeqs Seqs) : IComparable<ArticleTerm>
    {
        public static readonly ArticleTerm Zero = New();

        public static ArticleTerm New() => new(ArticleCode.New(), ArticleSeqs.New());

        public static ArticleTerm Get(Int32 valueCode, Int16 valueSeqs) => new(ArticleCode.Get(valueCode), ArticleSeqs.Get(valueSeqs));

        public int CompareTo(ArticleTerm other)
        {
            if (this.Seqs.CompareTo(other.Seqs)==0)
            {
                return this.Code.CompareTo(other.Code);
            }
            return this.Seqs.CompareTo(other.Seqs);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Seqs, this.Code);
        }
    }

}
