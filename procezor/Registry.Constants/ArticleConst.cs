using System;

namespace HraveMzdy.Procezor.Registry.Constants
{
    public enum ArticleConst : Int32
    {
        ARTICLE_NOTFOUND = 0,
    }
    public static class ArticleConstExtensions
    {
        public static string GetSymbol(this ArticleConst article)
        {
            return article.ToString();
        }
    }
}
