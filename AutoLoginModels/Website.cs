using System;
using System.Linq;
using System.Runtime.Serialization;
using CB.Model.Common;


namespace AutoLoginModels
{
    [Serializable]
    public class Website: ObservableObject
    {
        #region Fields
        private Account[] _accounts = { };
        private string _name;
        private string _url;
        #endregion


        #region  Properties & Indexers
        public Account[] Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
        #endregion


        #region Methods
        public void AddAcount(string name, string password, string description = null)
        {
            var account = Accounts.FirstOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (account != null)
            {
                account.Password = password;
                account.Description = description;
            }
            else
            {
                var newAccounts = new Account[Accounts.Length + 1];
                Accounts.CopyTo(newAccounts, 0);
                newAccounts[Accounts.Length] = new Account
                {
                    Name = name,
                    Password = password,
                    Description = description
                };
                Accounts = newAccounts;
            }
        }
        #endregion
    }
}