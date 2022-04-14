using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;
using MaybeMonad;

namespace HraveMzdy.Procezor.Service.Providers
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IList<Result<ITermResult, ITermResultError>>>;
    public abstract class ConceptSpec : IConceptSpec
    {
        public IEnumerable<ArticleCode> Path { get; protected set; }
        public ResultFunc ResultDelegate { get; protected set; }
        public ConceptCode Code { get; protected set; }

        public ConceptSpec(Int32 code)
        {
            Code = new ConceptCode(code);
        }
        public virtual IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new TermTarget(month, con, pos, var, article, this.Code)
            };
        }
        public int CompareTo(object obj)
        {
            IConceptSpec other = obj as IConceptSpec;

            return (this.Code.CompareTo(other.Code));
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            IConceptSpec other = obj as IConceptSpec;

            return (this.Code.Equals(other.Code));
        }

        public override int GetHashCode()
        {
            int result = this.Code.GetHashCode();

            return result;
        }
        public MonthCode GetMonthCode(IPeriod period)
        {
            return MonthCode.Get(period.Code);
        }
        protected static IList<Result<ITermResult, ITermResultError>> BuildResultList(params Result<ITermResult, ITermResultError>[] results)
        {
            return results.ToList();
        }
        protected static IList<Result<ITermResult, ITermResultError>> BuildEmptyResults()
        {
            return new List<Result<ITermResult, ITermResultError>>();
        }
        protected static IList<Result<ITermResult, ITermResultError>> BuildOkResults(params ITermResult[] resultValues)
        {
            return resultValues.Select((x) => Result.Ok<ITermResult, ITermResultError>(x)).ToList();
        }
        protected static IList<Result<ITermResult, ITermResultError>> BuildFailResults(params ITermResultError[] errorsValues)
        {
            return errorsValues.Select((x) => Result.Fail<ITermResult, ITermResultError>(x)).ToList();
        }
        protected static IList<Result<ITermResult, ITermResultError>> GetResults(IList<Result<ITermResult, ITermResultError>> results, ITermSymbol symbol)
        {
            return results.Where((x) => (x.IsSuccess && x.Value.IsPositionArticleEqual(symbol))).ToList();
        }
        protected static IList<ITermResult> GetOkPositionArticleResults(IList<Result<ITermResult, ITermResultError>> results, ITermSymbol symbol)
        {
            return results.Where((x) => (x.IsSuccess && x.Value.IsPositionArticleEqual(symbol)))
                .Select(x => x.Value).ToList();
        }
        protected static Result<IList<ITermResult>, ITermResultError> GetPositionArticleList(IList<Result<ITermResult, ITermResultError>> results, ITermSymbol symbol)
        {
            var reduceInit = Result.Ok<IList<ITermResult>, ITermResultError>(new List<ITermResult>());

            return results.Where((x) => (x.IsSuccess && x.Value.IsPositionArticleEqual(symbol)))
                .Aggregate(reduceInit, (agr, x) => ReduceResultList(agr, x));
        }
        protected static IList<ITermResultError> GetFailPositionArticleResults(IList<Result<ITermResult, ITermResultError>> results, MonthCode monthCode, ArticleCode article, ContractCode contract, PositionCode position)
        {
            return results.Where((x) => (x.IsFailure)).Select(x => x.Error).ToList();
        }
        protected static Result<Maybe<V>, ITermResultError> ReducePositionArticleList<V>(IList<Result<ITermResult, ITermResultError>> results, ITermSymbol symbol, 
            Func<Result<Maybe<V>, ITermResultError>, Result<ITermResult, ITermResultError>, Result<Maybe<V>, ITermResultError>> selector)
        {
            var reduceInit = Result.Ok<Maybe<V>, ITermResultError>(Maybe<V>.Nothing);

            return results.Where((x) => (x.IsSuccess && x.Value.IsPositionArticleEqual(symbol)))
                .Aggregate(reduceInit, (agr, t) => selector(agr, t));
        }
        protected static Result<Maybe<V>, ITermResultError> SelectPositionArticle<V>(IList<Result<ITermResult, ITermResultError>> results, ITermSymbol symbol, 
            Func<Result<ITermResult, ITermResultError>, Result<Maybe<V>, ITermResultError>> selector)
        {
            Result<ITermResult, ITermResultError> resultItem = results.FirstOrDefault((x) => (x.IsSuccess && x.Value.IsPositionArticleEqual(symbol)));
            
            return selector(resultItem);
        }
        protected static Result<Maybe<R>, ITermResultError> ResultSums<R>(Result<Maybe<R>, ITermResultError> agr, Result<ITermResult, ITermResultError> x, Func<ITermResult, R> valSelector, Func<R, R, R> sumFunc)
        {
            if (x.IsFailure)
            {
                return Result.Fail<Maybe<R>, ITermResultError>(x.Error);
            }
            if (agr.IsFailure)
            {
                return agr;
            }
            R resultValue = default;
            if (agr.Value.HasValue)
            {
                resultValue = agr.Value.Value;
            }
            return Result.Ok<Maybe<R>, ITermResultError>(Maybe.From<R>(sumFunc(resultValue, valSelector(x.Value))));
        }
        protected static Result<Maybe<R>, ITermResultError> ResultVals<R>(Result<ITermResult, ITermResultError> x, Func<ITermResult, R> valSelector)
        {
            if (x.IsFailure)
            {
                return Result.Fail<Maybe<R>, ITermResultError>(x.Error);
            }
            if (x.Value == null)
            {
                return Result.Ok<Maybe<R>, ITermResultError>(Maybe<R>.Nothing);
            }
            return Result.Ok<Maybe<R>, ITermResultError>(Maybe.From<R>(valSelector(x.Value)));
        }
        private static Result<IList<ITermResult>, ITermResultError> ReduceResultList(Result<IList<ITermResult>, ITermResultError> agr, Result<ITermResult, ITermResultError> x)
        {
            if (agr.IsFailure)
            {
                return agr;
            }
            if (x.IsFailure)
            {
                return Result.Fail<IList<ITermResult>, ITermResultError>(x.Error);
            }     
            return Result.Ok<IList<ITermResult>, ITermResultError>(MergeResults(agr.Value, x.Value));
        }
        private static IList<ITermResult> MergeResults(IList<ITermResult> results, params ITermResult[] resultValues)
        {
            return results.Concat(resultValues).ToList();
        }
        public static IEnumerable<ArticleCode> ConstToPathArray(IEnumerable<Int32> _path)
        {
            return _path.Select((x) => ArticleCode.Get(x));
        }

        public static Result<IPropsSalary, ITermResultError> GetSalaryPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsSalary propsType = GetSalaryProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsSalary>.CreateError(period, target);
                return Result.Fail<IPropsSalary, ITermResultError>(error);
            }
            return Result.Ok<IPropsSalary, ITermResultError>(propsType);
        }
        public static Result<IPropsHealth, ITermResultError> GetHealthPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsHealth propsType = GetHealthProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsHealth>.CreateError(period, target);
                return Result.Fail<IPropsHealth, ITermResultError>(error);
            }
            return Result.Ok<IPropsHealth, ITermResultError>(propsType);
        }
        public static Result<IPropsSocial, ITermResultError> GetSocialPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsSocial propsType = GetSocialProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsSocial>.CreateError(period, target);
                return Result.Fail<IPropsSocial, ITermResultError>(error);
            }
            return Result.Ok<IPropsSocial, ITermResultError>(propsType);
        }
        public static Result<IPropsTaxing, ITermResultError> GetTaxingPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsTaxing propsType = GetTaxingProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsTaxing>.CreateError(period, target);
                return Result.Fail<IPropsTaxing, ITermResultError>(error);
            }
            return Result.Ok<IPropsTaxing, ITermResultError>(propsType);
        }
        public static IPropsSalary GetSalaryProps(IBundleProps ruleset, IPeriod period)
        {
            IPropsSalary propsType = ruleset.SalaryProps as IPropsSalary;
            if (propsType == null || ruleset.PeriodProps.Code != period.Code)
            {
                return null;
            }
            return propsType;
        }
        public static IPropsHealth GetHealthProps(IBundleProps ruleset, IPeriod period)
        {
            IPropsHealth propsType = ruleset.HealthProps as IPropsHealth;
            if (propsType == null || ruleset.PeriodProps.Code != period.Code)
            {
                return null;
            }
            return propsType;
        }
        public static IPropsSocial GetSocialProps(IBundleProps ruleset, IPeriod period)
        {
            IPropsSocial propsType = ruleset.SocialProps as IPropsSocial;
            if (propsType == null || ruleset.PeriodProps.Code != period.Code)
            {
                return null;
            }
            return propsType;
        }
        public static IPropsTaxing GetTaxingProps(IBundleProps ruleset, IPeriod period)
        {
            IPropsTaxing propsType = ruleset.TaxingProps as IPropsTaxing;
            if (propsType == null || ruleset.PeriodProps.Code != period.Code)
            {
                return null;
            }
            return propsType;
        }
    }
}
