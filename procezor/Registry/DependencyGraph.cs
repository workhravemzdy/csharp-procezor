using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry
{
    sealed record ArticleEdge(ArticleTerm start, ArticleTerm stops)
    {
        public static ArticleEdge New(ArticleTerm start, ArticleTerm stops) => new(start, stops);
    }
    class DependencyGraph
    {
        public DependencyGraph()
        {
        }
        public Tuple<IList<ArticleTerm>, IDictionary<ArticleTerm, IEnumerable<IArticleDefine>>> InitGraphModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel)
        {
            IEnumerable<ArticleTerm> vertModel = CreateVertModel(articlesModel);

            IEnumerable<ArticleEdge> edgeModel = CreateEdgeModel(articlesModel, conceptsModel);

            IEnumerable<ArticleEdge> pendModel = CreatePendModel(articlesModel, conceptsModel);

            var order = CreateTopoModel(vertModel, edgeModel);

            var paths = CreatePathModel(articlesModel, vertModel, pendModel, order);

            return new Tuple<IList<ArticleTerm>, IDictionary<ArticleTerm, IEnumerable<IArticleDefine>>>(order, paths);
        }
        private IEnumerable<ArticleTerm> CreateVertModel(IEnumerable<IArticleSpec> articlesModel)
        {
            return articlesModel.Select((a) => (a.Term())).OrderBy((o) => (o)).ToList();
        }
        private IEnumerable<ArticleEdge> CreateEdgeModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel)
        {
            IEnumerable<ArticleEdge> init = new HashSet<ArticleEdge>();

            var edgeComparer = Comparer<ArticleEdge>.Create(
                (x, y) => {
                    if (x.start == y.start)
                    {
                        return x.stops.CompareTo(y.stops);
                    }
                    return x.start.CompareTo(y.start);
                });

            return articlesModel.Aggregate(init, (agr, x) => MergeEdges(articlesModel, conceptsModel, agr, x))
                .OrderBy((o) => (o), edgeComparer);
        }
        private IEnumerable<ArticleEdge> CreatePendModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel)
        {
            IEnumerable<ArticleEdge> init = new HashSet<ArticleEdge>();

            var edgeComparer = Comparer<ArticleEdge>.Create(
                (x, y) => {
                    if (x.start == y.start)
                    {
                        return x.stops.CompareTo(y.stops);
                    }
                    return x.start.CompareTo(y.start);
                });

            return articlesModel.Aggregate(init, (agr, x) => MergePends(articlesModel, conceptsModel, agr, x))
                .OrderBy((o) => (o), edgeComparer);
        }
        private IList<ArticleTerm> CreateTopoModel(IEnumerable<ArticleTerm> vertModel, IEnumerable<ArticleEdge> edgeModel)
        {
            IList<ArticleTerm> articlesOrder = new List<ArticleTerm>();

            IDictionary<ArticleTerm, Int32> degrees = vertModel.Select((x) => (x))
                .ToDictionary((k) => (k), (v) => (edgeModel).Count((e) => (e.stops == v)));

            Queue<ArticleTerm> queues = new Queue<ArticleTerm>(degrees.Where((x) => (x.Value == 0)).Select((x) => (x.Key)).OrderBy((o) => (o)));

            int index = 0;
            while (queues.Count != 0)
            {
                index++;
                var article = queues.Dequeue();
                articlesOrder.Add(article);
                IList<ArticleTerm> paths = edgeModel
                    .Where((x) => (x.start == article)).Select((x) => (x.stops)).ToList();
                paths.ToList().ForEach((p) => {
                    degrees[p] -= 1;
                    if (degrees[p] == 0)
                    {
                        queues.Enqueue(p);
                    }
                });
            }
            var modelLength = vertModel.Count();
            if (index != modelLength) {
                Console.WriteLine($"CreateTopoModel, build graph failed: {index}<>{modelLength}");
                return new List<ArticleTerm>();
            }
            return articlesOrder;
        }
        private IDictionary<ArticleTerm, IEnumerable<IArticleDefine>> CreatePathModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<ArticleTerm> vertModel, IEnumerable<ArticleEdge> edgeModel, IList<ArticleTerm> vertOrder)
        {
            return vertModel.Select((x) => (x)).ToDictionary((k) => (k), (v) => (MergePaths(articlesModel, edgeModel, vertOrder, v)));
        }
        private IEnumerable<ArticleEdge> MergeEdges(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel, IEnumerable<ArticleEdge> agr, IArticleSpec article)
        {
            IEnumerable<ArticleEdge> result = agr.ToHashSet();

            var concept = conceptsModel.FirstOrDefault((c) => (c.Code == article.Role));

            result = article?.Sums.Select((s) => ArticleEdge.New(article.Term(), GetArticleTerm(s, articlesModel))).Concat(result).ToHashSet();

            result = concept?.Path.Select((p) => ArticleEdge.New(GetArticleTerm(p, articlesModel), article.Term())).Concat(result).ToHashSet();

            return result;
        }
        private IEnumerable<ArticleEdge> MergePends(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel, IEnumerable<ArticleEdge> agr, IArticleSpec article)
        {
            IEnumerable<ArticleEdge> result = agr.ToHashSet();

            var concept = conceptsModel.FirstOrDefault((c) => (c.Code == article.Role));

            result = concept?.Path.Select((p) => ArticleEdge.New(GetArticleTerm(p, articlesModel), article.Term())).Concat(result).ToHashSet();

            return result;
        }
        private IEnumerable<IArticleDefine> MergePaths(IEnumerable<IArticleSpec> articlesModel, IEnumerable<ArticleEdge> edgeModel, IList<ArticleTerm> vertOrder, ArticleTerm article)
        {
            IEnumerable<IArticleDefine> articleInit = edgeModel
                .Where((e) => (e.stops == article)).Select((e) => GetArticleDefs(e.start.Code, articlesModel)).ToList();
            IEnumerable<IArticleDefine> articlePath = articleInit
                .Aggregate(articleInit, (agr, x) => MergeVert(articlesModel, edgeModel, agr, x));
            return articlePath.Distinct().OrderBy((x) => (x), new DefineComparator(vertOrder));
        }
        private IList<IArticleDefine> MergeVert(IEnumerable<IArticleSpec> articlesModel, IEnumerable<ArticleEdge> edgeModel, IEnumerable<IArticleDefine> agr, IArticleDefine x)
        {
            IEnumerable<IArticleDefine> resultInit = edgeModel.Where((e) => (e.stops == x.Term())).Select((e) => GetArticleDefs(e.start.Code, articlesModel));
            IEnumerable<IArticleDefine> resultList = resultInit.Aggregate(resultInit, (agr, x) => MergeVert(articlesModel, edgeModel, agr, x));
            return agr.Concat(resultList).Concat(new[] { x }).ToList();
        }
        private static IArticleDefine GetArticleDefs(ArticleCode article, IEnumerable<IArticleSpec> articlesModel)
        {
            IArticleSpec articleSpec = articlesModel.FirstOrDefault((m) => (m.Code == article));
            if (articleSpec == null)
            {
                return new ArticleDefine();
            }
            return articleSpec.Defs();
        }
        private static ArticleTerm GetArticleTerm(ArticleCode article, IEnumerable<IArticleSpec> articlesModel)
        {
            IArticleSpec articleSpec = articlesModel.FirstOrDefault((m) => (m.Code == article));
            if (articleSpec == null)
            {
                return ArticleTerm.Zero;
            }
            return articleSpec.Term();
        }
        private class DefineComparator : IComparer<IArticleDefine>
        {
            private IList<ArticleTerm> TopoOrders;
            public DefineComparator(IList<ArticleTerm> topoOrders)
            {
                TopoOrders = topoOrders.ToList();
            }

            public int Compare(IArticleDefine x, IArticleDefine y)
            {
                var xIndex = TopoOrders.IndexOf(x.Term());

                var yIndex = TopoOrders.IndexOf(y.Term());

                if (xIndex == -1 && yIndex == -1)
                {
                    return 0;
                }

                if (xIndex == -1 && yIndex != -1)
                {
                    return -1;
                }

                if (xIndex != -1 && yIndex == -1)
                {
                    return 1;
                }

                return xIndex.CompareTo(yIndex);
            }
        }
    }
}
