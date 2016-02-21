using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoLoginModels;
using CB.Model.Common;


namespace AutoLoginDataContext
{
    public interface IGetLoginInfo
    {
        #region Abstract
        void Load();
        Task LoadAsync();
        void SaveChanges();
        Task SaveChangesAsync();
        ObservableCollection<Website> WebSites { get; }
        #endregion
    }
}