using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySky.Models
{
    public class TransactionRequestModel
    {

        public int ID { set; get; }

        public int ProcessingCode { set; get; }
       public int SystemTraceNr { set; get; }
        public int FunctionCode { set; get; }
        public long CardNo { set; get; }
        public string CardHolder { set; get; }
        public int AmountTrxn { set; get; }
        public int CurrencyCode { set; get; }

    }
    public class TransactionResponseModel
    {
        public int ID { set; get; }

        public int RequestID { set; get; }
        public int ResponseCode { set; get; }
        public string ApprovalCode { set; get; }
        public string DateTime { set; get; }
        public string Message { set; get; }

    }
}
