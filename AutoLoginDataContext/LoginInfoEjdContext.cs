using System.Collections.ObjectModel;
using System.IO;
using System.Web.Script.Serialization;
using AutoLoginModels;


namespace AutoLoginDataContext
{
    public class LoginInfoEjdContext: LoginInfoContextBase
    {
        #region  Constructors & Destructor
        public LoginInfoEjdContext(string filePath): base(filePath) { }
        #endregion


        #region Override
        protected override Website[] DoLoadLogic()
        {
            var ser = CreateWebsitesSerializer();
            var contents = File.ReadAllText(_filePath);
            return ser.Deserialize<Website[]>(contents);
        }

        protected override void DoSaveChangesLogic(Website[] websites)
        {
            var ser = CreateWebsitesSerializer();
            var contents = ser.Serialize(websites);
            File.WriteAllText(_filePath, contents);
        }
        #endregion


        #region Implementation
        private static JavaScriptSerializer CreateWebsitesSerializer()
        {
            return new JavaScriptSerializer();
        }
        #endregion
    }
}