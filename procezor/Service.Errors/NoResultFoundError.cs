using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class NoResultFoundError<T> : TermResultError
        where T : class, ITermResult
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string article)
        {
            return new NoResultFoundError<T>(period, target, $"Result for {article} Not Found");
        }
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string article, ContractCode contract)
        {
            return new NoResultFoundError<T>(period, target, $"Result for {article}, contract={contract.Value} Not Found");
        }
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string article, ContractCode contract, PositionCode position)
        {
            return new NoResultFoundError<T>(period, target, $"Result for {article}, contract={contract.Value}, position={position.Value} Not Found");
        }
        public static Either<ITermResultError, T> CreateResultError(IPeriod period, ITermTarget target, string article)
        {
            return Left(NoResultFoundError<T>.CreateError(period, target, article));
        }
        public static Either<ITermResultError, T> CreateResultError(IPeriod period, ITermTarget target, string article, ContractCode contract)
        {
            return Left(NoResultFoundError<T>.CreateError(period, target, article, contract));
        }
        public static Either<ITermResultError, T> CreateResultError(IPeriod period, ITermTarget target, string article, ContractCode contract, PositionCode position)
        {
            return Left(NoResultFoundError<T>.CreateError(period, target, article, contract, position));
        }
        NoResultFoundError(IPeriod period, ITermTarget target, string errorDesr) : base(period, target, null, errorDesr)
        {
        }
    }
}
