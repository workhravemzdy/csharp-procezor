using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ResultMonad;

namespace ProcezorTests.Registry.Providers
{
    // TimeshtWorking			TIMESHT_WORKING
    class TimeshtWorkingConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING;
        public TimeshtWorkingConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimeshtWorkingConSpec(this.Code.Value);
        }
    }

    class TimeshtWorkingConSpec : ExampleConceptSpec
    {
        public TimeshtWorkingConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new TimeshtWorkingResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // AmountBasis			AMOUNT_BASIS
    class AmountBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS;
        public AmountBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AmountBasisConSpec(this.Code.Value);
        }
    }

    class AmountBasisConSpec : ExampleConceptSpec
    {
        public AmountBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new AmountBasisResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // AmountFixed			AMOUNT_FIXED
    class AmountFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;
        public AmountFixedConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AmountFixedConSpec(this.Code.Value);
        }
    }

    class AmountFixedConSpec : ExampleConceptSpec
    {
        public AmountFixedConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new AmountFixedResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // HealthInsbase			HEALTH_INSBASE
    class HealthInsbaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSBASE;
        public HealthInsbaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsbaseConSpec(this.Code.Value);
        }
    }

    class HealthInsbaseConSpec : ExampleConceptSpec
    {
        public HealthInsbaseConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new HealthInsbaseResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // SocialInsbase			SOCIAL_INSBASE
    class SocialInsbaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSBASE;
        public SocialInsbaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInsbaseConSpec(this.Code.Value);
        }
    }

    class SocialInsbaseConSpec : ExampleConceptSpec
    {
        public SocialInsbaseConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new SocialInsbaseResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // HealthInspaym			HEALTH_INSPAYM
    class HealthInspaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSPAYM;
        public HealthInspaymConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInspaymConSpec(this.Code.Value);
        }
    }

    class HealthInspaymConSpec : ExampleConceptSpec
    {
        public HealthInspaymConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new HealthInspaymResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // SocialInspaym			SOCIAL_INSPAYM
    class SocialInspaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSPAYM;
        public SocialInspaymConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInspaymConSpec(this.Code.Value);
        }
    }

    class SocialInspaymConSpec : ExampleConceptSpec
    {
        public SocialInspaymConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new SocialInspaymResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // TaxingAdvbase			TAXING_ADVBASE
    class TaxingAdvbaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVBASE;
        public TaxingAdvbaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvbaseConSpec(this.Code.Value);
        }
    }

    class TaxingAdvbaseConSpec : ExampleConceptSpec
    {
        public TaxingAdvbaseConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new TaxingAdvbaseResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // TaxingAdvpaym			TAXING_ADVPAYM
    class TaxingAdvpaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVPAYM;
        public TaxingAdvpaymConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvpaymConSpec(this.Code.Value);
        }
    }

    class TaxingAdvpaymConSpec : ExampleConceptSpec
    {
        public TaxingAdvpaymConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new TaxingAdvpaymResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // IncomeGross			INCOME_GROSS
    class IncomeGrossConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_GROSS;
        public IncomeGrossConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeGrossConSpec(this.Code.Value);
        }
    }

    class IncomeGrossConSpec : ExampleConceptSpec
    {
        public IncomeGrossConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new IncomeGrossResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }


    // IncomeNetto			INCOME_NETTO
    class IncomeNettoConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO;
        public IncomeNettoConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoConSpec(this.Code.Value);
        }
    }

    class IncomeNettoConSpec : ExampleConceptSpec
    {
        public IncomeNettoConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSPAYM,
                (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSPAYM,
                (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVPAYM,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new IncomeNettoResult(target, spec);

            return BuildOkResults(resultsValues);
        }
    }
}
