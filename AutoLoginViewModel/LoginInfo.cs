using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoLoginDataContext;
using AutoLoginModels;
using CB.Model.Common;


namespace AutoLoginViewModel
{
    public class LoginInfo: ObservableObject
    {
        #region Fields
        private readonly IGetLoginInfo _loginInfoContext;
        private Account _selectedAccount;
        private Website _selectedWebsite;
        private ObservableCollection<Website> _websites;
        #endregion


        #region  Constructors & Destructor
        public LoginInfo(IGetLoginInfo loginInfoContext)
        {
            _loginInfoContext = loginInfoContext;
        }
        #endregion


        #region  Properties & Indexers
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set { SetProperty(ref _selectedAccount, value); }
        }

        public Website SelectedWebsite
        {
            get { return _selectedWebsite; }
            set
            {
                if (SetProperty(ref _selectedWebsite, value))
                    SelectedAccount = SelectedWebsite?.Accounts?.Length > 0 ? SelectedWebsite.Accounts[0] : null;
            }
        }

        public ObservableCollection<Website> Websites
        {
            get { return _websites; }
            private set
            {
                if (SetProperty(ref _websites, value))
                    SelectedWebsite = Websites?.Count > 0 ? Websites[0] : null;
            }
        }
        #endregion


        #region Methods
        public void AddAcount(string name, string password, string description)
            => SelectedWebsite?.AddAcount(name, password, description);

        public void AddWebsite(string name)
        {
            if (!Websites.Any(w => w.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                Websites.Add(new Website { Name = name });
        }

        public void Load()
        {
            _loginInfoContext.Load();
            LoadWebsites();
        }

        public async Task LoadAsync()
        {
            await _loginInfoContext.LoadAsync();
            LoadWebsites();
        }

        public void Save() => _loginInfoContext.SaveChanges();

        public async Task SaveAsync() => await _loginInfoContext.SaveChangesAsync();
        #endregion


        #region Implementation
        private void LoadWebsites() => Websites = _loginInfoContext.WebSites;
        #endregion
    }
}