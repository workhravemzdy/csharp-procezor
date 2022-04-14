using System;
using System.Linq;
using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ProcezorTests.Registry.Providers;
using ProcezorTests.Registry.Factories;

namespace ProcezorTests.Service.Examples
{
    public class ServiceProcezorExamlesTest
    {
        private readonly ITestOutputHelper output;

        private readonly ExampleService _sut;

        static IEnumerable<ITermTarget> GetTargetsWithSalaryHomeOffice(IPeriod period) {
            const Int16 CONTRACT_CODE = 0;
            const Int16 POSITION_CODE = 0;

            var montCode = MonthCode.Get(period.Code);
            var contract = ContractCode.Get(CONTRACT_CODE);
            var position = PositionCode.Get(POSITION_CODE);
            var variant1 = VariantCode.Get(1);

            var targets = new TermTarget[] {
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING)),
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_PAYMENT_SALARY),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS)),
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_ALLOWCE_HOFFICE),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED))
            };
            return targets;
        }
        static IEnumerable<ITermTarget> GetTargetsWithSalaryBonusBarter(IPeriod period) {
            const Int16 CONTRACT_CODE = 0;
            const Int16 POSITION_CODE = 0;

            var montCode = MonthCode.Get(period.Code);
            var contract = ContractCode.Get(CONTRACT_CODE);
            var position = PositionCode.Get(POSITION_CODE);
            var variant1 = VariantCode.Get(1);

            var targets = new TermTarget[] {
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING)),
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_PAYMENT_SALARY),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS)),
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_PAYMENT_BONUS),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED)),
                new ExampleTermTarget(montCode, contract, position, variant1,
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_PAYMENT_BARTER),
                    ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED))
            };
            return targets;
        }
        public ServiceProcezorExamlesTest(ITestOutputHelper output)
        {
            this.output = output;

            this._sut = new ExampleService();

         }
        [Fact]
        public void ServiceProcezorExampleWithSalaryHomeOfficeTest()
        {
            var testVersion = _sut.Version;
            testVersion.Value.Should().Be(100);

            var testPeriod = new Period(2021, 1);
            testPeriod.Code.Should().Be(202101);

            IBundleProps testLegal = BundleProps.Empty(testPeriod);

            var factoryArticleCode = ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING);

            var factoryArticle = _sut.GetArticleSpec(factoryArticleCode, testPeriod, testVersion);
            factoryArticle.Should().NotBeNull();
            factoryArticle.Code.Value.Should().NotBe(0);

            var factoryConceptCode = ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING);

            var factoryConcept = _sut.GetConceptSpec(factoryConceptCode, testPeriod, testVersion);
            factoryConcept.Should().NotBeNull();
            factoryConcept.Code.Value.Should().NotBe(0);

            var initService = _sut.InitWithPeriod(testPeriod);
            initService.Should().BeTrue();

            var restTargets = GetTargetsWithSalaryHomeOffice(testPeriod);
            var restService = _sut.GetResults(testPeriod, testLegal, restTargets);
            restService.Count().Should().NotBe(0);

            foreach (var (result, index) in restService.Select((item, index) => (item, index))) {
                if (result.IsSuccess) 
                {
                    var resultValue = result.Value;
                    var articleSymbol = resultValue.ArticleDescr();
                    var conceptSymbol = resultValue.ConceptDescr();
                    output.WriteLine("Index: {0}; ART: {1}; CON: {2}", index, articleSymbol, conceptSymbol);
                }
                else if (result.IsFailure) 
                {
                    var errorValue = result.Error;
                    var articleSymbol = errorValue.ArticleDescr();
                    var conceptSymbol = errorValue.ConceptDescr();
                    output.WriteLine("Index: {0}; ART: {1}; CON: {2}; Error: {3}", index, articleSymbol, conceptSymbol, errorValue);
                }
            }

            var restArticles = restService.Where((r) => (r.IsSuccess)).Select((x) => (x.Value.Article.Value)).ToArray();
            restArticles.Should().NotBeEmpty()
                .And.HaveCount(11)
                .And.ContainInOrder(new[] { 80001, 80005, 80002, 80006, 80007, 80010, 80012, 80008, 80009, 80011, 80013 })
                .And.ContainItemsAssignableTo<Int32>();

        }
        [Fact]
        public void ServiceProcezorExampleWithSalaryBonusBarterTest()
        {
            var testVersion = _sut.Version;
            testVersion.Value.Should().Be(100);

            var testPeriod = new Period(2021, 1);
            testPeriod.Code.Should().Be(202101);

            IBundleProps testLegal = BundleProps.Empty(testPeriod);

            var factoryArticleCode = ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING);

            var factoryArticle = _sut.GetArticleSpec(factoryArticleCode, testPeriod, testVersion);
            factoryArticle.Should().NotBeNull();
            factoryArticle.Code.Value.Should().NotBe(0);

            var factoryConceptCode = ConceptCode.Get((Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING);

            var factoryConcept = _sut.GetConceptSpec(factoryConceptCode, testPeriod, testVersion);
            factoryConcept.Should().NotBeNull();
            factoryConcept.Code.Value.Should().NotBe(0);

            var initService = _sut.InitWithPeriod(testPeriod);
            initService.Should().BeTrue();

            var restTargets = GetTargetsWithSalaryBonusBarter(testPeriod);
            var restService = _sut.GetResults(testPeriod, testLegal, restTargets);
            restService.Count().Should().NotBe(0);

            foreach (var (result, index) in restService.Select((item, index) => (item, index))) {
                if (result.IsSuccess) 
                {
                    var resultValue = result.Value;
                    var articleSymbol = resultValue.ArticleDescr();
                    var conceptSymbol = resultValue.ConceptDescr();
                    output.WriteLine("Index: {0}; ART: {1}; CON: {2}", index, articleSymbol, conceptSymbol);
                }
                else if (result.IsFailure) 
                {
                    var errorValue = result.Error;
                    var articleSymbol = errorValue.ArticleDescr();
                    var conceptSymbol = errorValue.ConceptDescr();
                    output.WriteLine("Index: {0}; ART: {1}; CON: {2}; Error: {3}", index, articleSymbol, conceptSymbol, errorValue);
                }
            }

            var restArticles = restService.Where((r) => (r.IsSuccess)).Select((x) => (x.Value.Article.Value)).ToArray();
            restArticles.Should().NotBeEmpty()
                .And.HaveCount(12)
                .And.ContainInOrder(new[] { 80001, 80003, 80004, 80002, 80006, 80007, 80010, 80012, 80008, 80009, 80011, 80013 })
                .And.ContainItemsAssignableTo<Int32>();

        }
    }
}
