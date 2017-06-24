using System;
using System.Collections.Generic;
using System.Text;

namespace LucidX.ResponseModels
{
    public class OrdersResponse
    {
        public int CompCode { get; set; }
        public string AccountCode { get; set; }
        public string LineDescription { get; set; }
        public int JournalNo { get; set; }
        public int JournalLine { get; set; }
        public string TransactionReference { get; set; }
        public decimal BaseAmount { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public bool isActualCurrency { get; set; }
        public string TransDate { get; set; }

    }
}
