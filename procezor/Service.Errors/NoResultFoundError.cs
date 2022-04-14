using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

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
        public static Result<T, ITermResultError> CreateResultError(IPeriod period, ITermTarget target, string article)
        {
            return Result.Fail<T, ITermResultError>(NoResultFoundError<T>.CreateError(period, target, article));
        }
        public static Result<T, ITermResultError> CreateResultError(IPeriod period, ITermTarget target, string article, ContractCode contract)
        {
            return Result.Fail<T, ITermResultError>(NoResultFoundError<T>.CreateError(period, target, article, contract));
        }
        public static Result<T, ITermResultError> CreateResultError(IPeriod period, ITermTarget target, string article, ContractCode contract, PositionCode position)
        {
            return Result.Fail<T, ITermResultError>(NoResultFoundError<T>.CreateError(period, target, article, contract, position));
        }
        NoResultFoundError(IPeriod period, ITermTarget target, string errorDesr) : base(period, target, null, errorDesr)
        {
        }
    }
}
