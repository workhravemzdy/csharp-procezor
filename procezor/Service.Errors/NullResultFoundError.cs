using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using LanguageExt;
using static LanguageExt.Prelude;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class NullResultFoundError<T> : TermResultError
        where T : class, ITermResult
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string article)
        {
            return new NullResultFoundError<T>(period, target, $"Result found for {article} but Instance is Null!");
        }
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string article, ContractCode contract)
        {
            return new NullResultFoundError<T>(period, target, $"Result found for {article}, contract={contract.Value} but Instance is Null!");
        }
        public static ITermResultError CreateError(IPeriod period, ITermTarget target, string article, ContractCode contract, PositionCode position)
        {
            return new NullResultFoundError<T>(period, target, $"Result found for {article}, contract={contract.Value}, position={position.Value} but Instance is Null!");
        }
        public static Either<ITermResultError, T> CreateResultError(IPeriod period, ITermTarget target, string article)
        {
            return Left(NullResultFoundError<T>.CreateError(period, target, article));
        }
        public static Either<ITermResultError, T> CreateResultError(IPeriod period, ITermTarget target, string article, ContractCode contract)
        {
            return Left(NullResultFoundError<T>.CreateError(period, target, article, contract));
        }
        public static Either<ITermResultError, T> CreateResultError(IPeriod period, ITermTarget target, string article, ContractCode contract, PositionCode position)
        {
            return Left(NullResultFoundError<T>.CreateError(period, target, article, contract, position));
        }
        NullResultFoundError(IPeriod period, ITermTarget target, string errorDesr) : base(period, target, null, errorDesr)
        {
        }
    }
}
