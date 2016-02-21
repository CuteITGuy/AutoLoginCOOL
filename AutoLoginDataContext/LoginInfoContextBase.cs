using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoLoginModels;


namespace AutoLoginDataContext
{
    public abstract class LoginInfoContextBase: IGetLoginInfo
    {
        #region Fields
        protected readonly string _filePath;
        protected readonly object _lockObj = new object();
        #endregion


        #region  Constructors & Destructor
        protected LoginInfoContextBase(string filePath)
        {
            _filePath = filePath;
        }
        #endregion


        #region Abstract
        protected abstract Website[] DoLoadLogic();

        protected abstract void DoSaveChangesLogic(Website[] websites);
        #endregion


        #region  Properties & Indexers
        public virtual ObservableCollection<Website> WebSites { get; protected set; } =
            new ObservableCollection<Website>();
        #endregion


        #region Methods
        public virtual void Load()
        {
            if (!File.Exists(_filePath)) return;

            lock (_lockObj)
            {
                var websites = DoLoadLogic();
                if (websites != null) WebSites = new ObservableCollection<Website>(websites);
            }
        }

        public virtual async Task LoadAsync() => await Task.Run(() => Load());

        public virtual void SaveChanges()
        {
            lock (_lockObj)
            {
                DoSaveChangesLogic(WebSites.ToArray());
            }
        }

        public virtual async Task SaveChangesAsync() => await Task.Run(() => SaveChanges());
        #endregion
    }
}