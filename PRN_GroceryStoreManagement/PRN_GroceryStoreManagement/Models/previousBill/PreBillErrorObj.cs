namespace PRN_GroceryStoreManagement.Models.previousBill
{
    public class PreBillErrorObj
    {
        public bool isError { get; set; }
        public string dateError { get; set; }

        public PreBillErrorObj()
        {
            this.isError = false;
            this.dateError = "";
        }

    }
}