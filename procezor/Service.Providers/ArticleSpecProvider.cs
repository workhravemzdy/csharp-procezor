using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Providers
{
    public abstract class ArticleSpecProvider : IArticleSpecProvider
    {
        public ArticleSpecProvider(Int32 code)
        {
            Code = new ArticleCode(code);
        }

        public ArticleCode Code { get; protected set; }

        public abstract IArticleSpec GetSpec(IPeriod period, VersionCode version);
    }
}
