using System;
using CB.Model.Common;


namespace AutoLoginModels
{
    [Serializable]
    public class Account: ObservableObject
    {
        #region Fields
        private string _description;
        private string _name;
        private string _password;
        #endregion


        #region  Properties & Indexers
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        #endregion
    }
}