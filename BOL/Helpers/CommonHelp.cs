using BOL.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSBillingSoftware.Helpers
{
    public class CommonHelp
    {
        public static string GenerateInvoiceNumber(long invoiceId)
        {
            return Invoice.INV.ToString() + invoiceId;
        }
    }
}