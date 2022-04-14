using System;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry.Factories
{
    public interface IArticleSpecFactory : ISpecFactory<IArticleSpecProvider, IArticleSpec, ArticleCode>
    {
    }
}
