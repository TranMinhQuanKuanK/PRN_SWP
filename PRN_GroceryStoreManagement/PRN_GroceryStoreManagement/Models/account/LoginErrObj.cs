namespace PRN_GroceryStoreManagement.Models.account
{
    public class LoginErrObj
    {
        public int user_type { get; set; }
        public bool has_Error { get; set; }
        public string LoginErr { get; set; }

        public LoginErrObj(bool has_Error, int user_type)
        {
            this.has_Error = has_Error;
            this.user_type = user_type;
        }

        public LoginErrObj(string LoginErr)
        {
            this.LoginErr = LoginErr;
            this.has_Error = true;

        }
    }
}
