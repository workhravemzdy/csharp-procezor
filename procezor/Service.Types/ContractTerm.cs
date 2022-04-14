using System;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class ContractTerm : IContractTerm
    {
        public ContractCode Contract { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateStop { get; set; }
        public Byte TermDayFrom { get; set; }
        public Byte TermDayStop { get; set; }
        public ContractTerm()
        {
            Contract = ContractCode.Zero;
            DateFrom = null;
            DateStop = null;
            TermDayFrom = TermConstants.TERM_BEG_NOTLIMIT;
            TermDayStop = TermConstants.TERM_END_NOTLIMIT;
        }
        public bool IsActive()
        {
            return (TermDayFrom < TermConstants.TERM_BEG_FINISHED && TermDayStop > TermConstants.TERM_END_FINISHED);
        }
    }
}
