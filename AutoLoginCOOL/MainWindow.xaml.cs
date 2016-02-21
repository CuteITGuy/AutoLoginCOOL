using System;
using System.Configuration;
using System.Windows;
using AutoLoginDataContext;
using AutoLoginViewModel;


namespace AutoLoginCOOL
{
    public partial class MainWindow
    {
        #region Fields
        private const string DATA_FILE_NAME = "data";
        private readonly LoginInfo _loginInfo = new LoginInfo(CreateLoginInfoContext());
        #endregion


        #region  Constructors & Destructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Event Handlers
        private async void CmdAddAccount_OnClick(object sender, RoutedEventArgs e)
        {
            _loginInfo.AddAcount(lstAccounts.Text, txtPassword.Password, txtDescription.Text);
            await _loginInfo.SaveAsync();
        }

        private async void CmdAddWebsite_OnClick(object sender, RoutedEventArgs e)
        {
            _loginInfo.AddWebsite(lstWebsites.Text);
            await _loginInfo.SaveAsync();
        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await _loginInfo.LoadAsync();
            DataContext = _loginInfo;
        }
        #endregion


        #region Implementation
        private static IGetLoginInfo CreateLoginInfoContext()
        {
            var serializeType = ConfigurationManager.AppSettings["serializeType"]?.ToLower();
            IGetLoginInfo result = null;
            var filePath = $"{DATA_FILE_NAME}.{serializeType}";

            switch (serializeType)
            {
                case "ebd":
                    result = new LoginInfoEbdContext(filePath);
                    break;
                case "ejd":
                    result = new LoginInfoEjdContext(filePath);
                    break;
                case "exd":
                    result = new LoginInfoExdContext(filePath);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return result;
        }
        #endregion
    }
}