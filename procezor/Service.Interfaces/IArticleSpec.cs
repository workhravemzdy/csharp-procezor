using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface IArticleSpec : IArticleDefine
    {
        IEnumerable<ArticleCode> Sums { get; }
        IArticleDefine Defs();
    }
}
