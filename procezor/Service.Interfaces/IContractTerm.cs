﻿using System;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface IContractTerm
    {
        ContractCode Contract { get; }
        DateTime? DateFrom { get; }
        DateTime? DateStop { get; }
        Byte TermDayFrom { get; }
        Byte TermDayStop { get; }
        bool IsActive();
    }
}
