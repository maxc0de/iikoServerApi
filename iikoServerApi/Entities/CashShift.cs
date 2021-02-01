using System;

namespace IikoServerApi
{
    public class CashShift
    {
        public string Id { get; set; }
        public int SessionNumber { get; set; }
        public int? FiscalNumber { get; set; }
        public int CashRegNumber { get; set; }
        public string CashRegSerial { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public string ManagerId { get; set; }
        public string ResponsibleUser { get; set; }
        public int SessionStartCash { get; set; }
        public decimal PayOrders { get; set; }
        public int SumWriteoffOrders { get; set; }
        public decimal SalesCash { get; set; }
        public int SalesCredit { get; set; }
        public int SalesCard { get; set; }
        public int PayIn { get; set; }
        public int PayOut { get; set; }
        public decimal PayIncome { get; set; }
        public int? CashRemain { get; set; }
        public decimal CashDiff { get; set; }
        public CashShiftStatus SessionStatus { get; set; }
        public string Conception { get; set; }
        public string PointOfSale { get; set; }
    }
}