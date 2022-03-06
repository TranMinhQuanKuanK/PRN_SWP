using System;
using PRN_GroceryStoreManagement.Models.account;

namespace PRN_GroceryStoreManagement.Models.feedback
{
    public class FeedbackDTO {
        public int feedback_ID {get; set;}
        public DateTime feedback_date {get; set;}
        public String feedback_content {get; set;}
        public bool is_seen {get; set;}
        public AccountDTO account {get; set;}

        public FeedbackDTO (int feedback_ID, DateTime feedback_date, String feedback_content, bool is_seen, AccountDTO account) {
            this.feedback_ID = feedback_ID;
            this.feedback_date = feedback_date;
            this.feedback_content = feedback_content;
            this.is_seen = is_seen;
            this.account = account;
        }
    }
}