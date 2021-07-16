using System;
using System.Collections.Generic;

namespace PRN_GroceryStoreManagement.Models.previousBill
{
    public class PreBillDTO
    {
        public int billID { get; set; }
        public int totalCost { get; set; }
        public int pointUsed { get; set; }
        public int cash { get; set; }
        public String name { get; set; }
        public String phoneNo { get; set; }
        public String buyDate { get; set; }
        public String cashier { get; set; }
        public List<PreBillDetailDTO> details { get; set; }

        public PreBillDTO(int billID, int totalCost, int pointUsed, int cash, String name, String phoneNo, String buyDate, String cashier, List<PreBillDetailDTO> details)
        {
            this.billID = billID;
            this.totalCost = totalCost;
            this.pointUsed = pointUsed;
            this.cash = cash;
            this.name = name;
            this.phoneNo = phoneNo;
            this.buyDate = buyDate;
            this.cashier = cashier;
            this.details = details;
        }

    }
}