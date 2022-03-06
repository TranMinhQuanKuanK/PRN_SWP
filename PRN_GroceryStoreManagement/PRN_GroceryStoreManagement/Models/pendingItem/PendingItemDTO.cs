using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.pendingItem
{
    public class PendingItemDTO
    {
        public int pendingID { get; set; }
        public int product_ID { get; set; }
        public DateTime pending_date { get; set; }
        public bool is_resolved { get; set; }
        public string note { get; set; }

        public PendingItemDTO(int pendingID, int product_ID, DateTime pending_date, bool is_resolved, string note)
        {
            this.pendingID = pendingID;
            this.product_ID = product_ID;
            this.pending_date = pending_date;
            this.is_resolved = is_resolved;
            this.note = note;
        }
    }
}
