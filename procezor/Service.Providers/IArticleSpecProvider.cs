using System;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Providers
{
    public interface IArticleSpecProvider : ISpecProvider<IArticleSpec, ArticleCode>
    {
    }
}
