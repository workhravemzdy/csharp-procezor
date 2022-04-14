using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Registry;
using HraveMzdy.Procezor.Registry.Factories;
using ResultMonad;
using System.Linq;

namespace HraveMzdy.Procezor.Service
{
    public abstract class ServiceProcezor : IServiceProcezor
    {
        public VersionCode Version { get; }
        public IList<ArticleCode> CalcArticles { get; }
        protected IArticleSpecFactory ArticleFactory { get; set; }
        protected IConceptSpecFactory ConceptFactory { get; set; }
        protected IResultBuilder Builder { get; set; }
        public IList<ArticleTerm> BuilderOrder { get { return Builder.ArticleOrder; } }
        public IDictionary<ArticleTerm, IEnumerable<IArticleDefine>> BuilderPaths { get { return Builder.ArticlePaths; } }

        public ServiceProcezor(Int32 version, IList<ArticleCode> calcArticles)
        {
            this.Version = new VersionCode(version);

            this.CalcArticles = calcArticles.ToList();

            this.Builder = new ResultBuilder();
        }
        public abstract IEnumerable<IContractTerm> GetContractTerms(IPeriod period, IEnumerable<ITermTarget> targets);
        public abstract IEnumerable<IPositionTerm> GetPositionTerms(IPeriod period, IEnumerable<IContractTerm> contracts, IEnumerable<ITermTarget> targets);
        public IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IBundleProps ruleset, IEnumerable<ITermTarget> targets)
        {
            IEnumerable<Result<ITermResult, ITermResultError>> results = new List<Result<ITermResult, ITermResultError>>();

            bool success = InitWithPeriod(period);

            if (success == false)
            {
                return (results);
            }
            if (Builder != null)
            {
                var contractTerms = GetContractTerms(period, targets);
                var positionTerms = GetPositionTerms(period, contractTerms, targets);

                results = Builder.GetResults(ruleset, contractTerms, positionTerms, targets, CalcArticles);
            }
            return (results);
        }
        public bool InitWithPeriod(IPeriod period)
        {
            bool initResult = false;

            if (Builder != null)
            {
                initResult = true;
            }

            bool initBuilder = false;

            if (Builder != null)
            {
                initBuilder = (Builder.PeriodInit != period);
            }

            if (initBuilder && ArticleFactory != null && ConceptFactory != null) 
            {
                initResult = Builder.InitWithPeriod(Version, period, ArticleFactory, ConceptFactory);
            }

            if (initResult == false) {
                Console.WriteLine($"Period: {period.Code}, init with period failed");
            }
            return initResult;
        }
        public bool BuildFactories()
        {
            bool articleFactorySuccess = BuildArticleFactory();

            bool conceptFactorySuccess = BuildConceptFactory();

            if (!(articleFactorySuccess && conceptFactorySuccess)) {
                Console.WriteLine($"ServiceProcezor::BuildFactories(): Version: {this.Version}, build factories failed");
            }
            return (articleFactorySuccess && conceptFactorySuccess);
        }
        public IArticleSpec GetArticleSpec(ArticleCode code, IPeriod period, VersionCode version)
        {
            if (ArticleFactory == null)
            {
                return null;
            }
            return ArticleFactory.GetSpec(code, period, version);
        }
        public IConceptSpec GetConceptSpec(ConceptCode code, IPeriod period, VersionCode version)
        {
            if (ConceptFactory == null)
            {
                return null;
            }
            return ConceptFactory.GetSpec(code, period, version);
        }
        protected abstract bool BuildArticleFactory();
        protected abstract bool BuildConceptFactory();

    }
}
