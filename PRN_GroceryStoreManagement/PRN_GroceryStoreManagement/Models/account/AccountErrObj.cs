namespace PRN_GroceryStoreManagement.Models.account
{
    public class AccountErrObj
    {
        public bool hasError { get; set; }
        public string currentPasswordError { get; set; }
        public string newPasswordError { get; set; }
        public string resetPasswordError{ get; set;}
        public string deleteAccountError{ get; set;}
        public string usernameLengthError{ get; set;}
        public string passwordLengthError{ get; set;}
        public string confirmNotMatch{ get; set;}
        public string nameLengthError{ get; set;}
        public string usernameExist{ get; set;}

        public AccountErrObj()
        {
            this.hasError = false;
            this.currentPasswordError = "";
            this.newPasswordError = "";
        }
    }
}
