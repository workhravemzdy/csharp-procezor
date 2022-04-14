using System;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class PositionTerm : IPositionTerm
    {
        public ContractCode Contract { get; set; }
        public PositionCode Position { get; set; }
        public IContractTerm BaseTerm { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateStop { get; set; }
        public Byte TermDayFrom { get; set; }
        public Byte TermDayStop { get; set; }
        public PositionTerm()
        {
            Contract = ContractCode.Zero;
            Position = PositionCode.Zero;
            BaseTerm = null;
            DateFrom = null;
            DateStop = null;
            TermDayFrom = TermConstants.TERM_BEG_NOTLIMIT;
            TermDayStop = TermConstants.TERM_END_NOTLIMIT;
        }
        public bool IsPositionActive()
        {
            return (TermDayFrom < TermConstants.TERM_BEG_FINISHED && TermDayStop > TermConstants.TERM_END_FINISHED);
        }

        public bool IsActive()
        {
            if (BaseTerm != null)
            {
                return (BaseTerm.IsActive() && IsPositionActive());
            }
            return IsPositionActive();
        }
    }
}
