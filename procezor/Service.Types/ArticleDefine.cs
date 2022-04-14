using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class ArticleDefine : IArticleDefine
    {
        public ArticleCode Code { get; }
        public ArticleSeqs Seqs { get; }
        public ConceptCode Role { get; }
        public ArticleDefine()
        {
            Code = ArticleCode.New();

            Seqs = ArticleSeqs.New();

            Role = ConceptCode.New();
        }
        public ArticleDefine(Int32 code, Int16 seqs, Int32 role)
        {
            Code = new ArticleCode(code);

            Seqs = new ArticleSeqs(seqs);

            Role = new ConceptCode(role);
        }
        public ArticleDefine(IArticleDefine define)
        {
            Code = define.Code;

            Seqs = define.Seqs;

            Role = define.Role;
        }
        public ArticleTerm Term()
        {
            return ArticleTerm.Get(Code.Value, Seqs.Value);
        }

        public int CompareTo(object obj)
        {
            IArticleDefine other = obj as IArticleDefine;

            return (this.Code.CompareTo(other.Code));
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            IArticleDefine other = obj as IArticleDefine;

            return (this.Code.Equals(other.Code));
        }

        public override int GetHashCode()
        {
            int result = this.Code.GetHashCode();

            return result;
        }
    }
}
