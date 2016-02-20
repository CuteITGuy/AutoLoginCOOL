using CB.Model.Common;


namespace AutoLoginModels
{
    public class LoginInfo: ObservableObject
    {
        #region Fields
        private string _password;
        private string _user;
        #endregion


        #region  Properties & Indexers
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        #endregion
    }
}