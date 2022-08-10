using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using LanguageExt;

namespace HraveMzdy.Procezor.Service.Providers
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Either<ITermResultError, ITermResult>>, IList<Either<ITermResultError, ITermResult>>>;
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
        protected static IList<ITermResult> EmptyResults()
        {
            return new List<ITermResult>();
        }
        protected static Either<ITermResultError, IEnumerable<ITermResult>> OkResultList(params ITermResult[] resultValues)
        {
            return Either<ITermResultError, IEnumerable<ITermResult>>.Right(resultValues.ToList());
        }
        protected static IList<Either<ITermResultError, ITermResult>> BuildEmptyResults()
        {
            return new List<Either<ITermResultError, ITermResult>>();
        }
        protected static IList<Either<ITermResultError, ITermResult>> BuildOkResults(params ITermResult[] resultValues)
        {
            return resultValues.Select((x) => Either<ITermResultError, ITermResult>.Right(x)).ToList();
        }
        protected static IList<Either<ITermResultError, ITermResult>> BuildFailResultList(params ITermResultError[] errorsValues)
        {
            return errorsValues.Select((x) => Either<ITermResultError, ITermResult>.Left(x)).ToList();
        }
       protected static IList<Either<ITermResultError, ITermResult>> BuildResultList(params Either<ITermResultError, ITermResult>[] results)
        {
            return results.ToList();
        }
        protected static IList<Either<ITermResultError, ITermResult>> BuildResultList(Either<ITermResultError, IEnumerable<ITermResult>> result)
        {
            return result.Match(Left: err => BuildFailResultList(err), Right: res => BuildOkResults(res.ToArray()));
        }
        protected static IList<Either<ITermResultError, ITermResult>> BuildResultList(Either<ITermResultError, Either<ITermResultError, IEnumerable<ITermResult>>> result)
        {
            return result.Match(Left: err => BuildFailResultList(err), Right: res => BuildResultList(res));
        }
        protected static IList<Either<ITermResultError, ITermResult>> BuildResultList(Either<ITermResultError, Either<ITermResultError, ITermResult>> result)
        {
            return result.Match(Left: err => BuildFailResultList(err), Right: res => BuildResultList(res)
            );
        }
        public static Either<ITermResultError, IPropsSalary> GetSalaryPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsSalary propsType = GetSalaryProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsSalary>.CreateError(period, target);
                return Either<ITermResultError, IPropsSalary>.Left(error);
            }
            return Either<ITermResultError, IPropsSalary>.Right(propsType);
        }
        public static Either<ITermResultError, IPropsHealth> GetHealthPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsHealth propsType = GetHealthProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsHealth>.CreateError(period, target);
                return Either<ITermResultError, IPropsHealth>.Left(error);
            }
            return Either<ITermResultError, IPropsHealth>.Right(propsType);
        }
        public static Either<ITermResultError, IPropsSocial> GetSocialPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsSocial propsType = GetSocialProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsSocial>.CreateError(period, target);
                return Either<ITermResultError, IPropsSocial>.Left(error);
            }
            return Either<ITermResultError, IPropsSocial>.Right(propsType);
        }
        public static Either<ITermResultError, IPropsTaxing> GetTaxingPropsResult(IBundleProps ruleset, ITermTarget target, IPeriod period)
        {
            IPropsTaxing propsType = GetTaxingProps(ruleset, period);
            if (propsType == null)
            {
                var error = InvalidRulesetError<IPropsTaxing>.CreateError(period, target);
                return Either<ITermResultError, IPropsTaxing>.Left(error);
            }
            return Either<ITermResultError, IPropsTaxing>.Right(propsType);
        }
        public static IEnumerable<ArticleCode> ConstToPathArray(IEnumerable<Int32> _path)
        {
            return _path.Select((x) => ArticleCode.Get(x));
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
